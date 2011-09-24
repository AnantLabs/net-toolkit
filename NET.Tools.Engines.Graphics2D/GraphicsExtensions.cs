using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.Graphics2D;
using System.Drawing;

namespace NET.Tools
{
    /// \addtogroup graphics2d
    /// @{

    /// <summary>
    /// Represent additional graphic extensions to wrap graphics2d
    /// </summary>
    public static class GraphicsExtensions
    {
        /// <summary>
        /// Create an default oblique cube
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static ObliqueCube CreateObliqueCube(this Graphics g)
        {
            return new Graphics2D(g).CreateObliqueCube();
        }

        /// <summary>
        /// Create a default drawable graph
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static DrawableGraph CreateDrawableGraph(this Graphics g)
        {
            return new Graphics2D(g).CreateDrawableGraph();
        }

        /// <summary>
        /// Create a default drawable coordinate system
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static DrawableCoordinateSystem CreateCoordinateSystem(this Graphics g)
        {
            return new Graphics2D(g).CreateDrawableCoordinateSystem();
        }

        /// <summary>
        /// Draw all graphics2d objects
        /// </summary>
        /// <param name="style">Style for drawing</param>
        /// <param name="draw">The drawable object to draw</param>
        /// <param name="g"></param>
        public static void Draw(this Graphics g, DrawStyle style, DrawableObject draw)
        {
            new Graphics2D(g).Draw(style, draw);
        }
    }

    /// @}
}
