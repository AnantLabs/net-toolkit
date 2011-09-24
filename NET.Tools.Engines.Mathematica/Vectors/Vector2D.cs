using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// \addtogroup math 
    /// @{

    /// <summary>
    /// Represent a 2d vector
    /// 
    /// This vector contains x and y value.
    /// This object is immutable!
    /// </summary>
    public sealed class Vector2D : IVector<Vector2D>
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Vector2D()
            : this(0, 0)
        {
        }

        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Vector2D operator +(Vector2D v1, Vector2D v2)
        {
            return v1.Add(v2);
        }

        public static Vector2D operator -(Vector2D v1, Vector2D v2)
        {
            return v1.Subtract(v2);
        }

        public static double operator *(Vector2D v1, Vector2D v2)
        {
            return v1.Multiply(v2);
        }

        public static Vector2D operator *(double val, Vector2D vec)
        {
            return vec.Multiply(val);
        }

        public static Vector2D operator /(Vector2D vec, double val)
        {
            return vec.DivideForward(val);
        }

        public static Vector2D operator /(double val, Vector2D vec)
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
                              Math.Pow(Y, 2)));
            }
        }

        public Vector2D Add(Vector2D vec)
        {
            return
                new Vector2D(
                    X + vec.X,
                    Y + vec.Y
                );
        }

        public Vector2D Subtract(Vector2D vec)
        {
            return
                new Vector2D(
                    X - vec.X,
                    Y - vec.Y
                );
        }

        public double Multiply(Vector2D vec)
        {
            return X * vec.X + Y * vec.Y;
        }

        public Vector2D Multiply(double num)
        {
            return
                new Vector2D(
                    num * X,
                    num * Y
                );
        }

        public Vector2D DivideForward(double num)
        {
            return
                new Vector2D(
                    X / num,
                    Y / num
                );
        }

        public Vector2D DivideBackward(double num)
        {
            return
                new Vector2D(
                    num / X,
                    num / Y
                );
        }

        public Vector2D Normalize
        {
            get { return this / Length; }
        }

        #endregion

        public override string ToString()
        {
            return "[" + X + "|" + Y + "]";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (!(obj is Vector2D))
                return false;
            else if (Object.ReferenceEquals(this, obj))
                return true;

            Vector2D myObj = (Vector2D)obj;

            return
                myObj.X.Equals(X) &&
                myObj.Y.Equals(Y);
        }

        public override int GetHashCode()
        {
            return
                X.GetHashCode() +
                Y.GetHashCode();
        }
    }

    /// @}
}
