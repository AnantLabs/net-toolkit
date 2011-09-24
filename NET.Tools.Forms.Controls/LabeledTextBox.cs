using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NET.Tools.Forms
{
    [ToolboxItemFilter("NET Tools")]
    public partial class LabeledTextBox : UserControl
    {
        public override String Text
        {
            get
            {
                return txtInput.Text;
            }
            set
            {
                txtInput.Text = value;
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("The title of the textbox")]
        [Localizable(true)]
        public String Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("SET to true to stop edit text, otherwise false")]
        [DefaultValue(false)]
        public bool ReadOnly
        {
            get { return txtInput.ReadOnly; }
            set { txtInput.ReadOnly = value; }
        }

        [Browsable(true)]
        [Category("Behavior")]
        public event EventHandler TextChanged;

        public LabeledTextBox()
        {
            InitializeComponent();
            this.Height = lblTitle.Height + txtInput.Height;
        }

        private void LabeledTextBox_Resize(object sender, EventArgs e)
        {
            this.Height = lblTitle.Height + txtInput.Height;
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            if (TextChanged != null)
                TextChanged(this, e);
        }
    }
}
