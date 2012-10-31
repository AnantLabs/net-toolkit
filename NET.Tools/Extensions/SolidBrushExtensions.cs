using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class SolidBrushExtensions
    {
        public static SolidBrush Darker(this SolidBrush brush, int div)
        {
            if (div < 1)
                throw new ArgumentException("The div-value must be greater than 0!");

            return new SolidBrush(brush.Color.Darker(div));
        }

        public static SolidBrush Darker(this SolidBrush brush)
        {
            return Darker(brush, 2);
        }

        public static SolidBrush Brighter(this SolidBrush brush, int div)
        {
            if (div < 1)
                throw new ArgumentException("The div-value must be greater than 0!");

            return new SolidBrush(brush.Color.Brighter(div));
        }

        public static SolidBrush Brighter(this SolidBrush brush)
        {
            return Brighter(brush, 2);
        }

        public static SolidBrush ToGrayScale(this SolidBrush brush)
        {
            return new SolidBrush(brush.Color.ToGrayScale());
        }

        public static SolidBrush ToRedGrayScale(this SolidBrush brush)
        {
            return new SolidBrush(brush.Color.ToRedGrayScale());
        }

        public static SolidBrush ToGreenGrayScale(this SolidBrush brush)
        {
            return new SolidBrush(brush.Color.ToGreenGrayScale());
        }

        public static SolidBrush ToBlueGrayScale(this SolidBrush brush)
        {
            return new SolidBrush(brush.Color.ToBlueGrayScale());
        }

        public static SolidBrush ToNegative(this SolidBrush brush)
        {
            return new SolidBrush(brush.Color.ToNegative());
        }

        public static SolidBrush AddColor(this SolidBrush brush, Color addColor, float percent)
        {
            return new SolidBrush(brush.Color.AddColor(addColor, percent));
        }

        public static SolidBrush AddColor(this SolidBrush brush, Color addColor)
        {
            return AddColor(brush, addColor, 0.5f);
        }

        public static Color ToColor(this SolidBrush brush)
        {
            return brush.Color;
        }

        public static System.Windows.Media.SolidColorBrush ToWPFSolidBrush(this SolidBrush brush)
        {
            return new System.Windows.Media.SolidColorBrush(brush.Color.ToWPFColor());
        }
    }
    /// @}
}
