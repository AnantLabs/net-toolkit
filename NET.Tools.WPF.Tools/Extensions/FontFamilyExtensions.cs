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

        public static System.Drawing.FontFamily[] ToDrawingFontFamilies(this FontFamily[] fontFamilies)
        {
            System.Drawing.FontFamily[] result = new System.Drawing.FontFamily[fontFamilies.Length];

            for (int i = 0; i < fontFamilies.Length; i++)
            {
                result[i] = ToDrawingFontFamily(fontFamilies[i]);
            }

            return result;
        }
    }
}
