using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Drawing;
using System.ComponentModel;

using System.Drawing.Design;

namespace NET.Tools.Forms
{
    [ToolboxItemFilter("NET Tools")]
    [DefaultEvent("TextChanged")]
    [DefaultProperty("RecordList")]
    public sealed class HighLightingTextBox : RichTextBox
    {
        [DllImport("user32.dll")]
        private static extern bool LockWindowUpdate(IntPtr hwndLock);

        private HighLightingRecord[] recordList;

        [Browsable(true)]
        [Category("Behavior")]
        [Description("List of all highlighting records")]
        [Editor(typeof(UIHighLightingEditor), typeof(UITypeEditor))]
        [DesignOnly(false)]
        public HighLightingRecord[] RecordList
        {
            get { return recordList; }
            set { recordList = value; HighLiteTextBox_TextChanged(this, new EventArgs()); }
        }

        public HighLightingTextBox()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            TextChanged += new EventHandler(HighLiteTextBox_TextChanged);
            RecordList = new HighLightingRecord[0];
            HighLiteTextBox_TextChanged(this, new EventArgs());
        }

        private void HighLiteTextBox_TextChanged(object sender, EventArgs e)
        {
            if ((RecordList == null) || (RecordList.Length <= 0))
                return;

            try
            {
                LockWindowUpdate(this.Handle);

                //Save old position
                int oldPosition = this.SelectionStart;

                //Clean up
                this.Select(0, this.Text.Length);
                this.SelectionColor = this.ForeColor;
                this.SelectionBackColor = this.BackColor;
                this.SelectionFont = this.Font;
                this.SelectionStart = oldPosition;

                //Find Key Words
                foreach (HighLightingRecord rec in RecordList)
                {
                    foreach (Match match in rec.RegularExpression.Matches(this.Text))
                    {
                        this.Select(match.Index, match.Length);
                        this.SelectionColor = rec.ForeColor;
                        this.SelectionBackColor = rec.BackColor;
                        this.SelectionFont = new Font(this.Font, rec.FontStyle);
                    }
                }

                //Reset to old position and color
                this.SelectionStart = oldPosition;
                this.SelectionLength = 0;
                this.SelectionColor = this.ForeColor;
                this.SelectionBackColor = Color.Transparent;
                this.SelectionFont = this.Font;
            }
            finally
            {
                LockWindowUpdate(IntPtr.Zero);
            }
        }
    }
}
