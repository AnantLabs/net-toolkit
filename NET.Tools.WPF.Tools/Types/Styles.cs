using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace NET.Tools
{
    #region Style Classes

    /// <summary>
    /// Defines the stroke style for a shape
    /// </summary>
    public class StrokeStyle
    {
        /// <summary>
        /// Stroke thickness
        /// </summary>
        public double Thickness { get; set; }

        /// <summary>
        /// Stroke color 
        /// </summary>
        public Brush StrokeColor { get; set; }

        /// <summary>
        /// Dash style (can be null)
        /// </summary>
        public DashStyle DashStyle { get; set; }

        /// <summary>
        /// Dash cap style (only usable, if dash-style is set)
        /// </summary>
        public PenLineCap DashCap { get; set; }

        /// <summary>
        /// Start Line Cup
        /// </summary>
        public PenLineCap StartLineCap { get; set; }

        /// <summary>
        /// End Line Cup
        /// </summary>
        public PenLineCap EndLineCap { get; set; }

        /// <summary>
        /// Line Join Point Style
        /// </summary>
        public PenLineJoin LineJoin { get; set; }

        public StrokeStyle()
        {
            Thickness = 1;
            StrokeColor = Brushes.Black;
            DashStyle = null;
            DashCap = PenLineCap.Flat;
            StartLineCap = PenLineCap.Flat;
            EndLineCap = PenLineCap.Flat;
            LineJoin = PenLineJoin.Miter;
        }

        public StrokeStyle(Brush strokeColor) : this()
        {
            StrokeColor = strokeColor;
        }

        public StrokeStyle(Brush strokeColor, double thickness)
            : this()
        {
            Thickness = thickness;
            StrokeColor = strokeColor;
        }

        public StrokeStyle(Brush strokeColor, DashStyle dashStyle)
            : this()
        {
            StrokeColor = strokeColor;
            DashStyle = dashStyle;
        }

        public StrokeStyle(Brush strokeColor, double thickness, DashStyle dashStyle)
            : this()
        {
            Thickness = thickness;
            StrokeColor = strokeColor;
            DashStyle = dashStyle;
        }

        public StrokeStyle(Brush strokeColor, DashStyle dashStyle, PenLineCap dashCap)
            : this()
        {
            StrokeColor = strokeColor;
            DashStyle = dashStyle;
            DashCap = dashCap;
        }

        public StrokeStyle(Brush strokeColor, double thickness, DashStyle dashStyle, PenLineCap dashCap)
            : this()
        {
            StrokeColor = strokeColor;
            DashStyle = dashStyle;
            DashCap = dashCap;
            Thickness = thickness;
        }

        public StrokeStyle(Brush strokeColor, double thickness, PenLineCap startLineCap, PenLineCap endLineCap)
            : this()
        {
            StrokeColor = strokeColor;
            Thickness = thickness;
            StartLineCap = startLineCap;
            EndLineCap = endLineCap;
        }

        public StrokeStyle(Brush strokeColor, double thickness, PenLineCap startLineCap, PenLineCap endLineCap,
                           PenLineJoin lineJoin)
            : this()
        {
            StrokeColor = strokeColor;
            Thickness = thickness;
            StartLineCap = startLineCap;
            EndLineCap = endLineCap;
            LineJoin = lineJoin;
        }

        public StrokeStyle(Brush strokeColor, double thickness, PenLineJoin lineJoin)
            : this()
        {
            StrokeColor = strokeColor;
            Thickness = thickness;
            LineJoin = lineJoin;
        }

        public StrokeStyle(Brush strokeColor, double thickness, PenLineCap startLineCap, PenLineCap endLineCap,
                           PenLineJoin lineJoin, DashStyle dashStyle)
            : this()
        {
            StrokeColor = strokeColor;
            Thickness = thickness;
            StartLineCap = startLineCap;
            EndLineCap = endLineCap;
            LineJoin = lineJoin;
            DashStyle = dashStyle;
        }

        public StrokeStyle(Brush strokeColor, double thickness, PenLineCap startLineCap, PenLineCap endLineCap,
                           PenLineJoin lineJoin, DashStyle dashStyle, PenLineCap dashCap)
            : this()
        {
            StrokeColor = strokeColor;
            Thickness = thickness;
            StartLineCap = startLineCap;
            EndLineCap = endLineCap;
            LineJoin = lineJoin;
            DashStyle = dashStyle;
            DashCap = dashCap;
        }

        protected bool Equals(StrokeStyle other)
        {
            return Thickness.Equals(other.Thickness) && Equals(StrokeColor, other.StrokeColor) && Equals(DashStyle, other.DashStyle) && DashCap.Equals(other.DashCap) && StartLineCap.Equals(other.StartLineCap) && EndLineCap.Equals(other.EndLineCap) && LineJoin.Equals(other.LineJoin);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((StrokeStyle) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Thickness.GetHashCode();
                hashCode = (hashCode*397) ^ (StrokeColor != null ? StrokeColor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (DashStyle != null ? DashStyle.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ DashCap.GetHashCode();
                hashCode = (hashCode*397) ^ StartLineCap.GetHashCode();
                hashCode = (hashCode*397) ^ EndLineCap.GetHashCode();
                hashCode = (hashCode*397) ^ LineJoin.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return string.Format("Thickness: {0}, StrokeColor: {1}, DashStyle: {2}, DashCap: {3}, StartLineCap: {4}, EndLineCap: {5}, LineJoin: {6}", Thickness, StrokeColor, DashStyle, DashCap, StartLineCap, EndLineCap, LineJoin);
        }
    }

    /// <summary>
    /// Defines the fill style of a shape
    /// </summary>
    public class FillStyle
    {
        /// <summary>
        /// Fill color
        /// </summary>
        public Brush FillColor { get; set; }

        public FillStyle()
        {
            FillColor = Brushes.White;
        }

        public FillStyle(Brush fillColor)
        {
            FillColor = fillColor;
        }

        protected bool Equals(FillStyle other)
        {
            return Equals(FillColor, other.FillColor);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FillStyle) obj);
        }

        public override int GetHashCode()
        {
            return (FillColor != null ? FillColor.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return string.Format("FillColor: {0}", FillColor);
        }
    }

    /// <summary>
    /// Defines the text style of a text based "shape"
    /// </summary>
    public class TextStyle
    {
        /// <summary>
        /// Text color
        /// </summary>
        public Brush TextColor { get; set; }
        /// <summary>
        /// Text size
        /// </summary>
        public double FontSize { get; set; }
        /// <summary>
        /// Text is bold?
        /// </summary>
        public bool Bold { get; set; }
        /// <summary>
        /// Text is italic?
        /// </summary>
        public bool Italic { get; set; }
        /// <summary>
        /// Text alignment (only horizontal)
        /// </summary>
        public TextAlignment Alignment { get; set; }

        public TextStyle()
        {
            TextColor = Brushes.Black;
            FontSize = 8;
            Bold = false;
            Italic = false;
            Alignment = TextAlignment.Left;
        }

        public TextStyle(Brush textColor) : this()
        {
            TextColor = textColor;
        }

        public TextStyle(Brush textColor, double fontSize) : this()
        {
            TextColor = textColor;
            FontSize = fontSize;
        }

        public TextStyle(Brush textColor, double fontSize, TextAlignment alignment) : this()
        {
            TextColor = textColor;
            FontSize = fontSize;
            Alignment = alignment;
        }

        public TextStyle(Brush textColor, double fontSize, bool italic, bool bold, TextAlignment alignment)
        {
            TextColor = textColor;
            FontSize = fontSize;
            Italic = italic;
            Bold = bold;
            Alignment = alignment;
        }

        protected bool Equals(TextStyle other)
        {
            return Equals(TextColor, other.TextColor) && FontSize.Equals(other.FontSize) && Bold.Equals(other.Bold) && Italic.Equals(other.Italic) && Alignment.Equals(other.Alignment);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TextStyle) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (TextColor != null ? TextColor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ FontSize.GetHashCode();
                hashCode = (hashCode*397) ^ Bold.GetHashCode();
                hashCode = (hashCode*397) ^ Italic.GetHashCode();
                hashCode = (hashCode*397) ^ Alignment.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return string.Format("TextColor: {0}, FontSize: {1}, Bold: {2}, Italic: {3}, Alignment: {4}", TextColor, FontSize, Bold, Italic, Alignment);
        }
    }

    /// <summary>
    /// Defines a complete shape style. It contains the StrokeStyle and the FillStyle
    /// </summary>
    public class ShapeStyle
    {
        /// <summary>
        /// Stroke style for the shape
        /// </summary>
        public StrokeStyle StrokeStyle { get; set; }
        /// <summary>
        /// Fill style for the shape
        /// </summary>
        public FillStyle FillStyle { get; set; }

        public ShapeStyle()
        {
            StrokeStyle = new StrokeStyle();
            FillStyle = new FillStyle();
        }

        public ShapeStyle(StrokeStyle strokeStyle)
        {
            StrokeStyle = strokeStyle;
        }

        public ShapeStyle(FillStyle fillStyle)
        {
            FillStyle = fillStyle;
        }

        public ShapeStyle(StrokeStyle strokeStyle, FillStyle fillStyle)
        {
            StrokeStyle = strokeStyle;
            FillStyle = fillStyle;
        }

        protected bool Equals(ShapeStyle other)
        {
            return Equals(StrokeStyle, other.StrokeStyle) && Equals(FillStyle, other.FillStyle);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ShapeStyle) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((StrokeStyle != null ? StrokeStyle.GetHashCode() : 0)*397) ^ (FillStyle != null ? FillStyle.GetHashCode() : 0);
            }
        }

        public override string ToString()
        {
            return string.Format("StrokeStyle: {0}, FillStyle: {1}", StrokeStyle, FillStyle);
        }
    }

    #endregion
}
