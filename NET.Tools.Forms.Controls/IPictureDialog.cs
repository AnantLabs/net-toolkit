using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NET.Tools.Forms
{
    public interface IPictureDialog : IFileDialog
    {
        bool UseBMPFilter { get; set; }
        bool UseJPEGFilter { get; set; }
        bool UsePNGFilter { get; set; }

        PictureFilterIndex FilterIndex { get; set; }
    }
}
