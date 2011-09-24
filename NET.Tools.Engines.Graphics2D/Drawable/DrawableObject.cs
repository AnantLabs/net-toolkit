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
    /// Represent a drawable object
    /// </summary>
    public abstract class DrawableObject
    {
        /// <summary>
        /// Gets or sets the line style and color as System.Drawing.Pen
        /// </summary>
        public Pen LineStyle { get; set; }
        /// <summary>
        /// Gets or sets the fill style and color as System.Drawing.Brush
        /// </summary>
        public Brush FillStyle { get; set; }

        public DrawableObject(Pen line, Brush fill)
        {
            LineStyle = line;
            FillStyle = fill;
        }

        internal abstract void Draw(Graphics g, DrawStyle style);
    }

    /// @}
}
