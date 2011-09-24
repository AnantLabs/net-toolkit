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
        public static Pen Convert(this Pen pen, DashStyle dash)
        {
            Pen p = new Pen(pen.Color, pen.Width);
            p.DashStyle = dash;

            return p;
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
