using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.Mathematica;
using Microsoft.DirectX;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Represent the 3d camera
    /// </summary>
    public sealed class Camera : IGraphics3DObject
    {
        /// <summary>
        /// Gets or stes the position of this camera
        /// </summary>
        public Vector3D Position { get; set; }
        /// <summary>
        /// Gets or sets the direction (at-point) of this camera
        /// </summary>
        public Vector3D Direction { get; set; }
        /// <summary>
        /// Gets or sets the up vector for this camera
        /// </summary>
        public Vector3D UpVector { get; set; }

        public Camera(Vector3D pos, Vector3D dir)
        {
            Position = pos;
            Direction = dir;
        }

        public Camera()
            : this(new Vector3D(), new Vector3D(1,0,1))
        {
        }

        internal void SetCamera(Graphics3D graphics)
        {
            if (!IsVisible)
                return;

            graphics.D3DX9.Transform.View = 
                Matrix.LookAtLH(
                    Position.ToVector3(), 
                    Direction.ToVector3(), 
                    UpVector.ToVector3());
        }

        #region IGraphics3DObject Member

        public bool IsVisible
        {
            get;
            set;
        }

        #endregion

        #region IDisposable Member

        public void Dispose()
        {
        }

        #endregion
    }

    /// @}
}
