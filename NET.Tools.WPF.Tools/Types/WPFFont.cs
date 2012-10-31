using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace NET.Tools
{
    /// <summary>
    /// Default font for WPF
    /// </summary>
    public sealed class WPFFont
    {
        public FontFamily FontFamily { get; set; }
        public double FontSize { get; set; }
        public FontWeight FontWeight { get; set; }
        public FontStyle FontStyle { get; set; }
        public FontStretch FontStretch { get; set; }

        public WPFFont(FontFamily ff, double size, FontStyle style, FontWeight weight, FontStretch strech)
        {
            FontFamily = ff;
            FontSize = size;
            FontStyle = style;
            FontWeight = weight;
            FontStretch = strech;
        }

        public WPFFont(FontFamily ff, double size, FontWeight weight, FontStretch strech)
            : this(ff, size, FontStyles.Normal, weight, strech)
        {
        }

        public WPFFont(FontFamily ff, double size, FontStyle style, FontStretch strech)
            : this(ff, size, style, FontWeights.Normal, strech)
        {
        }

        public WPFFont(FontFamily ff, double size, FontStretch strech)
            : this(ff, size, FontStyles.Normal, FontWeights.Normal, strech)
        {
        }

        public WPFFont(FontFamily ff, double size, FontStyle style, FontWeight weight)
            : this(ff, size, style, weight, FontStretches.Normal)
        {
        }

        public WPFFont(FontFamily ff, double size, FontStyle style)
            : this(ff, size, style, FontWeights.Normal)
        {
        }

        public WPFFont(FontFamily ff, double size, FontWeight weight)
            : this(ff, size, FontStyles.Normal, weight)
        {
        }

        public WPFFont(FontFamily ff, double size)
            : this(ff, size, FontStyles.Normal)
        {
        }

        public WPFFont(FontFamily ff)
            : this(ff, 12d)
        {
        }

        /// <summary>
        /// Implicit convertion to font family
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static implicit operator FontFamily(WPFFont f)
        {
            return f.FontFamily;
        }

        /// <summary>
        /// Implicit conversion to font style
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static implicit operator FontStyle(WPFFont f)
        {
            return f.FontStyle;
        }

        /// <summary>
        /// Implicit converion to font weight
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static implicit operator FontWeight(WPFFont f)
        {
            return f.FontWeight;
        }

        /// <summary>
        /// Implicit conversion to font size (double)
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static implicit operator double(WPFFont f)
        {
            return f.FontSize;
        }

        /// <summary>
        /// Implicit converion to font stretch
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static implicit operator FontStretch(WPFFont f)
        {
            return f.FontStretch;
        }
    }
}
