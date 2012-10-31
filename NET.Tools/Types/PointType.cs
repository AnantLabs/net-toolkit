using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    /// <summary>
    /// Represent a typed point
    /// </summary>
    /// <typeparam name="T">Type of the point values</typeparam>
    public struct PointType<T> where T : struct
    {
        /// <summary>
        /// Gets an empty point type
        /// </summary>
        public static PointType<T> Empty { get { return new PointType<T>(default(T), default(T)); } }

        private T x, y;

        /// <summary>
        /// X-Value
        /// </summary>
        public T X { get { return x; } set { x = value; } }
        /// <summary>
        /// Y-Value
        /// </summary>
        public T Y { get { return y; } set { y = value; } }

        public PointType(T x, T y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Check the point type is empty
        /// </summary>
        public bool IsEmpty
        {
            get { return this.Equals(Empty); }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (!(obj is PointType<T>))
                return false;
            else if (Object.ReferenceEquals(this, obj))
                return true;

            PointType<T> myObj = (PointType<T>)obj;

            return
                myObj.x.Equals(x) &&
                myObj.y.Equals(y);
        }

        public override int GetHashCode()
        {
            return
                x.GetHashCode() +
                y.GetHashCode();
        }

        public override string ToString()
        {
            return "[X: " + x.ToString() + ";Y: " + y.ToString() + "]";
        }
    }
}
