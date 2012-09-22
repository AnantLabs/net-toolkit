using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// \addtogroup math 
    /// @{

    /// <summary>
    /// Represent a millimeter (unit of length)
    /// </summary>
    public sealed class MillimeterUnit : LengthUnit<MillimeterUnit>
    {
        public MillimeterUnit(double value)
            : base(value)
        {
        }

        public MillimeterUnit(MeterUnit m)
            : base(0)
        {
        }

        public MillimeterUnit(InchUnit i)
            : base(0)
        {
        }

        public MillimeterUnit(KilometerUnit m)
            : base(0)
        {
            Kilometer = m;
        }

        public MillimeterUnit(MileUnit m)
            : base(0)
        {
            Mile = m;
        }

        public MillimeterUnit()
            : base(0)
        {
        }

        /// <summary>
        /// Compute the pixel count on the destination in dependency of the ppi
        /// </summary>
        /// <param name="dpi">DPI</param>
        /// <returns>The pixel count on destination</returns>
        public PixelUnit ToPixelCount(DPIUnit dpi)
        {
            return new PixelUnit(Value / dpi.MillimetersPerPixel.Value);
        }

        public override MeterUnit Meter
        {
            get { return ToMeter(); }
            set { Value = value.ToMillimeter().Value; }
        }

        public override InchUnit Inch
        {
            get { return ToInch(); }
            set { Value = value.ToMillimeter().Value; }
        }

        public override KilometerUnit Kilometer
        {
            get
            {
                return ToKilometer();
            }
            set
            {
                Value = value.ToMillimeter().Value;
            }
        }

        public override MileUnit Mile
        {
            get
            {
                return ToMile();
            }
            set
            {
                Value = value.ToMillimeter().Value;
            }
        }

        public override MillimeterUnit Millimeter
        {
            get { return (MillimeterUnit)this.Clone(); }
            set { throw new NotSupportedException("The object is immutable!"); }
        }

        public static implicit operator double(MillimeterUnit value)
        {
            return value.Value;
        }

        public static implicit operator MillimeterUnit(double value)
        {
            return new MillimeterUnit(value);
        }

        #region Self

        public static MillimeterUnit operator +(MillimeterUnit val1, MillimeterUnit val2)
        {
            return new MillimeterUnit(val1.Value + val2.Value);
        }

        public static MillimeterUnit operator -(MillimeterUnit val1, MillimeterUnit val2)
        {
            return new MillimeterUnit(val1.Value - val2.Value);
        }

        public static MillimeterUnit operator *(MillimeterUnit val1, MillimeterUnit val2)
        {
            return new MillimeterUnit(val1.Value * val2.Value);
        }

        public static MillimeterUnit operator /(MillimeterUnit val1, MillimeterUnit val2)
        {
            return new MillimeterUnit(val1.Value / val2.Value);
        }

        public static bool operator <(MillimeterUnit val1, MillimeterUnit val2)
        {
            return val1.Value < val2.Value;
        }

        public static bool operator >(MillimeterUnit val1, MillimeterUnit val2)
        {
            return val1.Value > val2.Value;
        }

        public static bool operator <=(MillimeterUnit val1, MillimeterUnit val2)
        {
            return val1.Value <= val2.Value;
        }

        public static bool operator >=(MillimeterUnit val1, MillimeterUnit val2)
        {
            return val1.Value >= val2.Value;
        }

        public static bool operator ==(MillimeterUnit val1, MillimeterUnit val2)
        {
            return val1.Value == val2.Value;
        }

        public static bool operator !=(MillimeterUnit val1, MillimeterUnit val2)
        {
            return val1.Value != val2.Value;
        }

        #endregion

        #region Meter

        public static MillimeterUnit operator +(MillimeterUnit mil, MeterUnit met)
        {
            return new MillimeterUnit(mil.Value + met.Millimeter.Value);
        }

        public static MillimeterUnit operator -(MillimeterUnit mil, MeterUnit met)
        {
            return new MillimeterUnit(mil.Value - met.Millimeter.Value);
        }

        public static MillimeterUnit operator *(MillimeterUnit mil, MeterUnit met)
        {
            return new MillimeterUnit(mil.Value * met.Millimeter.Value);
        }

        public static MillimeterUnit operator /(MillimeterUnit mil, MeterUnit met)
        {
            return new MillimeterUnit(mil.Value / met.Millimeter.Value);
        }

        public static bool operator <(MillimeterUnit mil, MeterUnit met)
        {
            return mil.Value < met.Millimeter.Value;
        }

        public static bool operator >(MillimeterUnit mil, MeterUnit met)
        {
            return mil.Value > met.Millimeter.Value;
        }

        public static bool operator <=(MillimeterUnit mil, MeterUnit met)
        {
            return mil.Value <= met.Millimeter.Value;
        }

        public static bool operator >=(MillimeterUnit mil, MeterUnit met)
        {
            return mil.Value >= met.Millimeter.Value;
        }

        public static bool operator ==(MillimeterUnit mil, MeterUnit met)
        {
            return mil.Value == met.Millimeter.Value;
        }

        public static bool operator !=(MillimeterUnit mil, MeterUnit met)
        {
            return mil.Value != met.Millimeter.Value;
        }

        #endregion

        #region Inch

        public static MillimeterUnit operator +(MillimeterUnit mil, InchUnit inch)
        {
            return new MillimeterUnit(mil.Value + inch.Millimeter.Value);
        }

        public static MillimeterUnit operator -(MillimeterUnit mil, InchUnit inch)
        {
            return new MillimeterUnit(mil.Value - inch.Millimeter.Value);
        }

        public static MillimeterUnit operator *(MillimeterUnit mil, InchUnit inch)
        {
            return new MillimeterUnit(mil.Value * inch.Millimeter.Value);
        }

        public static MillimeterUnit operator /(MillimeterUnit mil, InchUnit inch)
        {
            return new MillimeterUnit(mil.Value / inch.Millimeter.Value);
        }

        public static bool operator <(MillimeterUnit mil, InchUnit inch)
        {
            return mil.Value < inch.Millimeter.Value;
        }

        public static bool operator >(MillimeterUnit mil, InchUnit inch)
        {
            return mil.Value > inch.Millimeter.Value;
        }

        public static bool operator <=(MillimeterUnit mil, InchUnit inch)
        {
            return mil.Value <= inch.Millimeter.Value;
        }

        public static bool operator >=(MillimeterUnit mil, InchUnit inch)
        {
            return mil.Value >= inch.Millimeter.Value;
        }

        public static bool operator ==(MillimeterUnit mil, InchUnit inch)
        {
            return mil.Value == inch.Millimeter.Value;
        }

        public static bool operator !=(MillimeterUnit mil, InchUnit inch)
        {
            return mil.Value != inch.Millimeter.Value;
        }

        #endregion

        #region Kilometer

        public static MillimeterUnit operator +(MillimeterUnit mil, KilometerUnit kmet)
        {
            return new MillimeterUnit(mil.Value + kmet.Millimeter.Value);
        }

        public static MillimeterUnit operator -(MillimeterUnit mil, KilometerUnit kmet)
        {
            return new MillimeterUnit(mil.Value - kmet.Millimeter.Value);
        }

        public static MillimeterUnit operator *(MillimeterUnit mil, KilometerUnit kmet)
        {
            return new MillimeterUnit(mil.Value * kmet.Millimeter.Value);
        }

        public static MillimeterUnit operator /(MillimeterUnit mil, KilometerUnit kmet)
        {
            return new MillimeterUnit(mil.Value / kmet.Millimeter.Value);
        }

        public static bool operator <(MillimeterUnit mil, KilometerUnit kmet)
        {
            return mil.Value < kmet.Millimeter.Value;
        }

        public static bool operator >(MillimeterUnit mil, KilometerUnit kmet)
        {
            return mil.Value > kmet.Millimeter.Value;
        }

        public static bool operator <=(MillimeterUnit mil, KilometerUnit kmet)
        {
            return mil.Value <= kmet.Millimeter.Value;
        }

        public static bool operator >=(MillimeterUnit mil, KilometerUnit kmet)
        {
            return mil.Value >= kmet.Millimeter.Value;
        }

        public static bool operator ==(MillimeterUnit mil, KilometerUnit kmet)
        {
            return mil.Value == kmet.Millimeter.Value;
        }

        public static bool operator !=(MillimeterUnit mil, KilometerUnit kmet)
        {
            return mil.Value != kmet.Millimeter.Value;
        }

        #endregion

        #region Mile

        public static MillimeterUnit operator +(MillimeterUnit mil, MileUnit mile)
        {
            return new MillimeterUnit(mil.Value + mile.Millimeter.Value);
        }

        public static MillimeterUnit operator -(MillimeterUnit mil, MileUnit mile)
        {
            return new MillimeterUnit(mil.Value - mile.Millimeter.Value);
        }

        public static MillimeterUnit operator *(MillimeterUnit mil, MileUnit mile)
        {
            return new MillimeterUnit(mil.Value * mile.Millimeter.Value);
        }

        public static MillimeterUnit operator /(MillimeterUnit mil, MileUnit mile)
        {
            return new MillimeterUnit(mil.Value / mile.Millimeter.Value);
        }

        public static bool operator <(MillimeterUnit mil, MileUnit mile)
        {
            return mil.Value < mile.Millimeter.Value;
        }

        public static bool operator >(MillimeterUnit mil, MileUnit mile)
        {
            return mil.Value > mile.Millimeter.Value;
        }

        public static bool operator <=(MillimeterUnit mil, MileUnit mile)
        {
            return mil.Value <= mile.Millimeter.Value;
        }

        public static bool operator >=(MillimeterUnit mil, MileUnit mile)
        {
            return mil.Value >= mile.Millimeter.Value;
        }

        public static bool operator ==(MillimeterUnit mil, MileUnit mile)
        {
            return mil.Value == mile.Millimeter.Value;
        }

        public static bool operator !=(MillimeterUnit mil, MileUnit mile)
        {
            return mil.Value != mile.Millimeter.Value;
        }

        #endregion

        internal override MeterUnit ToMeter()
        {
            return new MeterUnit(Value / 1000);
        }

        internal override InchUnit ToInch()
        {
            return new InchUnit(Value / 25.4);
        }

        internal override MillimeterUnit ToMillimeter()
        {
            throw new NotSupportedException();
        }

        internal override KilometerUnit ToKilometer()
        {
            return ToMeter().ToKilometer();
        }

        internal override MileUnit ToMile()
        {
            return ToMeter().ToMile();
        }

        public override string UnitString
        {
            get { return "mm"; }
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
