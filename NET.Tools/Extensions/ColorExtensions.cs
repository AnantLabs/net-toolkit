using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace NET.Tools
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Extensions for Colors
    /// </summary>
    public static class ColorExtensions
    {
        public static Color ToGrayScale(this Color color)
        {
            byte r = color.R, b = color.B, g = color.G;
            Algorithm.Math.Color.ToGrayScale(ref r, ref g, ref b);
            return Color.FromArgb(r, g, b);
        }

        public static Color ToRedGrayScale(this Color color)
        {
            byte r = color.R, b = color.B, g = color.G;
            Algorithm.Math.Color.ToRedGrayScale(ref r, ref g, ref b);
            return Color.FromArgb(r, g, b);
        }

        public static Color ToGreenGrayScale(this Color color)
        {
            byte r = color.R, b = color.B, g = color.G;
            Algorithm.Math.Color.ToGreenGrayScale(ref r, ref g, ref b);
            return Color.FromArgb(r, g, b);
        }

        public static Color ToBlueGrayScale(this Color color)
        {
            byte r = color.R, b = color.B, g = color.G;
            Algorithm.Math.Color.ToBlueGrayScale(ref r, ref g, ref b);
            return Color.FromArgb(r, g, b);
        }

        public static Color ToNegative(this Color color)
        {
            byte r = color.R, b = color.B, g = color.G;
            Algorithm.Math.Color.ToNegative(ref r, ref g, ref b);
            return Color.FromArgb(r, g, b);
        }

        public static Color AddColor(this Color color, Color addColor, float percent)
        {
            byte r = color.R, b = color.B, g = color.G;
            Algorithm.Math.Color.AddColor(ref r, ref g, ref b, 
                addColor.R, addColor.G, addColor.B, percent);
            return Color.FromArgb(r, g, b);
        }

        public static Color AddColor(this Color color, Color addColor)
        {
            return AddColor(color, addColor, 0.5f);
        }

        public static Color Darker(this Color color, int div)
        {
            byte r = color.R, b = color.B, g = color.G;
            Algorithm.Math.Color.Darker(ref r, ref g, ref b, div);
            return Color.FromArgb(r, g, b);
        }

        public static Color Darker(this Color color)
        {
            return Darker(color, 2);
        }

        public static Color Brighter(this Color color, int div)
        {
            byte r = color.R, b = color.B, g = color.G;
            Algorithm.Math.Color.Brighter(ref r, ref g, ref b, div);
            return Color.FromArgb(r, g, b);
        }

        public static Color Brighter(this Color color)
        {
            return Brighter(color, 2);
        }

        public static Color ToTransparentFromGrayScale(this Color color, Color? newRGBColor)
        {
            return Color.FromArgb(
                color.ToGrayScale().R,
                newRGBColor.GetValueOrDefault(color));
        }

        public static Color ToTransparentFromGrayScale(this Color color)
        {
            return ToTransparentFromGrayScale(color, null);
        }

        public static Pen ToPen(this Color color, float width)
        {
            return new Pen(color, width);
        }

        public static Pen ToPen(this Color color)
        {
            return new Pen(color);
        }

        public static Brush ToSolidBrush(this Color color)
        {
            return new SolidBrush(color);
        }

        public static Brush ToGradientBrush(this Color color, Color c, Point p1, Point p2)
        {
            return new LinearGradientBrush(p1, p2, color, c);
        }

        public static Brush ToGradientBrush(this Color color, Color c)
        {
            return ToGradientBrush(color, c, new Point(0, 0), new Point(1, 1));
        }

        public static Brush ToHatchBrush(this Color color, Color back, HatchStyle hatch)
        {
            return new HatchBrush(hatch, color, back);
        }

        public static Brush ToHatchBrush(this Color color, HatchStyle hatch)
        {
            return new HatchBrush(hatch, color);
        }

        public static Brush ToHatchBrush(this Color color)
        {
            return ToHatchBrush(color, HatchStyle.Percent50);
        }

        public static Brush ToHatchBrush(this Color color, Color back)
        {
            return ToHatchBrush(color, back, HatchStyle.Percent50);
        }

        public static int ToBGR(this Color c)
        {
            if (c != Color.Empty)
                return (Convert.ToInt32(c.B) << 16) + (Convert.ToInt32(c.G) << 8) + c.R;
            return 0;
        }

        public static System.Windows.Media.Color ToWPFColor(this Color color)
        {
            return System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        
    }
    /// @}
}
