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
    /// Represent a coordinate system
    /// </summary>
    public sealed class DrawableCoordinateSystem : DrawableObject
    {
        /// <summary>
        /// Gets or sets the style and color of the main lines on x- and y-axis
        /// </summary>
        public Pen MainLineStyle { get; set; }

        /// <summary>
        /// Gets or sets the area for the coordinate system drawing
        /// </summary>
        public Rectangle CoordinateSystemArea { get; set; }
        /// <summary>
        /// Gets or sets the dimension for the x and y values
        /// </summary>
        public Dimension ValueDimension { get; set; }
        /// <summary>
        /// Gets or sets the function to compute the graph
        /// </summary>
        public Func<double, double> Function { get; set; }

        /// <summary>
        /// Gets or sets the coordinate system area origin
        /// </summary>
        public Point CoordinateSystemAreaLocation
        {
            get { return CoordinateSystemArea.Location; }
            set { CoordinateSystemArea = new Rectangle(value, CoordinateSystemArea.Size); }
        }
        /// <summary>
        /// Gets or sets the coordinate system area size
        /// </summary>
        public Size CoordinateSystemAreaSize
        {
            get { return CoordinateSystemArea.Size; }
            set { CoordinateSystemArea = new Rectangle(CoordinateSystemArea.Location, value); }
        }

        /// <summary>
        /// Gets or sets the tick frequence of X axis
        /// </summary>
        public double XTickFrequence { get; set; }
        /// <summary>
        /// Gets or sets the tick frequence of Y axis
        /// </summary>
        public double YTickFrequence { get; set; }

        /// <summary>
        /// Gets or sets the main axis value for x
        /// </summary>
        public double XMainAxis { get; set; }
        /// <summary>
        /// Gets or sets the main axis value for y
        /// </summary>
        public double YMainAxis { get; set; }

        internal DrawableCoordinateSystem()
            : base(Pens.Black, Brushes.White)
        {
            MainLineStyle = Pens.Black.Convert(3);
            SetTickFrequence(1);
            SetMainAxis(0);
        }

        internal override void Draw(System.Drawing.Graphics g, DrawStyle style)
        {
            if ((style == DrawStyle.Both) || (style == DrawStyle.Faces))
            {
                g.FillRectangle(FillStyle, CoordinateSystemArea);
            }

            if ((style == DrawStyle.Both) || (style == DrawStyle.Lines))
            {
                //***** X *****\\
                double counter = 0f, dimensionCounter = ValueDimension.MinimumX;
                bool isLineDrawn = false;
                for (int i = 0; i < CoordinateSystemArea.Width; i++)
                {
                    dimensionCounter += (ValueDimension.XDifference / CoordinateSystemArea.Width);
                    counter += (ValueDimension.XDifference / CoordinateSystemArea.Width);
                    if (counter >= XTickFrequence)
                    {
                        g.DrawLine(LineStyle,
                            new Point(CoordinateSystemArea.Left + i, CoordinateSystemArea.Top),
                            new Point(CoordinateSystemArea.Left + i, CoordinateSystemArea.Bottom));
                        counter = 0f;
                    }
                    if ((dimensionCounter >= XMainAxis) && !isLineDrawn)
                    {
                        g.DrawLine(MainLineStyle,
                            new Point(CoordinateSystemArea.Left + i, CoordinateSystemArea.Top),
                            new Point(CoordinateSystemArea.Left + i, CoordinateSystemArea.Bottom));
                        isLineDrawn = true;
                    }
                }

                //***** Y *****\\
                counter = 0f; dimensionCounter = ValueDimension.MinimumY;
                isLineDrawn = false;
                for (int i = 0; i < CoordinateSystemArea.Height; i++)
                {
                    dimensionCounter += (ValueDimension.YDifference / CoordinateSystemArea.Height);
                    counter += (ValueDimension.YDifference / CoordinateSystemArea.Height);
                    if (counter >= YTickFrequence)
                    {
                        g.DrawLine(LineStyle,
                            new Point(CoordinateSystemArea.Left, CoordinateSystemArea.Top + i),
                            new Point(CoordinateSystemArea.Right, CoordinateSystemArea.Top + i));
                        counter = 0f;
                    }
                    if ((dimensionCounter >= YMainAxis) && !isLineDrawn)
                    {
                        g.DrawLine(MainLineStyle,
                            new Point(CoordinateSystemArea.Left, CoordinateSystemArea.Top + i),
                            new Point(CoordinateSystemArea.Right, CoordinateSystemArea.Top + i));
                        isLineDrawn = true;
                    }
                }
            }
        }

        /// <summary>
        /// Sets tick frequence of both axis
        /// </summary>
        /// <param name="value">The tick frequence value</param>
        public void SetTickFrequence(double value)
        {
            XTickFrequence = value;
            YTickFrequence = value;
        }

        /// <summary>
        /// Sets the main axis value for both, x and y
        /// </summary>
        /// <param name="value">The axis value</param>
        public void SetMainAxis(double value)
        {
            XMainAxis = value;
            YMainAxis = value;
        }
    }

    /// @}
}
