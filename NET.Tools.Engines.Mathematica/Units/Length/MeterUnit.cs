using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// \addtogroup math 
    /// @{

    /// <summary>
    /// Represent a meter (unit of length)
    /// </summary>
    public sealed class MeterUnit : LengthUnit<MeterUnit>
    {
        public MeterUnit(double value)
            : base(value)
        {
        }

        public MeterUnit(MillimeterUnit m)
            : base(0)
        {
            Millimeter = m;
        }

        public MeterUnit(InchUnit i)
            : base(0)
        {
        }

        public MeterUnit(KilometerUnit m)
            : base(0)
        {
            Kilometer = m;
        }

        public MeterUnit(MileUnit m)
            : base(0)
        {
            Mile = m;
        }

        public MeterUnit()
            : base(0)
        {
        }

        public override MillimeterUnit Millimeter
        {
            get { return ToMillimeter(); }
            set { Value = value.ToMeter().Value; }
        }

        public override InchUnit Inch
        {
            get { return ToInch(); }
            set { Value = value.ToMeter().Value; }
        }

        public override KilometerUnit Kilometer
        {
            get { return ToKilometer(); }
            set { Value = ToMeter().Value; }
        }

        public override MileUnit Mile
        {
            get { return ToMile(); }
            set { Value = value.ToMeter().Value; }
        }

        public override MeterUnit Meter
        {
            get { return (MeterUnit)this.Clone(); }
            set { throw new NotSupportedException("The object is immutable!"); }
        }

        public static implicit operator double(MeterUnit value)
        {
            return value.Value;
        }

        public static implicit operator MeterUnit(double value)
        {
            return new MeterUnit(value);
        }

        #region Self

        public static MeterUnit operator +(MeterUnit val1, MeterUnit val2)
        {
            return new MeterUnit(val1.Value + val2.Value);
        }

        public static MeterUnit operator -(MeterUnit val1, MeterUnit val2)
        {
            return new MeterUnit(val1.Value - val2.Value);
        }

        public static MeterUnit operator *(MeterUnit val1, MeterUnit val2)
        {
            return new MeterUnit(val1.Value * val2.Value);
        }

        public static MeterUnit operator /(MeterUnit val1, MeterUnit val2)
        {
            return new MeterUnit(val1.Value / val2.Value);
        }

        public static bool operator <(MeterUnit val1, MeterUnit val2)
        {
            return val1.Value < val2.Value;
        }

        public static bool operator >(MeterUnit val1, MeterUnit val2)
        {
            return val1.Value > val2.Value;
        }

        public static bool operator <=(MeterUnit val1, MeterUnit val2)
        {
            return val1.Value <= val2.Value;
        }

        public static bool operator >=(MeterUnit val1, MeterUnit val2)
        {
            return val1.Value >= val2.Value;
        }

        public static bool operator ==(MeterUnit val1, MeterUnit val2)
        {
            return val1.Value == val2.Value;
        }

        public static bool operator !=(MeterUnit val1, MeterUnit val2)
        {
            return val1.Value != val2.Value;
        }

        #endregion

        #region Millimeter

        public static MeterUnit operator +(MeterUnit met, MillimeterUnit mil)
        {
            return new MeterUnit(met.Value + mil.Meter.Value);
        }

        public static MeterUnit operator -(MeterUnit met, MillimeterUnit mil)
        {
            return new MeterUnit(met.Value - mil.Meter.Value);
        }

        public static MeterUnit operator *(MeterUnit met, MillimeterUnit mil)
        {
            return new MeterUnit(met.Value * mil.Meter.Value);
        }

        public static MeterUnit operator /(MeterUnit met, MillimeterUnit mil)
        {
            return new MeterUnit(met.Value / mil.Meter.Value);
        }

        public static bool operator <(MeterUnit met, MillimeterUnit mil)
        {
            return met.Millimeter.Value < mil.Value;
        }

        public static bool operator >(MeterUnit met, MillimeterUnit mil)
        {
            return met.Millimeter.Value > mil.Value;
        }

        public static bool operator <=(MeterUnit met, MillimeterUnit mil)
        {
            return met.Millimeter.Value <= mil.Value;
        }

        public static bool operator >=(MeterUnit met, MillimeterUnit mil)
        {
            return met.Millimeter.Value >= mil.Value;
        }

        public static bool operator ==(MeterUnit met, MillimeterUnit mil)
        {
            return met.Millimeter.Value == mil.Value;
        }

        public static bool operator !=(MeterUnit met, MillimeterUnit mil)
        {
            return met.Millimeter.Value != mil.Value;
        }

        #endregion

        #region Inch

        public static MeterUnit operator +(MeterUnit met, InchUnit inch)
        {
            return new MeterUnit(met.Value + inch.Meter.Value);
        }

        public static MeterUnit operator -(MeterUnit met, InchUnit inch)
        {
            return new MeterUnit(met.Value - inch.Meter.Value);
        }

        public static MeterUnit operator *(MeterUnit met, InchUnit inch)
        {
            return new MeterUnit(met.Value * inch.Meter.Value);
        }

        public static MeterUnit operator /(MeterUnit met, InchUnit inch)
        {
            return new MeterUnit(met.Value / inch.Meter.Value);
        }

        public static bool operator <(MeterUnit met, InchUnit inch)
        {
            return met.Inch.Value < inch.Value;
        }

        public static bool operator >(MeterUnit met, InchUnit inch)
        {
            return met.Inch.Value > inch.Value;
        }

        public static bool operator <=(MeterUnit met, InchUnit inch)
        {
            return met.Inch.Value <= inch.Value;
        }

        public static bool operator >=(MeterUnit met, InchUnit inch)
        {
            return met.Inch.Value >= inch.Value;
        }

        public static bool operator ==(MeterUnit met, InchUnit inch)
        {
            return met.Inch.Value == inch.Value;
        }

        public static bool operator !=(MeterUnit met, InchUnit inch)
        {
            return met.Inch.Value != inch.Value;
        }

        #endregion

        #region Kilometer

        public static MeterUnit operator +(MeterUnit met, KilometerUnit kmet)
        {
            return new MeterUnit(met.Value + kmet.Meter.Value);
        }

        public static MeterUnit operator -(MeterUnit met, KilometerUnit kmet)
        {
            return new MeterUnit(met.Value - kmet.Meter.Value);
        }

        public static MeterUnit operator *(MeterUnit met, KilometerUnit kmet)
        {
            return new MeterUnit(met.Value * kmet.Meter.Value);
        }

        public static MeterUnit operator /(MeterUnit met, KilometerUnit kmet)
        {
            return new MeterUnit(met.Value / kmet.Meter.Value);
        }        

        public static bool operator <(MeterUnit met, KilometerUnit kmet)
        {
            return met.Kilometer.Value < kmet.Value;
        }

        public static bool operator >(MeterUnit met, KilometerUnit kmet)
        {
            return met.Kilometer.Value > kmet.Value;
        }

        public static bool operator <=(MeterUnit met, KilometerUnit kmet)
        {
            return met.Kilometer.Value <= kmet.Value;
        }

        public static bool operator >=(MeterUnit met, KilometerUnit kmet)
        {
            return met.Kilometer.Value >= kmet.Value;
        }

        public static bool operator ==(MeterUnit met, KilometerUnit kmet)
        {
            return met.Kilometer.Value == kmet.Value;
        }

        public static bool operator !=(MeterUnit met, KilometerUnit kmet)
        {
            return met.Kilometer.Value != kmet.Value;
        }

        #endregion

        #region Mile

        public static MeterUnit operator +(MeterUnit met, MileUnit mile)
        {
            return new MeterUnit(met.Value + mile.Meter.Value);
        }

        public static MeterUnit operator -(MeterUnit met, MileUnit mile)
        {
            return new MeterUnit(met.Value - mile.Meter.Value);
        }

        public static MeterUnit operator *(MeterUnit met, MileUnit mile)
        {
            return new MeterUnit(met.Value * mile.Meter.Value);
        }

        public static MeterUnit operator /(MeterUnit met, MileUnit mile)
        {
            return new MeterUnit(met.Value / mile.Meter.Value);
        }

        public static bool operator <(MeterUnit met, MileUnit mile)
        {
            return met.Mile.Value < mile.Value;
        }

        public static bool operator >(MeterUnit met, MileUnit mile)
        {
            return met.Mile.Value > mile.Value;
        }

        public static bool operator <=(MeterUnit met, MileUnit mile)
        {
            return met.Mile.Value <= mile.Value;
        }

        public static bool operator >=(MeterUnit met, MileUnit mile)
        {
            return met.Mile.Value >= mile.Value;
        }

        public static bool operator ==(MeterUnit met, MileUnit mile)
        {
            return met.Mile.Value == mile.Value;
        }

        public static bool operator !=(MeterUnit met, MileUnit mile)
        {
            return met.Mile.Value != mile.Value;
        }

        #endregion

        internal override MillimeterUnit ToMillimeter()
        {
            return new MillimeterUnit(Value * 1000);
        }

        internal override InchUnit ToInch()
        {
            return ToMillimeter().ToInch();
        }

        internal override MeterUnit ToMeter()
        {
            throw new NotSupportedException();
        }

        internal override KilometerUnit ToKilometer()
        {
            return new KilometerUnit(Value / 1000);
        }

        internal override MileUnit ToMile()
        {
            return ToKilometer().ToMile();
        }

        public override string UnitString
        {
            get { return "m"; }
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
