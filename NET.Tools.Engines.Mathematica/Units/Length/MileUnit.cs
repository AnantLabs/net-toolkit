using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// \addtogroup math 
    /// @{

    /// <summary>
    /// Represent a mile unit (unit of length)
    /// </summary>
    public sealed class MileUnit : LengthUnit<MileUnit>
    {
        public const double MileToKilometers = 1.609344;

        public MileUnit(double value)
            : base(value)
        {
        }

        public MileUnit(MillimeterUnit m)
            : base(0)
        {
            Millimeter = m;
        }

        public MileUnit(MeterUnit m)
            : base(0)
        {
            Meter = m;
        }

        public MileUnit(KilometerUnit m)
            : base(0)
        {
            Kilometer = m;
        }

        public MileUnit(InchUnit i)
            : base(0)
        {
            Inch = i;
        }

        public MileUnit()
            : base(0)
        {
        }

        public override InchUnit Inch
        {
            get { return ToInch(); }
            set { Value = value.ToMile().Value; }
        }

        public override MillimeterUnit Millimeter
        {
            get { return ToMillimeter(); }
            set { Value = value.ToMile().Value; }
        }

        public override MeterUnit Meter
        {
            get { return ToMeter(); }
            set { Value = value.ToMile().Value; }
        }

        public override KilometerUnit Kilometer
        {
            get { return ToKilometer(); }
            set { Value = value.ToMile().Value; }
        }

        public override MileUnit Mile
        {
            get { return (MileUnit)this.Clone(); }
            set { throw new NotSupportedException("The object is immutable!"); }
        }

        public static implicit operator double(MileUnit value)
        {
            return value.Value;
        }

        public static implicit operator MileUnit(double value)
        {
            return new MileUnit(value);
        }

        #region Self

        public static MileUnit operator +(MileUnit val1, MileUnit val2)
        {
            return new MileUnit(val1.Value + val2.Value);
        }

        public static MileUnit operator -(MileUnit val1, MileUnit val2)
        {
            return new MileUnit(val1.Value - val2.Value);
        }

        public static MileUnit operator *(MileUnit val1, MileUnit val2)
        {
            return new MileUnit(val1.Value * val2.Value);
        }

        public static MileUnit operator /(MileUnit val1, MileUnit val2)
        {
            return new MileUnit(val1.Value / val2.Value);
        }

        public static bool operator <(MileUnit val1, MileUnit val2)
        {
            return val1.Value < val2.Value;
        }

        public static bool operator >(MileUnit val1, MileUnit val2)
        {
            return val1.Value > val2.Value;
        }

        public static bool operator <=(MileUnit val1, MileUnit val2)
        {
            return val1.Value <= val2.Value;
        }

        public static bool operator >=(MileUnit val1, MileUnit val2)
        {
            return val1.Value >= val2.Value;
        }

        public static bool operator ==(MileUnit val1, MileUnit val2)
        {
            return val1.Value == val2.Value;
        }

        public static bool operator !=(MileUnit val1, MileUnit val2)
        {
            return val1.Value != val2.Value;
        }

        #endregion

        #region Meter

        public static MileUnit operator +(MileUnit mile, MeterUnit met)
        {
            return new MileUnit(mile.Value + met.Mile.Value);
        }

        public static MileUnit operator -(MileUnit mile, MeterUnit met)
        {
            return new MileUnit(mile.Value - met.Mile.Value);
        }

        public static MileUnit operator *(MileUnit mile, MeterUnit met)
        {
            return new MileUnit(mile.Value * met.Mile.Value);
        }

        public static MileUnit operator /(MileUnit mile, MeterUnit met)
        {
            return new MileUnit(mile.Value / met.Mile.Value);
        }

        public static bool operator <(MileUnit mile, MeterUnit met)
        {
            return mile.Value < met.Mile.Value;
        }

        public static bool operator >(MileUnit mile, MeterUnit met)
        {
            return mile.Value > met.Mile.Value;
        }

        public static bool operator <=(MileUnit mile, MeterUnit met)
        {
            return mile.Value <= met.Mile.Value;
        }

        public static bool operator >=(MileUnit mile, MeterUnit met)
        {
            return mile.Value >= met.Mile.Value;
        }

        public static bool operator ==(MileUnit mile, MeterUnit met)
        {
            return mile.Value == met.Mile.Value;
        }

        public static bool operator !=(MileUnit mile, MeterUnit met)
        {
            return mile.Value != met.Mile.Value;
        }

        #endregion

        #region Millimeter

        public static MileUnit operator +(MileUnit mile, MillimeterUnit mil)
        {
            return new MileUnit(mile.Value + mil.Mile.Value);
        }

        public static MileUnit operator -(MileUnit mile, MillimeterUnit mil)
        {
            return new MileUnit(mile.Value - mil.Mile.Value);
        }

        public static MileUnit operator *(MileUnit mile, MillimeterUnit mil)
        {
            return new MileUnit(mile.Value * mil.Mile.Value);
        }

        public static MileUnit operator /(MileUnit mile, MillimeterUnit mil)
        {
            return new MileUnit(mile.Value / mil.Mile.Value);
        }

        public static bool operator <(MileUnit mile, MillimeterUnit mil)
        {
            return mile.Value < mil.Mile.Value;
        }

        public static bool operator >(MileUnit mile, MillimeterUnit mil)
        {
            return mile.Value > mil.Mile.Value;
        }

        public static bool operator <=(MileUnit mile, MillimeterUnit mil)
        {
            return mile.Value <= mil.Mile.Value;
        }

        public static bool operator >=(MileUnit mile, MillimeterUnit mil)
        {
            return mile.Value >= mil.Mile.Value;
        }

        public static bool operator ==(MileUnit mile, MillimeterUnit mil)
        {
            return mile.Value == mil.Mile.Value;
        }

        public static bool operator !=(MileUnit mile, MillimeterUnit mil)
        {
            return mile.Value != mil.Mile.Value;
        }

        #endregion

        #region Kilometer

        public static MileUnit operator +(MileUnit mile, KilometerUnit kmet)
        {
            return new MileUnit(mile.Value + kmet.Mile.Value);
        }

        public static MileUnit operator -(MileUnit mile, KilometerUnit kmet)
        {
            return new MileUnit(mile.Value - kmet.Mile.Value);
        }

        public static MileUnit operator *(MileUnit mile, KilometerUnit kmet)
        {
            return new MileUnit(mile.Value * kmet.Mile.Value);
        }

        public static MileUnit operator /(MileUnit mile, KilometerUnit kmet)
        {
            return new MileUnit(mile.Value / kmet.Mile.Value);
        }

        public static bool operator <(MileUnit mile, KilometerUnit kmet)
        {
            return mile.Value < kmet.Mile.Value;
        }

        public static bool operator >(MileUnit mile, KilometerUnit kmet)
        {
            return mile.Value > kmet.Mile.Value;
        }

        public static bool operator <=(MileUnit mile, KilometerUnit kmet)
        {
            return mile.Value <= kmet.Mile.Value;
        }

        public static bool operator >=(MileUnit mile, KilometerUnit kmet)
        {
            return mile.Value >= kmet.Mile.Value;
        }

        public static bool operator ==(MileUnit mile, KilometerUnit kmet)
        {
            return mile.Value == kmet.Mile.Value;
        }

        public static bool operator !=(MileUnit mile, KilometerUnit kmet)
        {
            return mile.Value != kmet.Mile.Value;
        }

        #endregion

        #region Inch

        public static MileUnit operator +(MileUnit mile, InchUnit inch)
        {
            return new MileUnit(mile.Value + inch.Mile.Value);
        }

        public static MileUnit operator -(MileUnit mile, InchUnit inch)
        {
            return new MileUnit(mile.Value - inch.Mile.Value);
        }

        public static MileUnit operator *(MileUnit mile, InchUnit inch)
        {
            return new MileUnit(mile.Value * inch.Mile.Value);
        }

        public static MileUnit operator /(MileUnit mile, InchUnit inch)
        {
            return new MileUnit(mile.Value / inch.Mile.Value);
        }

        public static bool operator <(MileUnit mile, InchUnit inch)
        {
            return mile.Value < inch.Mile.Value;
        }

        public static bool operator >(MileUnit mile, InchUnit inch)
        {
            return mile.Value > inch.Mile.Value;
        }

        public static bool operator <=(MileUnit mile, InchUnit inch)
        {
            return mile.Value <= inch.Mile.Value;
        }

        public static bool operator >=(MileUnit mile, InchUnit inch)
        {
            return mile.Value >= inch.Mile.Value;
        }

        public static bool operator ==(MileUnit mile, InchUnit inch)
        {
            return mile.Value == inch.Mile.Value;
        }

        public static bool operator !=(MileUnit mile, InchUnit inch)
        {
            return mile.Value != inch.Mile.Value;
        }

        #endregion

        internal override InchUnit ToInch()
        {
            return ToKilometer().ToInch();
        }

        internal override MeterUnit ToMeter()
        {
            return ToKilometer().ToMeter();
        }

        internal override MillimeterUnit ToMillimeter()
        {
            return ToKilometer().ToMillimeter();
        }

        internal override MileUnit ToMile()
        {
            throw new NotSupportedException();
        }

        internal override KilometerUnit ToKilometer()
        {
            return new KilometerUnit(Value * MileToKilometers);
        }

        public override string UnitString
        {
            get { return "Mile"; }
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
