using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// \defgroup math Mathematica
    /// \addtogroup math 
    /// @{

    /// <summary>
    /// Represent a physical unit
    /// 
    /// All physical units are immutable objects. The value cannot be set and all
    /// = operations are copies
    /// </summary>
    /// <typeparam name="T">Must be a implementation of this master class</typeparam>
    public abstract class Unit<T> : ICloneable where T : Unit<T>
    {
        /// <summary>
        /// Value of this unit
        /// </summary>
        public double Value { get; protected set; }

        public Unit(double value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the string for this unit, e. g. "m" for Meters or "pixels"
        /// </summary>
        public abstract String UnitString { get; }

        public override string ToString()
        {
            return this.GetType().Name + ": " + Value.ToString("0.00") + " " + UnitString;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (!(obj is Unit<T>))
                return false;
            else if (Object.ReferenceEquals(obj, this))
                return true;

            Unit<T> myObj = obj as Unit<T>;

            return 
                Value.Equals(myObj.Value);
        }

        public override int GetHashCode()
        {
            return
                Value.GetHashCode();
        }

        #region ICloneable Member

        public object Clone()
        {
            return (T)Activator.CreateInstance(typeof(T), Value);
        }

        #endregion
    }

    /// @}
}
