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
    /// Extensions for Font Family
    /// </summary>
    public static class FontFamilyExtensions
    {
        public static System.Windows.Media.FontFamily ToWPFFontFamily(this FontFamily ff)
        {
            return new System.Windows.Media.FontFamily(ff.Name);
        }
    }

    /// @}
}
