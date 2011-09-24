using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace NET.Tools.Forms
{
    [ToolboxItemFilter("NET Tools")]
    public partial class Header : UserControl
    {
        [Browsable(true)]
        [Category("Appearance")]
        public Color TopColor
        {
            get;
            set;
        }

        [Browsable(true)]
        [Category("Appearance")]
        public Color BottomColor
        {
            get;
            set;
        }

        [Browsable(true)]
        [Category("Appearance")]
        public Color HeaderColor
        {
            get { return lblHeader.ForeColor; }
            set { lblHeader.ForeColor = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public Color InfoColor
        {
            get { return lblDescription.ForeColor; }
            set { lblDescription.ForeColor = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Localizable(true)]
        public Font HeaderFont
        {
            get { return lblHeader.Font; }
            set { lblHeader.Font = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Localizable(true)]
        public Font InfoFont
        {
            get { return lblDescription.Font; }
            set { lblDescription.Font = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Localizable(true)]
        public String HeaderText
        {
            get { return lblHeader.Text; }
            set { lblHeader.Text = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Localizable(true)]
        public String InfoText
        {
            get { return lblDescription.Text; }
            set { lblDescription.Text = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Localizable(true)]
        public Image Icon
        {
            get { return imgIcon.Image; }
            set { imgIcon.Image = value; }
        }

        public Header()
        {
            InitializeComponent();

            TopColor = SystemColors.ActiveCaption;
            BottomColor = SystemColors.GradientActiveCaption;
            Icon = Properties.Resources.Default.ToBitmap();
        }

        private void Header_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(
                new LinearGradientBrush(
                    new Point(0, 0), new Point(0, 50), TopColor, BottomColor),
                e.ClipRectangle);
        }

        private void Header_Resize(object sender, EventArgs e)
        {
            this.Height = 50;
        }
    }
}
