using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    /// <summary>
    /// Represent a typed rectangle
    /// </summary>
    /// <typeparam name="T">Type of rectangle values</typeparam>
    public struct RectangleType<T> where T : struct
    {
        /// <summary>
        /// Gets an empty rectangle
        /// </summary>
        public static RectangleType<T> Empty
        {
            get { return new RectangleType<T>(PointType<T>.Empty, SizeType<T>.Empty); }
        }

        private PointType<T> location;
        private SizeType<T> size;

        /// <summary>
        /// X-Position
        /// </summary>
        public T X
        {
            get { return location.X; }
            set { location = new PointType<T>(value, location.Y); }
        }

        /// <summary>
        /// Y-Position
        /// </summary>
        public T Y
        {
            get { return location.Y; }
            set { location = new PointType<T>(location.X, value); }
        }

        /// <summary>
        /// Left position
        /// </summary>
        public T Left
        {
            get { return X; }
            set { X = value; }
        }

        /// <summary>
        /// Top position
        /// </summary>
        public T Top
        {
            get { return Y; }
            set { Y = value; }
        }

        /// <summary>
        /// Width
        /// </summary>
        public T Width
        {
            get { return size.Width; }
            set { size = new SizeType<T>(value, size.Height); }
        }

        /// <summary>
        /// Height
        /// </summary>
        public T Height
        {
            get { return size.Height; }
            set { size = new SizeType<T>(size.Width, value); }
        }

        /// <summary>
        /// Location
        /// </summary>
        public PointType<T> Location
        {
            get { return location; }
            set { location = value; }
        }

        /// <summary>
        /// Size
        /// </summary>
        public SizeType<T> Size
        {
            get { return size; }
            set { size = value; }
        }

        public RectangleType(T x, T y, T width, T height)
        {
            this.location = new PointType<T>(x, y);
            this.size = new SizeType<T>(width, height);
        }

        public RectangleType(PointType<T> location, SizeType<T> size)
        {
            this.location = location;
            this.size = size;
        }

        /// <summary>
        /// Check the rectangle is empty
        /// </summary>
        public bool IsEmpty
        {
            get { return this.Equals(Empty); }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (!(obj is RectangleType<T>))
                return false;
            else if (Object.ReferenceEquals(this, obj))
                return true;

            RectangleType<T> myObj = (RectangleType<T>)obj;

            return
                myObj.location.Equals(Location) &&
                myObj.size.Equals(Size);
        }

        public override int GetHashCode()
        {
            return
                location.GetHashCode() +
                size.GetHashCode();
        }

        public override string ToString()
        {
            return "(Location: " + location.ToString() + ";Size: " + size.ToString() + ")";
        }
    }
}
