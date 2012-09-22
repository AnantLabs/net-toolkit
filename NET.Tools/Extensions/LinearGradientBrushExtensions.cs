using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class LinearGradientBrushExtensions
    {
        public static LinearGradientBrush Darker(this LinearGradientBrush brush, int div)
        {
            if (div < 1)
                throw new ArgumentException("The div-value must be greater than 0!");

            return new LinearGradientBrush(
                brush.Rectangle.Location,
                new PointF(brush.Rectangle.Right, brush.Rectangle.Bottom),
                brush.LinearColors[0].Darker(div),
                brush.LinearColors[1].Darker(div));
        }

        public static LinearGradientBrush Darker(this LinearGradientBrush brush)
        {
            return Darker(brush, 2);
        }

        public static LinearGradientBrush Brighter(this LinearGradientBrush brush, int div)
        {
            if (div < 1)
                throw new ArgumentException("The div-value must be greater than 0!");

            return new LinearGradientBrush(
                brush.Rectangle.Location,
                brush.Rectangle.GetBottomRight(),
                brush.LinearColors[0].Brighter(div),
                brush.LinearColors[1].Brighter(div));
        }

        public static LinearGradientBrush Brighter(this LinearGradientBrush brush)
        {
            return Brighter(brush, 2);
        }

        public static LinearGradientBrush ToGrayScale(this LinearGradientBrush brush)
        {
            return new LinearGradientBrush(
                brush.Rectangle.Location,
                brush.Rectangle.GetBottomRight(),
                brush.LinearColors[0].ToGrayScale(),
                brush.LinearColors[1].ToGrayScale());
        }

        public static LinearGradientBrush ToRedGrayScale(this LinearGradientBrush brush)
        {
            return new LinearGradientBrush(
                brush.Rectangle.Location,
                brush.Rectangle.GetBottomRight(),
                brush.LinearColors[0].ToRedGrayScale(),
                brush.LinearColors[1].ToRedGrayScale());
        }

        public static LinearGradientBrush ToGreenGrayScale(this LinearGradientBrush brush)
        {
            return new LinearGradientBrush(
                brush.Rectangle.Location,
                brush.Rectangle.GetBottomRight(),
                brush.LinearColors[0].ToGreenGrayScale(),
                brush.LinearColors[1].ToGreenGrayScale());
        }

        public static LinearGradientBrush ToBlueGrayScale(this LinearGradientBrush brush)
        {
            return new LinearGradientBrush(
                brush.Rectangle.Location,
                brush.Rectangle.GetBottomRight(),
                brush.LinearColors[0].ToBlueGrayScale(),
                brush.LinearColors[1].ToBlueGrayScale());
        }

        public static LinearGradientBrush ToNegative(this LinearGradientBrush brush)
        {
            return new LinearGradientBrush(
                brush.Rectangle.Location,
                brush.Rectangle.GetBottomRight(),
                brush.LinearColors[0].ToNegative(),
                brush.LinearColors[1].ToNegative());
        }

        public static LinearGradientBrush AddColor(this LinearGradientBrush brush, Color addColor, float percent)
        {
            return new LinearGradientBrush(
                brush.Rectangle.Location,
                brush.Rectangle.GetBottomRight(),
                brush.LinearColors[0].AddColor(addColor, percent),
                brush.LinearColors[1].AddColor(addColor, percent));
        }

        public static LinearGradientBrush AddColor(this LinearGradientBrush brush, Color addColor)
        {
            return AddColor(brush, addColor, 0.5f);
        }

        public static System.Windows.Media.LinearGradientBrush ToWPFLinearGradientBrush(this LinearGradientBrush brush)
        {
            return new System.Windows.Media.LinearGradientBrush(
                brush.LinearColors[0].ToWPFColor(), brush.LinearColors[1].ToWPFColor(),
                brush.Rectangle.Location.ToWPFPoint(), brush.Rectangle.GetBottomRight().ToWPFPoint());
        }
    }
    /// @}
}
