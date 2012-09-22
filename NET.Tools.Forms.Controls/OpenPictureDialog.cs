using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using System.Threading;
using NET.Tools.Forms.Frames;




namespace NET.Tools.Forms
{
    /// <summary>
    /// Represent a open picture dialog
    /// 
    /// <remarks>
    /// Support languages:
    /// - English (Default)
    /// - German
    /// </remarks>
    /// </summary>
    [ToolboxItemFilter("NET Tools")]
    public sealed class OpenPictureDialog : CommonDialog, IPictureDialog
    {
        private PictureFilterIndex filterIndex;

        #region Properties

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Use the filter for JPEGs")]
        [DefaultValue(true)]
        public bool UseJPEGFilter { get; set; }
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Use the filter for BMPs")]
        [DefaultValue(true)]
        public bool UseBMPFilter { get; set; }
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Use the filter for PNGs")]
        [DefaultValue(true)]
        public bool UsePNGFilter { get; set; }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets the multi selecting")]
        [DefaultValue(false)]
        public bool MultiSelect { get; set; }
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets the first time directory")]
        [Editor(typeof(UIDirectoryInfoEditor), typeof(UITypeEditor))]
        public DirectoryInfo InitialDirectory { get; set; }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets the filter index")]
        [DefaultValue(PictureFilterIndex.JPEG)]
        public PictureFilterIndex FilterIndex {
            get { return filterIndex; }
            set
            {
                switch (value)
                {
                    case PictureFilterIndex.BMP:
                        if (!UseBMPFilter) throw new ArgumentException("The BMP Filter is deactivated!");
                        break;
                    case PictureFilterIndex.JPEG:
                        if (!UseJPEGFilter) throw new ArgumentException("The JPEG Filter is deactivated!");
                        break;
                    case PictureFilterIndex.PNG:
                        if (!UsePNGFilter) throw new ArgumentException("The PNG Filter is deactivated!");
                        break;
                    default:
                        throw new NotImplementedException();
                }

                filterIndex = value;
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets the initial file name")]
        [DefaultValue("")]
        public String FileName { get; set; }
        [Browsable(false)]
        public List<String> FileNames { get; private set; }

        #endregion

        public OpenPictureDialog()
        {
            UseBMPFilter = true;
            UseJPEGFilter = true;
            UsePNGFilter = true;
            MultiSelect = false;
            InitialDirectory = new DirectoryInfo("C:\\");
            filterIndex = PictureFilterIndex.JPEG;
            FileName = "";
            FileNames = new List<String>();
        }

        public override void Reset()
        {
        }

        protected override bool RunDialog(IntPtr hwndOwner)
        {
            PictureDialog dlg = new PictureDialog(PictureDialog.DialogType.Open, UseBMPFilter, UseJPEGFilter,
                UsePNGFilter, filterIndex, MultiSelect, false, InitialDirectory, FileName);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileName = dlg.FileNames[0];
                FileNames = dlg.FileNames;
                return true;
            }

            return false;
        }
    }
}
