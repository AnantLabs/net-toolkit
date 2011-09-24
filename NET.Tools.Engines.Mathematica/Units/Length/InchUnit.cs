using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// \addtogroup math 
    /// @{

    /// <summary>
    /// Represent an inch (unit of length)
    /// </summary>
    public sealed class InchUnit : LengthUnit<InchUnit>
    {
        public const double InchToMilimeters = 25.4;

        public InchUnit(double value)
            : base(value)
        {
        }

        public InchUnit(MillimeterUnit m)
            : base(0)
        {
            Millimeter = m;
        }

        public InchUnit(MeterUnit m)
            : base(0)
        {
            Meter = m;
        }

        public InchUnit(KilometerUnit m)
            : base(0)
        {
            Kilometer = m;
        }

        public InchUnit(MileUnit m)
            : base(0)
        {
            Mile = m;
        }

        public InchUnit()
            : base(0)
        {
        }

        /// <summary>
        /// Compute the pixel count on the destination in dependency of the dpi
        /// </summary>
        /// <param name="dpi">DPI</param>
        /// <returns>The pixel count on destination</returns>
        public PixelUnit ToPixelCount(DPIUnit dpi)
        {
            return new PixelUnit(Value / dpi.InchesPerPixel.Value);
        }

        public override MillimeterUnit Millimeter
        {
            get
            {
                return ToMillimeter();
            }
            set
            {
                Value = value.ToInch().Value;
            }
        }

        public override MeterUnit Meter
        {
            get
            {
                return ToMeter();
            }
            set
            {
                Value = value.ToInch().Value;
            }
        }

        public override KilometerUnit Kilometer
        {
            get { return ToKilometer(); }
            set { Value = value.ToInch().Value; }
        }

        public override MileUnit Mile
        {
            get { return ToMile(); }
            set { Value = value.ToInch().Value; }
        }

        public override InchUnit Inch
        {
            get { return (InchUnit)this.Clone(); }
            set { throw new NotSupportedException("The object is immutable!"); }
        }

        public static implicit operator double(InchUnit value)
        {
            return value.Value;
        }

        public static implicit operator InchUnit(double value)
        {
            return new InchUnit(value);
        }

        #region Self

        public static InchUnit operator +(InchUnit val1, InchUnit val2)
        {
            return new InchUnit(val1.Value + val2.Value);
        }

        public static InchUnit operator -(InchUnit val1, InchUnit val2)
        {
            return new InchUnit(val1.Value - val2.Value);
        }

        public static InchUnit operator *(InchUnit val1, InchUnit val2)
        {
            return new InchUnit(val1.Value * val2.Value);
        }

        public static InchUnit operator /(InchUnit val1, InchUnit val2)
        {
            return new InchUnit(val1.Value / val2.Value);
        }

        public static bool operator <(InchUnit val1, InchUnit val2)
        {
            return val1.Value < val2.Value;
        }

        public static bool operator >(InchUnit val1, InchUnit val2)
        {
            return val1.Value > val2.Value;
        }

        public static bool operator <=(InchUnit val1, InchUnit val2)
        {
            return val1.Value <= val2.Value;
        }

        public static bool operator >=(InchUnit val1, InchUnit val2)
        {
            return val1.Value >= val2.Value;
        }

        public static bool operator ==(InchUnit val1, InchUnit val2)
        {
            return val1.Value == val2.Value;
        }

        public static bool operator !=(InchUnit val1, InchUnit val2)
        {
            return val1.Value != val2.Value;
        }

        #endregion

        #region Millimeter

        public static InchUnit operator +(InchUnit inch, MillimeterUnit mil)
        {
            return new InchUnit(inch.Value + mil.Inch.Value);
        }

        public static InchUnit operator -(InchUnit inch, MillimeterUnit mil)
        {
            return new InchUnit(inch.Value - mil.Inch.Value);
        }

        public static InchUnit operator *(InchUnit inch, MillimeterUnit mil)
        {
            return new InchUnit(inch.Value * mil.Inch.Value);
        }

        public static InchUnit operator /(InchUnit inch, MillimeterUnit mil)
        {
            return new InchUnit(inch.Value / mil.Inch.Value);
        }

        public static bool operator <(InchUnit inch, MillimeterUnit mil)
        {
            return inch.Millimeter.Value < mil.Value;
        }

        public static bool operator >(InchUnit inch, MillimeterUnit mil)
        {
            return inch.Millimeter.Value > mil.Value;
        }

        public static bool operator <=(InchUnit inch, MillimeterUnit mil)
        {
            return inch.Millimeter.Value <= mil.Value;
        }

        public static bool operator >=(InchUnit inch, MillimeterUnit mil)
        {
            return inch.Millimeter.Value >= mil.Value;
        }

        public static bool operator ==(InchUnit inch, MillimeterUnit mil)
        {
            return inch.Millimeter.Value == mil.Value;
        }

        public static bool operator !=(InchUnit inch, MillimeterUnit mil)
        {
            return inch.Millimeter.Value != mil.Value;
        }

        #endregion

        #region Meter

        public static InchUnit operator +(InchUnit inch, MeterUnit met)
        {
            return new InchUnit(inch.Value + met.Inch.Value);
        }

        public static InchUnit operator -(InchUnit inch, MeterUnit met)
        {
            return new InchUnit(inch.Value - met.Inch.Value);
        }

        public static InchUnit operator *(InchUnit inch, MeterUnit met)
        {
            return new InchUnit(inch.Value * met.Inch.Value);
        }

        public static InchUnit operator /(InchUnit inch, MeterUnit met)
        {
            return new InchUnit(inch.Value / met.Inch.Value);
        }

        public static bool operator <(InchUnit inch, MeterUnit met)
        {
            return inch.Meter.Value < met.Value;
        }

        public static bool operator >(InchUnit inch, MeterUnit met)
        {
            return inch.Meter.Value > met.Value;
        }

        public static bool operator <=(InchUnit inch, MeterUnit met)
        {
            return inch.Meter.Value <= met.Value;
        }

        public static bool operator >=(InchUnit inch, MeterUnit met)
        {
            return inch.Meter.Value >= met.Value;
        }

        public static bool operator ==(InchUnit inch, MeterUnit met)
        {
            return inch.Meter.Value == met.Value;
        }

        public static bool operator !=(InchUnit inch, MeterUnit met)
        {
            return inch.Meter.Value != met.Value;
        }

        #endregion

        #region Kilometer

        public static InchUnit operator +(InchUnit inch, KilometerUnit met)
        {
            return new InchUnit(inch.Value + met.Inch.Value);
        }

        public static InchUnit operator -(InchUnit inch, KilometerUnit met)
        {
            return new InchUnit(inch.Value - met.Inch.Value);
        }

        public static InchUnit operator *(InchUnit inch, KilometerUnit met)
        {
            return new InchUnit(inch.Value * met.Inch.Value);
        }

        public static InchUnit operator /(InchUnit inch, KilometerUnit met)
        {
            return new InchUnit(inch.Value / met.Inch.Value);
        }

        public static bool operator <(InchUnit inch, KilometerUnit met)
        {
            return inch.Meter.Value < met.Value;
        }

        public static bool operator >(InchUnit inch, KilometerUnit met)
        {
            return inch.Meter.Value > met.Value;
        }

        public static bool operator <=(InchUnit inch, KilometerUnit met)
        {
            return inch.Meter.Value <= met.Value;
        }

        public static bool operator >=(InchUnit inch, KilometerUnit met)
        {
            return inch.Meter.Value >= met.Value;
        }

        public static bool operator ==(InchUnit inch, KilometerUnit met)
        {
            return inch.Meter.Value == met.Value;
        }

        public static bool operator !=(InchUnit inch, KilometerUnit met)
        {
            return inch.Meter.Value != met.Value;
        }

        #endregion

        #region Mile

        public static InchUnit operator +(InchUnit inch, MileUnit mile)
        {
            return new InchUnit(inch.Value + mile.Inch.Value);
        }

        public static InchUnit operator -(InchUnit inch, MileUnit mile)
        {
            return new InchUnit(inch.Value - mile.Inch.Value);
        }

        public static InchUnit operator *(InchUnit inch, MileUnit mile)
        {
            return new InchUnit(inch.Value * mile.Inch.Value);
        }

        public static InchUnit operator /(InchUnit inch, MileUnit mile)
        {
            return new InchUnit(inch.Value / mile.Inch.Value);
        }

        public static bool operator <(InchUnit inch, MileUnit mile)
        {
            return inch.Mile.Value < mile.Value;
        }

        public static bool operator >(InchUnit inch, MileUnit mile)
        {
            return inch.Mile.Value > mile.Value;
        }

        public static bool operator <=(InchUnit inch, MileUnit mile)
        {
            return inch.Mile.Value <= mile.Value;
        }

        public static bool operator >=(InchUnit inch, MileUnit mile)
        {
            return inch.Mile.Value >= mile.Value;
        }

        public static bool operator ==(InchUnit inch, MileUnit mile)
        {
            return inch.Mile.Value == mile.Value;
        }

        public static bool operator !=(InchUnit inch, MileUnit mile)
        {
            return inch.Mile.Value != mile.Value;
        }

        #endregion

        internal override MillimeterUnit ToMillimeter()
        {
            return new MillimeterUnit(Value * InchToMilimeters);
        }

        internal override MeterUnit ToMeter()
        {
            return ToMillimeter().ToMeter();
        }

        internal override InchUnit ToInch()
        {
            throw new NotSupportedException();
        }

        internal override KilometerUnit ToKilometer()
        {
            return ToMillimeter().ToKilometer();
        }

        internal override MileUnit ToMile()
        {
            return ToMillimeter().ToMile();
        }

        public override string UnitString
        {
            get { return "\""; }
        }

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
