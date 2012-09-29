using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class ControlExtensions
    {
        public static WPFFont GetFont(this Control element)
        {
            return new WPFFont(element.FontFamily, element.FontSize, element.FontStyle, element.FontWeight, element.FontStretch);
        }

        public static void SetFont(this Control element, WPFFont font)
        {
            element.FontFamily = font;
            element.FontSize = font;
            element.FontStretch = font;
            element.FontStyle = font;
            element.FontWeight = font;
        }

        public static WPFFont GetFont(this TextBlock element)
        {
            return new WPFFont(element.FontFamily, element.FontSize, element.FontStyle, element.FontWeight, element.FontStretch);
        }

        public static void SetFont(this TextBlock element, WPFFont font)
        {
            element.FontFamily = font;
            element.FontSize = font;
            element.FontStretch = font;
            element.FontStyle = font;
            element.FontWeight = font;
        }
    }
    /// @}
}
