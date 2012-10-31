using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// \addtogroup math 
    /// @{

    /// <summary>
    /// Represent a kilometer unit (unit of length)
    /// </summary>
    public sealed class KilometerUnit : LengthUnit<KilometerUnit>
    {
        public KilometerUnit(double value)
            : base(value)
        {
        }

        public KilometerUnit(MillimeterUnit m)
            : base(0)
        {
            Millimeter = m;
        }

        public KilometerUnit(MeterUnit m)
            : base(0)
        {
            Meter = m;
        }

        public KilometerUnit(InchUnit i)
            : base(0)
        {
            Inch = i;
        }

        public KilometerUnit(MileUnit m)
            : base(0)
        {
            Mile = m;
        }

        public KilometerUnit()
            : base(0)
        {
        }

        public override InchUnit Inch
        {
            get { return ToInch(); }
            set { Value = value.ToKilometer().Value; }
        }

        public override MeterUnit Meter
        {
            get { return ToMeter(); }
            set { Value = value.ToKilometer().Value; }
        }

        public override MillimeterUnit Millimeter
        {
            get { return ToMillimeter(); }
            set { Value = value.ToKilometer().Value; }
        }

        public override MileUnit Mile
        {
            get { return ToMile(); }
            set { Value = value.ToKilometer().Value; }
        }

        public override KilometerUnit Kilometer
        {
            get { return (KilometerUnit)this.Clone(); }
            set { throw new NotSupportedException("The object is immutable!"); }
        }

        public static implicit operator double(KilometerUnit value)
        {
            return value.Value;
        }

        public static implicit operator KilometerUnit(double value)
        {
            return new KilometerUnit(value);
        }

        #region Self

        public static KilometerUnit operator +(KilometerUnit val1, KilometerUnit val2)
        {
            return new KilometerUnit(val1.Value + val2.Value);
        }

        public static KilometerUnit operator -(KilometerUnit val1, KilometerUnit val2)
        {
            return new KilometerUnit(val1.Value - val2.Value);
        }

        public static KilometerUnit operator *(KilometerUnit val1, KilometerUnit val2)
        {
            return new KilometerUnit(val1.Value * val2.Value);
        }

        public static KilometerUnit operator /(KilometerUnit val1, KilometerUnit val2)
        {
            return new KilometerUnit(val1.Value / val2.Value);
        }

        public static bool operator <(KilometerUnit val1, KilometerUnit val2)
        {
            return val1.Value < val2.Value;
        }

        public static bool operator >(KilometerUnit val1, KilometerUnit val2)
        {
            return val1.Value > val2.Value;
        }

        public static bool operator <=(KilometerUnit val1, KilometerUnit val2)
        {
            return val1.Value <= val2.Value;
        }

        public static bool operator >=(KilometerUnit val1, KilometerUnit val2)
        {
            return val1.Value >= val2.Value;
        }

        public static bool operator ==(KilometerUnit val1, KilometerUnit val2)
        {
            return val1.Value == val2.Value;
        }

        public static bool operator !=(KilometerUnit val1, KilometerUnit val2)
        {
            return val1.Value != val2.Value;
        }

        #endregion

        #region Meter

        public static KilometerUnit operator +(KilometerUnit kmet, MeterUnit met)
        {
            return new KilometerUnit(kmet.Value + met.Kilometer.Value);
        }

        public static KilometerUnit operator -(KilometerUnit kmet, MeterUnit met)
        {
            return new KilometerUnit(kmet.Value - met.Kilometer.Value);
        }

        public static KilometerUnit operator *(KilometerUnit kmet, MeterUnit met)
        {
            return new KilometerUnit(kmet.Value * met.Kilometer.Value);
        }

        public static KilometerUnit operator /(KilometerUnit kmet, MeterUnit met)
        {
            return new KilometerUnit(kmet.Value / met.Kilometer.Value);
        }

        public static bool operator <(KilometerUnit kmet, MeterUnit met)
        {
            return kmet.Value < met.Kilometer.Value;
        }

        public static bool operator >(KilometerUnit kmet, MeterUnit met)
        {
            return kmet.Value > met.Kilometer.Value;
        }

        public static bool operator <=(KilometerUnit kmet, MeterUnit met)
        {
            return kmet.Value <= met.Kilometer.Value;
        }

        public static bool operator >=(KilometerUnit kmet, MeterUnit met)
        {
            return kmet.Value >= met.Kilometer.Value;
        }

        public static bool operator ==(KilometerUnit kmet, MeterUnit met)
        {
            return kmet.Value == met.Kilometer.Value;
        }

        public static bool operator !=(KilometerUnit kmet, MeterUnit met)
        {
            return kmet.Value != met.Kilometer.Value;
        }

        #endregion

        #region Millimeter

        public static KilometerUnit operator +(KilometerUnit kmet, MillimeterUnit mil)
        {
            return new KilometerUnit(kmet.Value + mil.Kilometer.Value);
        }

        public static KilometerUnit operator -(KilometerUnit kmet, MillimeterUnit mil)
        {
            return new KilometerUnit(kmet.Value - mil.Kilometer.Value);
        }

        public static KilometerUnit operator *(KilometerUnit kmet, MillimeterUnit mil)
        {
            return new KilometerUnit(kmet.Value * mil.Kilometer.Value);
        }

        public static KilometerUnit operator /(KilometerUnit kmet, MillimeterUnit mil)
        {
            return new KilometerUnit(kmet.Value / mil.Kilometer.Value);
        }

        public static bool operator <(KilometerUnit kmet, MillimeterUnit mil)
        {
            return kmet.Value < mil.Kilometer.Value;
        }

        public static bool operator >(KilometerUnit kmet, MillimeterUnit mil)
        {
            return kmet.Value > mil.Kilometer.Value;
        }

        public static bool operator <=(KilometerUnit kmet, MillimeterUnit mil)
        {
            return kmet.Value <= mil.Kilometer.Value;
        }

        public static bool operator >=(KilometerUnit kmet, MillimeterUnit mil)
        {
            return kmet.Value >= mil.Kilometer.Value;
        }

        public static bool operator ==(KilometerUnit kmet, MillimeterUnit mil)
        {
            return kmet.Value == mil.Kilometer.Value;
        }

        public static bool operator !=(KilometerUnit kmet, MillimeterUnit mil)
        {
            return kmet.Value != mil.Kilometer.Value;
        }

        #endregion

        #region Inch

        public static KilometerUnit operator +(KilometerUnit kmet, InchUnit inch)
        {
            return new KilometerUnit(kmet.Value + inch.Kilometer.Value);
        }

        public static KilometerUnit operator -(KilometerUnit kmet, InchUnit inch)
        {
            return new KilometerUnit(kmet.Value - inch.Kilometer.Value);
        }

        public static KilometerUnit operator *(KilometerUnit kmet, InchUnit inch)
        {
            return new KilometerUnit(kmet.Value * inch.Kilometer.Value);
        }

        public static KilometerUnit operator /(KilometerUnit kmet, InchUnit inch)
        {
            return new KilometerUnit(kmet.Value / inch.Kilometer.Value);
        }

        public static bool operator <(KilometerUnit kmet, InchUnit inch)
        {
            return kmet.Value < inch.Kilometer.Value;
        }

        public static bool operator >(KilometerUnit kmet, InchUnit inch)
        {
            return kmet.Value > inch.Kilometer.Value;
        }

        public static bool operator <=(KilometerUnit kmet, InchUnit inch)
        {
            return kmet.Value <= inch.Kilometer.Value;
        }

        public static bool operator >=(KilometerUnit kmet, InchUnit inch)
        {
            return kmet.Value >= inch.Kilometer.Value;
        }

        public static bool operator ==(KilometerUnit kmet, InchUnit inch)
        {
            return kmet.Value == inch.Kilometer.Value;
        }

        public static bool operator !=(KilometerUnit kmet, InchUnit inch)
        {
            return kmet.Value != inch.Kilometer.Value;
        }

        #endregion

        #region Meter

        public static KilometerUnit operator +(KilometerUnit kmet, MileUnit mile)
        {
            return new KilometerUnit(kmet.Value + mile.Kilometer.Value);
        }

        public static KilometerUnit operator -(KilometerUnit kmet, MileUnit mile)
        {
            return new KilometerUnit(kmet.Value - mile.Kilometer.Value);
        }

        public static KilometerUnit operator *(KilometerUnit kmet, MileUnit mile)
        {
            return new KilometerUnit(kmet.Value * mile.Kilometer.Value);
        }

        public static KilometerUnit operator /(KilometerUnit kmet, MileUnit mile)
        {
            return new KilometerUnit(kmet.Value / mile.Kilometer.Value);
        }

        public static bool operator <(KilometerUnit kmet, MileUnit mile)
        {
            return kmet.Value < mile.Kilometer.Value;
        }

        public static bool operator >(KilometerUnit kmet, MileUnit mile)
        {
            return kmet.Value > mile.Kilometer.Value;
        }

        public static bool operator <=(KilometerUnit kmet, MileUnit mile)
        {
            return kmet.Value <= mile.Kilometer.Value;
        }

        public static bool operator >=(KilometerUnit kmet, MileUnit mile)
        {
            return kmet.Value >= mile.Kilometer.Value;
        }

        public static bool operator ==(KilometerUnit kmet, MileUnit mile)
        {
            return kmet.Value == mile.Kilometer.Value;
        }

        public static bool operator !=(KilometerUnit kmet, MileUnit mile)
        {
            return kmet.Value != mile.Kilometer.Value;
        }

        #endregion

        internal override InchUnit ToInch()
        {
            return ToMeter().ToInch();
        }

        internal override MeterUnit ToMeter()
        {
            return new MeterUnit(Value * 1000d);
        }

        internal override MillimeterUnit ToMillimeter()
        {
            return ToMeter().ToMillimeter();
        }

        internal override MileUnit ToMile()
        {
            return new MileUnit(Value / MileUnit.MileToKilometers);
        }

        internal override KilometerUnit ToKilometer()
        {
            throw new NotSupportedException();
        }

        public override string UnitString
        {
            get { return "km"; }
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
