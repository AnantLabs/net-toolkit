using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using NET.Tools.Forms.Frames;




namespace NET.Tools.Forms
{
    /// <summary>
    /// Represent a save picture dialog
    /// 
    /// <remarks>
    /// Support languages:
    /// - English (Default)
    /// - German
    /// </remarks>
    /// </summary>
    [ToolboxItemFilter("NET Tools")]
    public sealed class SavePictureDialog : CommonDialog, IPictureDialog
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

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets that the dialog warn if the selected file exists")]
        [DefaultValue(true)]
        public bool OverwritePromt { get; set; }

        #endregion

        public SavePictureDialog()
        {
            UseBMPFilter = true;
            UseJPEGFilter = true;
            UsePNGFilter = true;
            InitialDirectory = new DirectoryInfo("C:\\");
            filterIndex = PictureFilterIndex.JPEG;
            FileName = "";
            OverwritePromt = true;
        }

        public override void Reset()
        {
        }

        protected override bool RunDialog(IntPtr hwndOwner)
        {
            PictureDialog dlg = new PictureDialog(PictureDialog.DialogType.Open, UseBMPFilter, UseJPEGFilter,
                UsePNGFilter, filterIndex, false, OverwritePromt, InitialDirectory, FileName);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileName = dlg.FileNames[0];
                return true;
            }

            return false;
        }
    }
}
