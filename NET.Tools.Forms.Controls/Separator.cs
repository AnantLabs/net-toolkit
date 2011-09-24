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
    public partial class Separator : UserControl
    {
        private Orientation orientation;

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Represent a seperator line")]
        [DefaultValue(Orientation.Horizontal)]
        public Orientation Orientation
        {
            get { return orientation; }
            set
            {
                bool other = orientation != value;
                orientation = value;
                ResetSize(other);

                switch (orientation)
                {
                    case Orientation.Horizontal:
                        SetStyle(ControlStyles.FixedHeight, true);
                        SetStyle(ControlStyles.FixedWidth, false);
                        break;
                    case Orientation.Vertical:
                        SetStyle(ControlStyles.FixedHeight, false);
                        SetStyle(ControlStyles.FixedWidth, true);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text
        {
            get
            {
                return "";
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public Separator()
        {
            InitializeComponent();
            orientation = Orientation.Horizontal;
            ResetSize(false);

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.FixedHeight, true);
        }

        private void Separator_Resize(object sender, EventArgs e)
        {
            ResetSize(false);
        }

        private void ResetSize(bool negative)
        {
            if (negative)
            {
                if (orientation == Orientation.Horizontal)
                {
                    int old = this.Height;
                    this.Height = 2;
                    this.Width = old;
                }
                else if (orientation == Orientation.Vertical)
                {
                    int old = this.Width;
                    this.Width = 2;
                    this.Height = old;
                }
                else
                    throw new NotImplementedException();
            }
            else
            {
                if (orientation == Orientation.Horizontal)
                    this.Height = 2;
                else if (orientation == Orientation.Vertical)
                    this.Width = 2;
                else
                    throw new NotImplementedException();
            }
        }

        private void Separator_Paint(object sender, PaintEventArgs e)
        {
            if (orientation == Orientation.Horizontal)
            {
                e.Graphics.DrawLine(BackColor.ToPen(), 0, 0, this.Width, 0);
                e.Graphics.DrawLine(ForeColor.ToPen(), 0, 1, this.Width, 1);
            }
            else if (orientation == Orientation.Vertical)
            {
                e.Graphics.DrawLine(BackColor.ToPen(), 0, 0, 0, this.Height);
                e.Graphics.DrawLine(ForeColor.ToPen(), 1, 0, 1, this.Height);
            }
            else
                throw new NotImplementedException();
        }
    }
}
