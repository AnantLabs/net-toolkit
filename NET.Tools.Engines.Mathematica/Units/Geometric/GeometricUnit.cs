using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// \addtogroup math 
    /// @{

    /// <summary>
    /// Present all geometric units
    /// </summary>
    /// <typeparam name="T">see above</typeparam>
    public abstract class GeometricUnit<T> : Unit<T> where T : Unit<T>
    {
        public GeometricUnit(double value)
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

        /// <summary>
        /// Gets or sets degree value
        /// </summary>
        public abstract DegreeUnit Degree { get; set; }
        /// <summary>
        /// Gets or sets radian value
        /// </summary>
        public abstract RadianUnit Radian { get; set; }

        internal abstract DegreeUnit ToDegree();
        internal abstract RadianUnit ToRadian();
    }

    /// @}
}
