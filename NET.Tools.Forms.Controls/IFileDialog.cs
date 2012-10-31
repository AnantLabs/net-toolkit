using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NET.Tools.Forms
{
    public interface IFileDialog
    {
        DirectoryInfo InitialDirectory { get; set; }
        String FileName { get; set; }
    }
}
