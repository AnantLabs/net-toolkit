using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// \addtogroup math 
    /// @{

    /// <summary>
    /// Represent a degree unit
    /// </summary>
    public sealed class DegreeUnit : GeometricUnit<DegreeUnit>
    {
        public DegreeUnit(double value)
            : base(value)
        {
        }

        public DegreeUnit()
            : base(0)
        {
        }

        public DegreeUnit(RadianUnit value)
            : base(0)
        {
        }

        public override RadianUnit Radian
        {
            get { return ToRadian(); }
            set { Value = value.ToDegree().Value; }
        }

        public override DegreeUnit Degree
        {
            get
            {
                return (DegreeUnit)this.Clone();
            }
            set
            {
                throw new NotSupportedException("The object is immutable!");
            }
        }

        public static implicit operator double(DegreeUnit value)
        {
            return value.Value;
        }

        public static implicit operator DegreeUnit(double value)
        {
            return new DegreeUnit(value);
        }

        #region Self

        public static DegreeUnit operator +(DegreeUnit val1,  DegreeUnit val2)
        {
            return new DegreeUnit(val1.Value + val2.Value);
        }

        public static DegreeUnit operator -(DegreeUnit val1, DegreeUnit val2)
        {
            return new DegreeUnit(val1.Value - val2.Value);
        }

        public static DegreeUnit operator *(DegreeUnit val1, DegreeUnit val2)
        {
            return new DegreeUnit(val1.Value * val2.Value);
        }

        public static DegreeUnit operator /(DegreeUnit val1, DegreeUnit val2)
        {
            return new DegreeUnit(val1.Value / val2.Value);
        }

        public static bool operator <(DegreeUnit val1, DegreeUnit val2)
        {
            return val1.Value < val2.Value;
        }

        public static bool operator >(DegreeUnit val1, DegreeUnit val2)
        {
            return val1.Value > val2.Value;
        }

        public static bool operator <=(DegreeUnit val1, DegreeUnit val2)
        {
            return val1.Value <= val2.Value;
        }

        public static bool operator >=(DegreeUnit val1, DegreeUnit val2)
        {
            return val1.Value >= val2.Value;
        }

        public static bool operator ==(DegreeUnit val1, DegreeUnit val2)
        {
            return val1.Value == val2.Value;
        }

        public static bool operator !=(DegreeUnit val1, DegreeUnit val2)
        {
            return val1.Value != val2.Value;
        }

        #endregion

        #region Radian

        public static DegreeUnit operator +(DegreeUnit deg, RadianUnit rad)
        {
            return new DegreeUnit(deg.Value + rad.Degree.Value);
        }

        public static DegreeUnit operator -(DegreeUnit deg, RadianUnit rad)
        {
            return new DegreeUnit(deg.Value - rad.Degree.Value);
        }

        public static DegreeUnit operator *(DegreeUnit deg, RadianUnit rad)
        {
            return new DegreeUnit(deg.Value * rad.Degree.Value);
        }

        public static DegreeUnit operator /(DegreeUnit deg, RadianUnit rad)
        {
            return new DegreeUnit(deg.Value / rad.Degree.Value);
        }

        //******************************************************

        public static bool operator <(DegreeUnit deg, RadianUnit rad)
        {
            return deg.Value < rad.Degree.Value;
        }

        public static bool operator >(DegreeUnit deg, RadianUnit rad)
        {
            return deg.Value > rad.Degree.Value;
        }

        public static bool operator <=(DegreeUnit deg, RadianUnit rad)
        {
            return deg.Value <= rad.Degree.Value;
        }

        public static bool operator >=(DegreeUnit deg, RadianUnit rad)
        {
            return deg.Value >= rad.Degree.Value;
        }

        public static bool operator ==(DegreeUnit deg, RadianUnit rad)
        {
            return deg.Value == rad.Degree.Value;
        }

        public static bool operator !=(DegreeUnit deg, RadianUnit rad)
        {
            return deg.Value != rad.Degree.Value;
        }

        #endregion

        internal override RadianUnit ToRadian()
        {
            return new RadianUnit(Math.PI * Value / 180d);
        }

        internal override DegreeUnit ToDegree()
        {
            throw new NotSupportedException();
        }

        public override string UnitString
        {
            get { return "Degree"; }
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
