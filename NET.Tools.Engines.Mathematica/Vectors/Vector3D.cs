using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// \addtogroup math 
    /// @{

    /// <summary>
    /// Represent a 3d vector
    /// 
    /// This vector contains x, y and z value.
    /// This object is immutable!
    /// </summary>
    public sealed class Vector3D : IVector<Vector3D>
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public Vector3D()
            : this(0, 0, 0)
        {
        }

        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3D operator +(Vector3D v1, Vector3D v2)
        {
            return v1.Add(v2);
        }

        public static Vector3D operator -(Vector3D v1, Vector3D v2)
        {
            return v1.Subtract(v2);
        }

        public static double operator *(Vector3D v1, Vector3D v2)
        {
            return v1.Multiply(v2);
        }

        public static Vector3D operator *(double val, Vector3D vec)
        {
            return vec.Multiply(val);
        }

        public static Vector3D operator /(Vector3D vec, double val)
        {
            return vec.DivideForward(val);
        }

        public static Vector3D operator /(double val, Vector3D vec)
        {
            return vec.DivideBackward(val);
        }

        #region IVector Member

        public double Length
        {
            get
            {
                return Math.Abs(
                          Math.Sqrt(
                              Math.Pow(X, 2) +
                              Math.Pow(Y, 2) +
                              Math.Pow(Z, 2)));
            }
        }

        public Vector3D Add(Vector3D vec)
        {
            return
                new Vector3D(
                    X + vec.X,
                    Y + vec.Y,
                    Z + vec.Z
                );
        }

        public Vector3D Subtract(Vector3D vec)
        {
            return
                new Vector3D(
                    X - vec.X,
                    Y - vec.Y,
                    Z - vec.Z
                );
        }

        public double Multiply(Vector3D vec)
        {
            return X * vec.X + Y * vec.Y + Z * vec.Z;
        }

        public Vector3D Multiply(double num)
        {
            return
                new Vector3D(
                    num * X,
                    num * Y,
                    num * Z
                );
        }

        public Vector3D DivideForward(double num)
        {
            return
                new Vector3D(
                    X / num,
                    Y / num,
                    Z / num
                );
        }

        public Vector3D DivideBackward(double num)
        {
            return
                new Vector3D(
                    num / X,
                    num / Y, 
                    num / Z
                );
        }

        public Vector3D Normalize
        {
            get { return this / Length; }
        }

        #endregion

        /// <summary>
        /// Create the dot of the vectors
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        public Vector3D Dot(Vector3D vec)
        {
            return
                new Vector3D(
                    Y * vec.Z - Z * vec.Y,
                    Z * vec.X - X * vec.Z,
                    X * vec.Y - Y * vec.X
                );
        }

        public override string ToString()
        {
            return "[" + X + "|" + Y + "|" + Z + "]";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (!(obj is Vector3D))
                return false;
            else if (Object.ReferenceEquals(this, obj))
                return true;

            Vector3D myObj = (Vector3D)obj;

            return
                myObj.X.Equals(X) &&
                myObj.Y.Equals(Y) &&
                myObj.Z.Equals(Z);
        }

        public override int GetHashCode()
        {
            return
                X.GetHashCode() +
                Y.GetHashCode() +
                Z.GetHashCode();
        }
    }

    /// @}
}
