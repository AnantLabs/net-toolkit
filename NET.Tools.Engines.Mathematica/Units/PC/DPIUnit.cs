using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// \addtogroup math 
    /// @{

    /// <summary>
    /// Represent a dpi unit
    /// </summary>
    public sealed class DPIUnit : PCUnit<DPIUnit>
    {
        public DPIUnit(double value)
            : base(value)
        {
        }

        public DPIUnit()
            : base(0)
        {
        }

        /// <summary>
        /// Gets the inches of one pixel
        /// </summary>
        public InchUnit InchesPerPixel
        {
            get { return new InchUnit(1d / Value); }
        }

        /// <summary>
        /// Gets the millimeters of one pixel
        /// </summary>
        public MillimeterUnit MillimetersPerPixel
        {
            get { return InchesPerPixel.Millimeter; }
        }

        public override string UnitString
        {
            get { return "DPI"; }
        }

        public static implicit operator double(DPIUnit value)
        {
            return value.Value;
        }

        public static implicit operator DPIUnit(double value)
        {
            return new DPIUnit(value);
        }

        #region Self

        public static DPIUnit operator +(DPIUnit val1, DPIUnit val2)
        {
            return new DPIUnit(val1.Value + val2.Value);
        }

        public static DPIUnit operator -(DPIUnit val1, DPIUnit val2)
        {
            return new DPIUnit(val1.Value - val2.Value);
        }

        public static DPIUnit operator *(DPIUnit val1, DPIUnit val2)
        {
            return new DPIUnit(val1.Value * val2.Value);
        }

        public static DPIUnit operator /(DPIUnit val1, DPIUnit val2)
        {
            return new DPIUnit(val1.Value / val2.Value);
        }

        public static bool operator <(DPIUnit val1, DPIUnit val2)
        {
            return val1.Value < val2.Value;
        }

        public static bool operator >(DPIUnit val1, DPIUnit val2)
        {
            return val1.Value > val2.Value;
        }

        public static bool operator <=(DPIUnit val1, DPIUnit val2)
        {
            return val1.Value <= val2.Value;
        }

        public static bool operator >=(DPIUnit val1, DPIUnit val2)
        {
            return val1.Value >= val2.Value;
        }

        public static bool operator ==(DPIUnit val1, DPIUnit val2)
        {
            return val1.Value == val2.Value;
        }

        public static bool operator !=(DPIUnit val1, DPIUnit val2)
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
