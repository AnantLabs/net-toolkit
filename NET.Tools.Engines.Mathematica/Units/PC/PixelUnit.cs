using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// \addtogroup math 
    /// @{

    /// <summary>
    /// Represent a pixel unit
    /// </summary>
    public sealed class PixelUnit : PCUnit<PixelUnit>
    {
        public PixelUnit(double value)
            : base(value)
        {
        }

        public PixelUnit()
            : base(0)
        {
        }

        public override string UnitString
        {
            get { return "Pixels"; }
        }

        /// <summary>
        /// Compute the inch length of all pixels in dependency of the dpi
        /// </summary>
        /// <param name="dpi">DPI</param>
        /// <returns></returns>
        public InchUnit ToInchLength(DPIUnit dpi)
        {
            return new InchUnit(dpi.InchesPerPixel.Value * Value);
        }

        /// <summary>
        /// Compute the millimeter length of all pixels in dependency of the dpi
        /// </summary>
        /// <param name="dpi">DPI</param>
        /// <returns></returns>
        public MillimeterUnit ToMillimeterLength(DPIUnit dpi)
        {
            return new MillimeterUnit(dpi.MillimetersPerPixel.Value * Value);
        }

        public static implicit operator double(PixelUnit value)
        {
            return value.Value;
        }

        public static implicit operator PixelUnit(double value)
        {
            return new PixelUnit(value);
        }

        #region Self

        public static PixelUnit operator +(PixelUnit val1, PixelUnit val2)
        {
            return new PixelUnit(val1.Value + val2.Value);
        }

        public static PixelUnit operator -(PixelUnit val1, PixelUnit val2)
        {
            return new PixelUnit(val1.Value - val2.Value);
        }

        public static PixelUnit operator *(PixelUnit val1, PixelUnit val2)
        {
            return new PixelUnit(val1.Value * val2.Value);
        }

        public static PixelUnit operator /(PixelUnit val1, PixelUnit val2)
        {
            return new PixelUnit(val1.Value / val2.Value);
        }

        public static bool operator <(PixelUnit val1, PixelUnit val2)
        {
            return val1.Value < val2.Value;
        }

        public static bool operator >(PixelUnit val1, PixelUnit val2)
        {
            return val1.Value > val2.Value;
        }

        public static bool operator <=(PixelUnit val1, PixelUnit val2)
        {
            return val1.Value <= val2.Value;
        }

        public static bool operator >=(PixelUnit val1, PixelUnit val2)
        {
            return val1.Value >= val2.Value;
        }

        public static bool operator ==(PixelUnit val1, PixelUnit val2)
        {
            return val1.Value == val2.Value;
        }

        public static bool operator !=(PixelUnit val1, PixelUnit val2)
        {
            return val1.Value != val2.Value;
        }

        #endregion

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    /// @}
}
