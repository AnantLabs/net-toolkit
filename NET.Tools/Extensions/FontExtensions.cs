using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NET.Tools
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Extensions for Font
    /// </summary>
    public static class FontExtensions
    {
        public static SizeF GetStringSize(this Font f, String str)
        {
            return Graphics.FromImage(new Bitmap(1, 1)).MeasureString(str, f);
        }
    }
    /// @}
}
