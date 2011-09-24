using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.Mathematica;
using System.ComponentModel;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Interface for all renderable objects
    /// </summary>
    public interface IRenderableObject : IGraphics3DObject
    {
        /// <summary>
        /// Render the object
        /// </summary>
        /// <param name="graphics">Graphics-Object to render</param>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        void Render(Graphics3D graphics);

        /// <summary>
        /// Gets or sets the visibility of an graphics 3d object
        /// </summary>
        bool IsVisible { get; set; }
    }

    /// @}
}
