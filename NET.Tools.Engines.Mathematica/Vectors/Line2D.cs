using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// <summary>
    /// Represent a 2d line
    /// 
    /// The object is immutable!
    /// </summary>
    public sealed class Line2D : ILine<Vector2D>
    {
        /// <summary>
        /// Point on the line
        /// </summary>
        public Vector2D Point { get; private set; }
        /// <summary>
        /// Direction of the line from the point
        /// </summary>
        public Vector2D Direction { get; private set; }

        public Line2D(Vector2D point, Vector2D direction)
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
            else if (!(obj is Line2D))
                return false;
            else if (Object.ReferenceEquals(this, obj))
                return true;

            Line2D myObj = (Line2D)obj;

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
