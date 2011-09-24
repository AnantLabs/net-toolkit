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
    /// Basic class for all renderable objects
    /// 
    /// This includes that all renderable objects are Graphics3DObjects
    /// </summary>
    public abstract class Object3D : IMatrixObject
    {
        /// <summary>
        /// Render this entity
        /// </summary>
        /// <param name="graphics">Graphics-Object to render this entity</param>
        public abstract void Render(Graphics3D graphics);

        #region IRenderableObject Member

        public double StartRenderingDistance
        {
            get;
            set;
        }

        public double EndRenderingDistance
        {
            get;
            set;
        }

        public Vector3D Position { get; set; }
        public Vector3D Scaling { get; set; }
        public Quaternion3D Rotation { get; set; }

        #endregion

        #region IGraphics3DObject Member

        public bool IsVisible
        {
            get;
            set;
        }

        #endregion

        #region IDisposable Member

        public abstract void Dispose();

        #endregion
    }

    /// @}
}
