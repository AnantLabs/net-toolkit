using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// <summary>
    /// Represnet the plane form with normal vector
    /// 
    /// normal*(x-point)
    /// </summary>
    public sealed class NormalForm3D
    {
        /// <summary>
        /// Normal-Vector
        /// </summary>
        public Vector3D Normal { get; private set; }
        /// <summary>
        /// Point-Vector
        /// </summary>
        public Vector3D Point { get; private set; }

        public NormalForm3D(Vector3D normal, Vector3D point)
        {
            Normal = normal;
            Point = point;
        }

        /// <summary>
        /// Gets the coordinate form
        /// </summary>
        public CoordinateForm3D CoordinateForm
        {
            get
            {
                double result = Normal * Point;
                return new CoordinateForm3D(Normal, -result);
            }
        }

        public override string ToString()
        {
            return
                Normal.ToString() + 
                "*(x-" + Point.ToString() + 
                ")=0";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (!(obj is NormalForm3D))
                return false;
            else if (Object.ReferenceEquals(this, obj))
                return true;

            NormalForm3D myObj = (NormalForm3D)obj;

            return
                myObj.Normal.Equals(Normal) &&
                myObj.Point.Equals(Point);
        }

        public override int GetHashCode()
        {
            return
                Normal.GetHashCode() +
                Point.GetHashCode();
        }
    }
}
