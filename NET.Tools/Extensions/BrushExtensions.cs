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
    public static class BrushExtensions
    {
        /// <summary>
        /// Make the brush darker
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="div">Divisor for darking</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException">
        /// Is thrown if the brush is not:
        /// - SolidBrush
        /// - LinearGradientBrush
        /// - HatchBrush
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Is thrown if the div value is under 1
        /// </exception>
        public static Brush Darker(this Brush brush, int div)
        {
            if (div < 1)
                throw new ArgumentException("The div-value must be greater than 0!");

            if (brush is SolidBrush)
                return (brush as SolidBrush).Darker(div);
            else if (brush is LinearGradientBrush)
                return (brush as LinearGradientBrush).Darker(div);
            else if (brush is HatchBrush)
                return (brush as HatchBrush).Darker(div);
            else
                throw new NotSupportedException("The given brush type (" + brush.GetType().Name + ") is not supported!");
        }

        /// <summary>
        /// Make the brush darker
        /// </summary>
        /// <param name="brush"></param>
        /// <returns></returns>
        public static Brush Darker(this Brush brush)
        {
            return Darker(brush, 2);
        }

        /// <summary>
        /// Make it brighter
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="div">Divisor for brighting</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException">
        /// Is thrown if the brush is not:
        /// - SolidBrush
        /// - LinearGradientBrush
        /// - HatchBrush
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Is thrown if the div value is under 1
        /// </exception>
        public static Brush Brighter(this Brush brush, int div)
        {
            if (div < 1)
                throw new ArgumentException("The div-value must be greater than 0!");

            if (brush is SolidBrush)
                return (brush as SolidBrush).Brighter(div);
            else if (brush is LinearGradientBrush)
                return (brush as LinearGradientBrush).Brighter(div);
            else if (brush is HatchBrush)
                return (brush as HatchBrush).Brighter(div);
            else
                throw new NotSupportedException("The given brush type (" + brush.GetType().Name + ") is not supported!");
        }

        /// <summary>
        /// Make it brighter
        /// </summary>
        /// <param name="brush"></param>
        /// <returns></returns>
        public static Brush Brighter(this Brush brush)
        {
            return Brighter(brush, 2);
        }

        public static Brush ToGrayScale(this Brush brush)
        {
            if (brush is SolidBrush)
                return (brush as SolidBrush).ToGrayScale();
            else if (brush is LinearGradientBrush)
                return (brush as LinearGradientBrush).ToGrayScale();
            else if (brush is HatchBrush)
                return (brush as HatchBrush).ToGrayScale();
            else
                throw new NotSupportedException("The given brush type (" + brush.GetType().Name + ") is not supported!");
        }

        public static Brush ToRedGrayScale(this Brush brush)
        {
            if (brush is SolidBrush)
                return (brush as SolidBrush).ToRedGrayScale();
            else if (brush is LinearGradientBrush)
                return (brush as LinearGradientBrush).ToRedGrayScale();
            else if (brush is HatchBrush)
                return (brush as HatchBrush).ToRedGrayScale();
            else
                throw new NotSupportedException("The given brush type (" + brush.GetType().Name + ") is not supported!");
        }

        public static Brush ToGreenGrayScale(this Brush brush)
        {
            if (brush is SolidBrush)
                return (brush as SolidBrush).ToGreenGrayScale();
            else if (brush is LinearGradientBrush)
                return (brush as LinearGradientBrush).ToGreenGrayScale();
            else if (brush is HatchBrush)
                return (brush as HatchBrush).ToGreenGrayScale();
            else
                throw new NotSupportedException("The given brush type (" + brush.GetType().Name + ") is not supported!");
        }

        public static Brush ToBlueGrayScale(this Brush brush)
        {
            if (brush is SolidBrush)
                return (brush as SolidBrush).ToBlueGrayScale();
            else if (brush is LinearGradientBrush)
                return (brush as LinearGradientBrush).ToBlueGrayScale();
            else if (brush is HatchBrush)
                return (brush as HatchBrush).ToBlueGrayScale();
            else
                throw new NotSupportedException("The given brush type (" + brush.GetType().Name + ") is not supported!");
        }

        public static Brush ToNegative(this Brush brush)
        {
            if (brush is SolidBrush)
                return (brush as SolidBrush).ToNegative();
            else if (brush is LinearGradientBrush)
                return (brush as LinearGradientBrush).ToNegative();
            else if (brush is HatchBrush)
                return (brush as HatchBrush).ToNegative();
            else
                throw new NotSupportedException("The given brush type (" + brush.GetType().Name + ") is not supported!");
        }

        public static Brush AddColor(this Brush brush, Color addColor, float percent)
        {
            if (brush is SolidBrush)
                return (brush as SolidBrush).AddColor(addColor, percent);
            else if (brush is LinearGradientBrush)
                return (brush as LinearGradientBrush).AddColor(addColor, percent);
            else if (brush is HatchBrush)
                return (brush as HatchBrush).AddColor(addColor, percent);
            else
                throw new NotSupportedException("The given brush type (" + brush.GetType().Name + ") is not supported!");
        }

        public static Brush AddColor(this Brush brush, Color addColor)
        {
            return AddColor(brush, addColor, 0.5f);
        }

        /// <summary>
        /// Creates a brush pen
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="width">With of pen</param>
        /// <returns></returns>
        public static Pen ToPen(this Brush brush, int width)
        {
            return new Pen(brush, width);
        }

        /// <summary>
        /// Creates a brush pen
        /// </summary>
        /// <param name="brush"></param>
        /// <returns></returns>
        public static Pen ToPen(this Brush brush)
        {
            return new Pen(brush);
        }
    }
    /// @}
}
