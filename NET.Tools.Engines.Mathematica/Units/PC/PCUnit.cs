using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// \addtogroup math 
    /// @{

    /// <summary>
    /// Represent all pc units
    /// </summary>
    /// <typeparam name="T">see above</typeparam>
    public abstract class PCUnit<T> : Unit<T> where T : Unit<T>
    {
        public PCUnit(double value)
            : base(value)
        {
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
