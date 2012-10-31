using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    /// <summary>
    /// Represent a typed size
    /// </summary>
    /// <typeparam name="T">Type of size values</typeparam>
    public struct SizeType<T> where T : struct
    {
        /// <summary>
        /// Gets an empty point type
        /// </summary>
        public static SizeType<T> Empty { get { return new SizeType<T>(default(T), default(T)); } }

        private T width, height;

        /// <summary>
        /// Width-Value
        /// </summary>
        public T Width { get { return width; } set { width = value; } }
        /// <summary>
        /// Height-Value
        /// </summary>
        public T Height { get { return height; } set { height = value; } }

        public SizeType(T width, T height)
        {
            this.width = width;
            this.height = height;
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
            else if (!(obj is SizeType<T>))
                return false;
            else if (Object.ReferenceEquals(this, obj))
                return true;

            SizeType<T> myObj = (SizeType<T>)obj;

            return
                myObj.width.Equals(width) &&
                myObj.height.Equals(height);
        }

        public override int GetHashCode()
        {
            return
                width.GetHashCode() +
                height.GetHashCode();
        }

        public override string ToString()
        {
            return "[Width: " + width.ToString() + ";Height: " + height.ToString() + "]";
        }
    }
}
