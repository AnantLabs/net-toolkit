using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.Mathematica;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Interface for an object with a dependency to the matrix
    /// </summary>
    public interface IMatrixObject : IRenderableObject
    {
        /// <summary>
        /// Gets or sets the position of node
        /// </summary>
        Vector3D Position { get; set; }
        /// <summary>
        /// Gets or sets the scaling of node
        /// </summary>
        Vector3D Scaling { get; set; }
        /// <summary>
        /// Gets or sets the rotation of node
        /// </summary>
        Quaternion3D Rotation { get; set; }

        /// <summary>
        /// Gets or sets the distance to start rendering of this renerable object
        /// </summary>
        double StartRenderingDistance { get; set; }
        /// <summary>
        /// Gets or sets the distance until the renderable object is rendered
        /// </summary>
        double EndRenderingDistance { get; set; }
    }

    /// @}
}
