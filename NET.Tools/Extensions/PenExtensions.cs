using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class PenExtensions
    {
        public static Pen Darker(this Pen pen, int div)
        {
            return pen.Convert(pen.Color.Darker(div));
        }

        public static Pen Darker(this Pen pen)
        {
            return Darker(pen, 2);
        }

        public static Pen Brighter(this Pen pen, int div)
        {
            return pen.Convert(pen.Color.Brighter(div));
        }

        public static Pen Brighter(this Pen pen)
        {
            return Brighter(pen, 2);
        }

        public static Pen ToGrayScale(this Pen pen)
        {
            return pen.Convert(pen.Color.ToGrayScale());
        }

        public static Pen ToRedGrayScale(this Pen pen)
        {
            return pen.Convert(pen.Color.ToRedGrayScale());
        }

        public static Pen ToGreenGrayScale(this Pen pen)
        {
            return pen.Convert(pen.Color.ToGreenGrayScale());
        }

        public static Pen ToBlueGrayScale(this Pen pen)
        {
            return pen.Convert(pen.Color.ToBlueGrayScale());
        }

        public static Pen ToNegative(this Pen pen)
        {
            return pen.Convert(pen.Color.ToNegative());
        }

        public static Pen AddColor(this Pen pen, Color addColor, float percent)
        {
            return pen.Convert(pen.Color.AddColor(addColor, percent));
        }

        public static Pen AddColor(this Pen pen, Color addColor)
        {
            return AddColor(pen, addColor, 0.5f);
        }

        public static Pen Convert(this Pen pen, DashStyle dash)
        {
            return new Pen(pen.Color, pen.Width) {DashStyle = dash};
        }

        public static Pen Convert(this Pen pen, Color color)
        {
            return new Pen(color, pen.Width);
        }

        public static Pen Convert(this Pen pen, Brush brush)
        {
            return new Pen(brush, pen.Width);
        }

        public static Pen Convert(this Pen pen, int width)
        {
            return new Pen(pen.Color, width);
        }
    }
    /// @}
}
