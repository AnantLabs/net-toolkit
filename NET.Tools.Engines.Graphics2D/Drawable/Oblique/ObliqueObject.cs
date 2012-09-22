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
    /// Represent an obliquely object
    /// </summary>
    public abstract class ObliqueObject : DrawableObject
    {
        public Brush LightFaceBrush { get; set; }
        public Brush DarkFaceBrush { get; set; }
        public ObliqueLineStyle ObliqueLineStyle { get; set; }
        public ObliqueFaceStyle ObliqueFaceStyle { get; set; }

        public ObliqueObject(Brush lightSite, Brush darkSite, Brush normalSite,
            Pen line, ObliqueLineStyle oblLineStyle, ObliqueFaceStyle oblFaceStyle)
            : base(line, normalSite)
        {
            LightFaceBrush = lightSite;
            DarkFaceBrush = darkSite;
            ObliqueLineStyle = oblLineStyle;
            ObliqueFaceStyle = oblFaceStyle;
        }

        internal override void Draw(Graphics g, DrawStyle style)
        {
            if ((style == DrawStyle.Faces) || (style == DrawStyle.Both))
            {
                DrawFaces(g);
            }
            if ((style == DrawStyle.Lines) || (style == DrawStyle.Both))
            {
                DrawLines(g);
            }
        }

        /// <summary>
        /// Draw only lines
        /// </summary>
        protected abstract void DrawLines(Graphics g);
        /// <summary>
        /// Draw only faces
        /// </summary>
        protected abstract void DrawFaces(Graphics g);

        protected Point GetRealDepth(int depth)
        {
            return new Point((depth / 2), -(depth / 2));
        }
    }

    /// @}
}
