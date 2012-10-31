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
    public partial class FontComboBox : UserControl
    {
        private bool cacheFonts = false;

        [Browsable(true)]
        [Category("Behavior")]
        public event EventHandler SelectedFontChanged;

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets that the font face is drawing for each item")]
        [DefaultValue(true)]
        public bool DrawFontFace
        {
            get { return cmbFonts.DrawFont; }
            set { cmbFonts.DrawFont = value; }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets that the font face is drawing in the header of the box")]
        [DefaultValue(false)]
        public bool DrawFontFaceInHead
        {
            get { return cmbFonts.DrawFontInEditBox; }
            set { cmbFonts.DrawFontInEditBox = value; }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets the selected font as font family")]
        public FontFamily SelectedFontFamily
        {
            get { return cmbFonts.SelectedItem as FontFamily; }
            set { cmbFonts.SelectedItem = value; }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets that all fonts loaded at first")]
        [DefaultValue(false)]
        //[DesignOnly(true)]
        public bool CacheFonts
        {
            get { return cacheFonts; }
            set
            {
                cacheFonts = value;
                if (cacheFonts)
                    cmbFonts.CacheFonts();
                else
                    cmbFonts.ClearFontCache();
            }
        }

        public FontComboBox()
        {
            InitializeComponent();
            this.Height = cmbFonts.Height;

            DrawFontFace = true;
            DrawFontFaceInHead = false;

            foreach (FontFamily ff in FontFamily.Families)
            {
                cmbFonts.Items.Add(ff);
            }
            cmbFonts.SelectedIndex = 0;
        }

        private void FontComboBox_Resize(object sender, EventArgs e)
        {
            this.Height = cmbFonts.Height;
        }

        protected void DoSelectedFontChanged()
        {
            if (SelectedFontChanged != null)
                SelectedFontChanged(this, new EventArgs());
        }

        private void cmbFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoSelectedFontChanged();
        }
    }
}
