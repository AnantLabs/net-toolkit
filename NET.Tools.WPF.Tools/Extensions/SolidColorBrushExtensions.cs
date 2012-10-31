using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class SolidColorBrushExtensions
    {
        public static Color ToColor(this SolidColorBrush brush)
        {
            return brush.Color;
        }

        public static System.Drawing.SolidBrush ToDrawingSolidBrush(this SolidColorBrush brush)
        {
            return new System.Drawing.SolidBrush(brush.Color.ToDrawingColor());
        }

        public static SolidColorBrush Brighter(this SolidColorBrush solidColorBrush, int div)
        {
            return new SolidColorBrush(solidColorBrush.Color.Brighter(div));
        }

        public static SolidColorBrush Brighter(this SolidColorBrush c)
        {
            return Brighter(c, 2);
        }

        public static SolidColorBrush Darker(this SolidColorBrush solidColorBrush, int div)
        {
            return new SolidColorBrush(solidColorBrush.Color.Darker(div));
        }

        public static SolidColorBrush Darker(this SolidColorBrush c)
        {
            return Darker(c, 2);
        }

        public static SolidColorBrush ToGrayScale(this SolidColorBrush solidColorBrush)
        {
            return new SolidColorBrush(solidColorBrush.Color.ToGrayScale());
        }

        public static SolidColorBrush ToRedGrayScale(this SolidColorBrush solidColorBrush)
        {
            return new SolidColorBrush(solidColorBrush.Color.ToRedGrayScale());
        }

        public static SolidColorBrush ToGreenGrayScale(this SolidColorBrush solidColorBrush)
        {
            return new SolidColorBrush(solidColorBrush.Color.ToGreenGrayScale());
        }

        public static SolidColorBrush ToBlueGrayScale(this SolidColorBrush solidColorBrush)
        {
            return new SolidColorBrush(solidColorBrush.Color.ToBlueGrayScale());
        }

        public static SolidColorBrush ToNegative(this SolidColorBrush solidColorBrush)
        {
            return new SolidColorBrush(solidColorBrush.Color.ToNegative());
        }

        public static SolidColorBrush AddColor(this SolidColorBrush solidColorBrush, Color addColor, float percent)
        {
            return new SolidColorBrush(solidColorBrush.Color.AddColor(addColor, percent));
        }

        public static SolidColorBrush AddColor(this SolidColorBrush solidColorBrush, Color addColor)
        {
            return AddColor(solidColorBrush, addColor, 0.5f);
        }
    }
    /// @}
}
