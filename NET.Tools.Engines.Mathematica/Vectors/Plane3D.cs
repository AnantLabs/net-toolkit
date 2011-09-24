using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// <summary>
    /// Represent a 3d plane
    /// 
    /// The object is immutable!
    /// </summary>
    public sealed class Plane3D : IPlane
    {
        /// <summary>
        /// Normal form fpr this plane
        /// </summary>
        public NormalForm3D NormalForm { get; private set; }

        public Plane3D(NormalForm3D normalForm)
        {
            this.NormalForm = normalForm;
        }

        public override string ToString()
        {
            return NormalForm.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (!(obj is Plane3D))
                return false;
            else if (Object.ReferenceEquals(obj, this))
                return true;

            Plane3D myObj = (Plane3D)obj;

            return
                NormalForm.Equals(myObj.NormalForm);
        }

        public override int GetHashCode()
        {
            return
                NormalForm.GetHashCode();
        }
    }
}
