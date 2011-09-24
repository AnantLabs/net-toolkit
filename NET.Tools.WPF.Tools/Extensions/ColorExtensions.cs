using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace NET.Tools
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Extensions for WPF Color
    /// </summary>
    public static class ColorExtensions
    {
        public static System.Drawing.Color ToDrawingColor(this Color color)
        {
            return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        public static Color Brighter(this Color color, int div)
        {
            byte r = color.R, b = color.B, g = color.G;
            Algorithm.Math.Color.Brighter(ref r, ref g, ref b, div);
            return Color.FromArgb(color.A, r, g, b);
        }

        public static Color Brighter(this Color c)
        {
            return Brighter(c, 2);
        }

        public static Color Darker(this Color color, int div)
        {
            byte r = color.R, b = color.B, g = color.G;
            Algorithm.Math.Color.Darker(ref r, ref g, ref b, div);
            return Color.FromArgb(color.A, r, g, b);
        }

        public static Color Darker(this Color c)
        {
            return Darker(c, 2);
        }

        public static Color ToGrayScale(this Color color)
        {
            byte r = color.R, b = color.B, g = color.G;
            Algorithm.Math.Color.ToGrayScale(ref r, ref g, ref b);
            return Color.FromArgb(color.A, r, g, b);
        }

        public static Color ToRedGrayScale(this Color color)
        {
            byte r = color.R, b = color.B, g = color.G;
            Algorithm.Math.Color.ToRedGrayScale(ref r, ref g, ref b);
            return Color.FromArgb(color.A, r, g, b);
        }

        public static Color ToGreenGrayScale(this Color color)
        {
            byte r = color.R, b = color.B, g = color.G;
            Algorithm.Math.Color.ToGreenGrayScale(ref r, ref g, ref b);
            return Color.FromArgb(color.A, r, g, b);
        }

        public static Color ToBlueGrayScale(this Color color)
        {
            byte r = color.R, b = color.B, g = color.G;
            Algorithm.Math.Color.ToBlueGrayScale(ref r, ref g, ref b);
            return Color.FromArgb(color.A, r, g, b);
        }

        public static Color ToNegative(this Color color)
        {
            byte r = color.R, b = color.B, g = color.G;
            Algorithm.Math.Color.ToNegative(ref r, ref g, ref b);
            return Color.FromArgb(color.A, r, g, b);
        }

        public static Color AddColor(this Color color, Color addColor, float percent)
        {
            byte r = color.R, b = color.B, g = color.G;
            Algorithm.Math.Color.AddColor(ref r, ref g, ref b,
                addColor.R, addColor.G, addColor.B, percent);
            return Color.FromArgb(color.A, r, g, b);
        }

        public static Color AddColor(this Color color, Color addColor)
        {
            return AddColor(color, addColor, 0.5f);
        }

        public static Brush ToSolidBrush(this Color color)
        {
            return new SolidColorBrush(color);
        }
    }
    /// @}
}
