using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NET.Tools.Engines.Graphics2D
{
    /// \addtogroup graphics2d
    /// @{

    /// <summary>
    /// Represent a graphics 2d object for gdi+
    /// </summary>
    public sealed class Graphics2D
    {
        public Graphics Graphics { get; private set; }

        public Graphics2D(Graphics g)
        {
            Graphics = g;
        }

        public static implicit operator Graphics2D(Graphics g)
        {
            return new Graphics2D(g);
        }

        public static implicit operator Graphics(Graphics2D g)
        {
            return g.Graphics;
        }

        /// <summary>
        /// Create an default oblique cube
        /// </summary>
        /// <returns></returns>
        public ObliqueCube CreateObliqueCube()
        {
            return new ObliqueCube();
        }

        /// <summary>
        /// Create a default drawable graph
        /// </summary>
        /// <returns></returns>
        public DrawableGraph CreateDrawableGraph()
        {
            return new DrawableGraph();
        }

        /// <summary>
        /// Create a default drawable coordinate system
        /// </summary>
        /// <returns></returns>
        public DrawableCoordinateSystem CreateDrawableCoordinateSystem()
        {
            return new DrawableCoordinateSystem();
        }

        /// <summary>
        /// Draw all graphics2d objects
        /// </summary>
        /// <param name="style">Style for drawing</param>
        /// <param name="draw">The drawable object to draw</param>
        public void Draw(DrawStyle style, DrawableObject draw)
        {
            draw.Draw(Graphics, style);
        }
    }

    /// @}
}
