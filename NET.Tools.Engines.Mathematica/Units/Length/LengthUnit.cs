using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// \addtogroup math 
    /// @{

    /// <summary>
    /// Represent a unit of length
    /// 
    /// Computing of values:
    /// - Meter:
    ///   - To Kilometer
    ///   - To Millimeter
    /// - Kilometer:
    ///   - To Mile
    ///   - To Meter
    /// - Millimeter:
    ///   - To Meter
    ///   - To Inch
    /// - Mile:
    ///   - To Kilometer
    /// - Inch:
    ///   - To Millimeter
    /// </summary>
    /// <remarks>
    /// <b>IMPORTANT</b>
    /// The operators for +, -, *, /: Return the first operant type, e. g.:
    /// Meter + Inch => Meter
    /// Inch + Mile => Inch
    /// Millimeter + Kilometer => Millimeter
    /// </remarks>
    /// <typeparam name="T">see above</typeparam>
    public abstract class LengthUnit<T> : Unit<T> where T : Unit<T>
    {
        public LengthUnit(double value)
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
        /// Gets or sets inch value
        /// </summary>
        public abstract InchUnit Inch
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets mile value
        /// </summary>
        public abstract MileUnit Mile
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets millimeter value
        /// </summary>
        public abstract MillimeterUnit Millimeter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or stes meter value
        /// </summary>
        public abstract MeterUnit Meter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets kilometer value
        /// </summary>
        public abstract KilometerUnit Kilometer
        {
            get;
            set;
        }

        internal abstract InchUnit ToInch();
        internal abstract MeterUnit ToMeter();
        internal abstract MillimeterUnit ToMillimeter();
        internal abstract MileUnit ToMile();
        internal abstract KilometerUnit ToKilometer();
    }

    /// @}
}
