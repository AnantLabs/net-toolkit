using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// <summary>
    /// Represent the plane form with coordinates
    /// 
    /// x*a1+y*a2+z*a3=result
    /// </summary>
    public sealed class CoordinateForm3D : IForm
    {
        /// <summary>
        /// Coordinates
        /// </summary>
        public Vector3D Coordinates { get; private set; }
        /// <summary>
        /// Result
        /// </summary>
        public double Result { get; private set; }

        public CoordinateForm3D(Vector3D coord, double result)
        {
            Coordinates = coord;
            Result = result;
        }

        /// <summary>
        /// Gets the normal form
        /// </summary>
        public NormalForm3D NormalForm
        {
            get
            {
                return new NormalForm3D(Coordinates,
                    new Vector3D(0, 0, Result / Coordinates.Z));
            }
        }

        public override string ToString()
        {
            return
                Coordinates.X + "x1+" +
                Coordinates.Y + "x2" +
                Coordinates.Z + "x3=" +
                Result;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (!(obj is CoordinateForm3D))
                return false;
            else if (Object.ReferenceEquals(this, obj))
                return true;

            CoordinateForm3D myObj = (CoordinateForm3D)obj;

            return
                myObj.Coordinates.Equals(Coordinates) &&
                myObj.Result.Equals(Result);
        }

        public override int GetHashCode()
        {
            return
                Coordinates.GetHashCode() +
                Result.GetHashCode();
        }
    }
}
