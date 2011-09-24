using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Represent the viewport
    /// </summary>
    public sealed class Viewport : IGraphics3DObject
    {
        /// <summary>
        /// The name (key) of this viewport
        /// </summary>
        public String Name { get; private set; }

        /// <summary>
        /// Gets or sets the area of this viewport
        /// </summary>
        public ViewportRectangle ViewportArea { get; set; }
        /// <summary>
        /// Gets or sets the minimum zbuffer size
        /// </summary>
        public double MinimumZBuffer { get; set; }
        /// <summary>
        /// Gets or sets the maximum zbuffer size
        /// </summary>
        public double MaximumZBuffer { get; set; }
        /// <summary>
        /// Gets or sets the arc of viewing
        /// </summary>
        public double ViewArc { get; set; }
        /// <summary>
        /// Gets or sets the minimum distance to nan object to start the rendering process
        /// </summary>
        public double StartRenderingDistance { get; set; }
        /// <summary>
        /// Gets or sets the maximum distance to an object until the rendering is running
        /// </summary>
        public double EndRenderingDistance { get; set; }

        /// <summary>
        /// Gets the connected camera
        /// </summary>
        public Camera Camera { get; private set; }

        public Viewport(String name, Camera camera, ViewportRectangle area, double minZ, double maxZ)
        {
            Name = name;
            Camera = camera;
            ViewportArea = area;
            MinimumZBuffer = minZ;
            MaximumZBuffer = maxZ;
            ViewArc = Math.PI / 4;
        }

        public Viewport(String name, Camera camera, ViewportRectangle area)
            : this(name, camera, area, -1, -1)
        {
        }

        public Viewport(String name, Camera camera)
            : this(name, camera, new ViewportRectangle(0, 0, 1, 1))
        {
        }

        internal void SetViewport(Graphics3D graphics)
        {
            if (!IsVisible || !Camera.IsVisible)
                return;

            Microsoft.DirectX.Direct3D.Viewport vp = graphics.D3DX9.Viewport;
            uint width = graphics.Configuration.ScreenWidth;
            uint height = graphics.Configuration.ScreenHeight;

            vp.X = (int)(ViewportArea.X1 * width);
            vp.Y = (int)(ViewportArea.Y1 * height);
            vp.Width = (int)(ViewportArea.X2 * width);
            vp.Height = (int)(ViewportArea.Y2 * height);
            if (MinimumZBuffer >= 0)
                vp.MinZ = (float)MinimumZBuffer;
            if (MaximumZBuffer >= 0)
                vp.MaxZ = (float)MaximumZBuffer;

            graphics.D3DX9.Viewport = vp;

            graphics.D3DX9.Transform.Projection = Matrix.PerspectiveFovLH(
                (float)ViewArc,
                (float)(graphics.Configuration.ScreenWidth / graphics.Configuration.ScreenHeight),
                (float)StartRenderingDistance,
                (float)EndRenderingDistance);
            Camera.SetCamera(graphics);
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
