using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// <summary>
    /// Represent the plane form with direction vectors
    /// 
    /// x = first+a*second+b*third
    /// </summary>
    public sealed class PointDirectionForm3D
    {
        /// <summary>
        /// First direction vector
        /// </summary>
        public Vector3D FirstPoint { get; private set; }
        /// <summary>
        /// Second direction vector
        /// </summary>
        public Vector3D SecondPoint { get; private set; }
        /// <summary>
        /// Third direction vector
        /// </summary>
        public Vector3D ThirdPoint { get; private set; }

        public PointDirectionForm3D(Vector3D firstPoint, Vector3D secondPoint, Vector3D thirdPoint)
        {
            FirstPoint = firstPoint;
            SecondPoint = secondPoint;
            ThirdPoint = thirdPoint;
        }

        /// <summary>
        /// Gets the normal form
        /// </summary>
        public NormalForm3D NormalForm
        {
            get
            {
                return new NormalForm3D(SecondPoint.Dot(ThirdPoint), FirstPoint);
            }
        }

        /// <summary>
        /// Gets the coordinate form
        /// </summary>
        /// <remarks>It computes the normal form first, than the coordinate form</remarks>
        public CoordinateForm3D CoordinateForm
        {
            get
            {
                return this.NormalForm.CoordinateForm;
            }
        }

        public override string ToString()
        {
            return
                "x=" +
                FirstPoint.ToString() +
                "+a*" + SecondPoint.ToString() +
                "+b*" + ThirdPoint.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (!(obj is PointDirectionForm3D))
                return false;
            else if (Object.ReferenceEquals(this, obj))
                return true;

            PointDirectionForm3D myObj = (PointDirectionForm3D)obj;

            return
                myObj.FirstPoint.Equals(FirstPoint) &&
                myObj.SecondPoint.Equals(SecondPoint) &&
                myObj.ThirdPoint.Equals(ThirdPoint);
        }

        public override int GetHashCode()
        {
            return
                FirstPoint.GetHashCode() +
                SecondPoint.GetHashCode() +
                ThirdPoint.GetHashCode();
        }
    }
}
