using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX;
using NET.Tools.Engines.Mathematica;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// AddOn for vectors
    /// </summary>
    public static class AddOnVectors
    {
        public static Vector3 ToVector3(this Vector3D vector)
        {
            return new Vector3(
                (float)vector.X,
                (float)vector.Y,
                (float)vector.Z);
        }
    }

    /// @}
}
