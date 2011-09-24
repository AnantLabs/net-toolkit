using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// <summary>
    /// Represent a 3d line
    /// 
    /// The object is immutable!
    /// </summary>
    public sealed class Line3D : ILine<Vector3D>
    {
        /// <summary>
        /// Point on the line
        /// </summary>
        public Vector3D Point { get; private set; }
        /// <summary>
        /// Direction of the line from the point
        /// </summary>
        public Vector3D Direction { get; private set; }

        public Line3D(Vector3D point, Vector3D direction)
        {
            Point = point;
            Direction = direction;
        }

        public override string ToString()
        {
            return Point.ToString() + "+r*" + Direction.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (!(obj is Line3D))
                return false;
            else if (Object.ReferenceEquals(this, obj))
                return true;

            Line3D myObj = (Line3D)obj;

            return
                myObj.Direction.Equals(Direction) &&
                myObj.Point.Equals(Point);
        }

        public override int GetHashCode()
        {
            return
                Direction.GetHashCode() +
                Point.GetHashCode();
        }
    }
}
