using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// <summary>
    /// Represent a quaternion in 3d
    /// 
    /// This object contains values Angle in radian and degree and the axis as Vector3D
    /// </summary>
    public sealed class Quaternion3D : IQuaternion
    {
        /// <summary>
        /// Gets the angle of this quaternion as radian
        /// </summary>
        public RadianUnit AngleRadian { get; private set; }
        /// <summary>
        /// Gets the angle of this quaternion as degree
        /// </summary>
        public DegreeUnit AngleDegree 
        { 
            get { return AngleRadian.Degree; }
            private set { AngleRadian = value.Radian; }
        }
        /// <summary>
        /// Gets the axis around the objects will be rotate
        /// </summary>
        public Vector3D Axis { get; private set; }

        public Quaternion3D(RadianUnit angle, Vector3D axis)
        {
            AngleRadian = angle;
            Axis = axis;
        }

        public Quaternion3D(DegreeUnit angle, Vector3D axis)
        {
            AngleDegree = angle;
            Axis = axis;
        }

        public Quaternion3D()
            : this(new RadianUnit(0d), new Vector3D())
        {
        }

        public override string ToString()
        {
            return "Angle (Radian): " + AngleRadian.ToString() + "; Axis: " + Axis.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (!(obj is Quaternion3D))
                return false;
            else if (Object.ReferenceEquals(this, obj))
                return true;

            Quaternion3D myObj = (Quaternion3D)obj;

            return
                myObj.AngleRadian.Equals(AngleRadian) &&
                myObj.Axis.Equals(Axis);
        }

        public override int GetHashCode()
        {
            return
                AngleRadian.GetHashCode() +
                Axis.GetHashCode();
        }
    }
}
