using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// \addtogroup math 
    /// @{

    ///<summary>Represent a class for radian units</summary>
    public sealed class RadianUnit : GeometricUnit<RadianUnit>
    {
        public RadianUnit(double value)
            : base(value)
        {
        }

        public RadianUnit()
            : base(0)
        {
        }

        public RadianUnit(DegreeUnit value)
            : base(0)
        {
        }

        public override DegreeUnit Degree
        {
            get { return ToDegree(); }
            set { Value = value.Radian.Value; }
        }

        public override RadianUnit Radian
        {
            get
            {
                return (RadianUnit)this.Clone();
            }
            set
            {
                throw new NotSupportedException("The object is immutable!");
            }
        }

        public static implicit operator double(RadianUnit value)
        {
            return value.Value;
        }

        public static implicit operator RadianUnit(double value)
        {
            return new RadianUnit(value);
        }

        #region Self

        public static RadianUnit operator +(RadianUnit val1, RadianUnit val2)
        {
            return new RadianUnit(val1.Value + val2.Value);
        }

        public static RadianUnit operator -(RadianUnit val1, RadianUnit val2)
        {
            return new RadianUnit(val1.Value - val2.Value);
        }

        public static RadianUnit operator *(RadianUnit val1, RadianUnit val2)
        {
            return new RadianUnit(val1.Value * val2.Value);
        }

        public static RadianUnit operator /(RadianUnit val1, RadianUnit val2)
        {
            return new RadianUnit(val1.Value / val2.Value);
        }

        public static bool operator <(RadianUnit val1, RadianUnit val2)
        {
            return val1.Value < val2.Value;
        }

        public static bool operator >(RadianUnit val1, RadianUnit val2)
        {
            return val1.Value > val2.Value;
        }

        public static bool operator <=(RadianUnit val1, RadianUnit val2)
        {
            return val1.Value <= val2.Value;
        }

        public static bool operator >=(RadianUnit val1, RadianUnit val2)
        {
            return val1.Value >= val2.Value;
        }

        public static bool operator ==(RadianUnit val1, RadianUnit val2)
        {
            return val1.Value == val2.Value;
        }

        public static bool operator !=(RadianUnit val1, RadianUnit val2)
        {
            return val1.Value != val2.Value;
        }

        #endregion

        #region Degree

        public static RadianUnit operator +(RadianUnit rad, DegreeUnit deg)
        {
            return new RadianUnit(rad.Value + deg.Radian.Value);
        }

        public static RadianUnit operator -(RadianUnit rad, DegreeUnit deg)
        {
            return new RadianUnit(rad.Value - deg.Radian.Value);
        }

        public static RadianUnit operator *(RadianUnit rad, DegreeUnit deg)
        {
            return new RadianUnit(rad.Value * deg.Radian.Value);
        }

        public static RadianUnit operator /(RadianUnit rad, DegreeUnit deg)
        {
            return new RadianUnit(rad.Value / deg.Radian.Value);
        }

        public static bool operator <(RadianUnit rad, DegreeUnit deg)
        {
            return rad.Degree.Value < deg.Value;
        }

        public static bool operator >(RadianUnit rad, DegreeUnit deg)
        {
            return rad.Degree.Value > deg.Value;
        }

        public static bool operator <=(RadianUnit rad, DegreeUnit deg)
        {
            return rad.Degree.Value <= deg.Value;
        }

        public static bool operator >=(RadianUnit rad, DegreeUnit deg)
        {
            return rad.Degree.Value >= deg.Value;
        }

        public static bool operator ==(RadianUnit rad, DegreeUnit deg)
        {
            return rad.Degree.Value == deg.Value;
        }

        public static bool operator !=(RadianUnit rad, DegreeUnit deg)
        {
            return rad.Degree.Value != deg.Value;
        }

        #endregion

        internal override DegreeUnit ToDegree()
        {
            return new DegreeUnit(180d * Value / Math.PI);
        }

        internal override RadianUnit ToRadian()
        {
            throw new NotSupportedException();
        }

        public override string UnitString
        {
            get { return "Radian"; }
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
