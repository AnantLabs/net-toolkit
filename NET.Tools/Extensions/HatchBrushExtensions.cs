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
    public static class HatchBrushExtensions
    {
        public static HatchBrush Darker(this HatchBrush brush, int div)
        {
            if (div < 1)
                throw new ArgumentException("The div-value must be greater than 0!");

            return new HatchBrush(
                brush.HatchStyle,
                brush.ForegroundColor.Darker(div),
                brush.BackgroundColor.Darker(div));
        }

        public static HatchBrush Darker(this HatchBrush brush)
        {
            return Darker(brush, 2);
        }

        public static HatchBrush Brighter(this HatchBrush brush, int div)
        {
            if (div < 1)
                throw new ArgumentException("The div-value must be greater than 0!");

            return new HatchBrush(
                brush.HatchStyle,
                brush.ForegroundColor.Brighter(div),
                brush.BackgroundColor.Brighter(div));
        }

        public static HatchBrush Brighter(this HatchBrush brush)
        {
            return Brighter(brush, 2);
        }

        public static HatchBrush ToGrayScale(this HatchBrush brush)
        {
            return new HatchBrush(
                brush.HatchStyle,
                brush.ForegroundColor.ToGrayScale(),
                brush.BackgroundColor.ToGrayScale());
        }

        public static HatchBrush ToRedGrayScale(this HatchBrush brush)
        {
            return new HatchBrush(
                brush.HatchStyle,
                brush.ForegroundColor.ToRedGrayScale(),
                brush.BackgroundColor.ToRedGrayScale());
        }

        public static HatchBrush ToGreenGrayScale(this HatchBrush brush)
        {
            return new HatchBrush(
                brush.HatchStyle,
                brush.ForegroundColor.ToGreenGrayScale(),
                brush.BackgroundColor.ToGreenGrayScale());
        }

        public static HatchBrush ToBlueGrayScale(this HatchBrush brush)
        {
            return new HatchBrush(
                brush.HatchStyle,
                brush.ForegroundColor.ToBlueGrayScale(),
                brush.BackgroundColor.ToBlueGrayScale());
        }

        public static HatchBrush ToNegative(this HatchBrush brush)
        {
            return new HatchBrush(
                brush.HatchStyle,
                brush.ForegroundColor.ToNegative(),
                brush.BackgroundColor.ToNegative());
        }

        public static HatchBrush AddColor(this HatchBrush brush, Color addColor, float percent)
        {
            return new HatchBrush(
                brush.HatchStyle,
                brush.ForegroundColor.AddColor(addColor, percent),
                brush.BackgroundColor.AddColor(addColor, percent));
        }

        public static HatchBrush AddColor(this HatchBrush brush, Color addColor)
        {
            return AddColor(brush, addColor, 0.5f);
        }
    }
    /// @}
}
