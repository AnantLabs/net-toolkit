using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace NET.Tools
{
    public static class FontFamilyExtensions
    {
        public static System.Drawing.FontFamily ToDrawingFontFamily(this FontFamily ff)
        {
            return new System.Drawing.FontFamily(ff.Source);
        }
    }
}
