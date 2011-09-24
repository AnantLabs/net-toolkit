using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace NET.Tools.Engines.Graphics2D
{
    /// \addtogroup graphics2d
    /// @{

    /// <summary>
    /// Represent a single graph
    /// 
    /// If the FillStyle is not transparent it will filled the part under the graph line
    /// </summary>
    public sealed class DrawableGraph : DrawableObject
    {
        /// <summary>
        /// Gets or sets the area for the graph drawing
        /// </summary>
        public Rectangle GraphArea { get; set; }
        /// <summary>
        /// Gets or sets the dimension for the x and y values
        /// </summary>
        public Dimension ValueDimension { get; set; }
        /// <summary>
        /// Gets or sets the function to compute the graph
        /// </summary>
        public Func<double, double> Function { get; set; }

        /// <summary>
        /// Gets or sets the graph area origin
        /// </summary>
        public Point GraphAreaLocation
        {
            get { return GraphArea.Location; }
            set { GraphArea = new Rectangle(value, GraphArea.Size); }
        }
        /// <summary>
        /// Gets or sets the graph area size
        /// </summary>
        public Size GraphAreaSize
        {
            get { return GraphArea.Size; }
            set { GraphArea = new Rectangle(GraphArea.Location, value); }
        }

        internal DrawableGraph()
            : base(Pens.Red, Brushes.Transparent)
        {
            GraphArea = new Rectangle(0, 0, 300, 300);
            ValueDimension = new Dimension(-10, -10, 10, 10);
        }

        internal override void Draw(System.Drawing.Graphics g, DrawStyle style)
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < GraphArea.Width; i++)
            {
                double xValue = 
                    ValueDimension.MinimumX + 
                    (ValueDimension.XDifference / GraphArea.Width) * i;
                double yValue = Function(xValue);
                int yPixel = (int)Math.Abs(
                    (ValueDimension.MinimumY + yValue) * 
                    GraphArea.Height / ValueDimension.YDifference);

                if (ValueDimension.IsBetweenYBorders(yValue))
                {   //Add point to list
                    points.Add(new Point(GraphArea.Left + i, GraphArea.Top + yPixel));
                }
                else if (yValue < ValueDimension.MinimumY)
                {
                    points.Add(new Point(GraphArea.Left + i, GraphArea.Bottom));
                }
                else if (yValue > ValueDimension.MaximumY)
                {
                    points.Add(new Point(GraphArea.Left + i, GraphArea.Top));
                }
                //else if (points.Count > 0)
                //{
                //    //Draw all points...
                //    g.DrawLines(LineStyle, points.ToArray());
                //    //...and clear list for next draw point in list
                //    points.Clear();
                //}
            }

            if ((style == DrawStyle.Both) || (style == DrawStyle.Lines))
            {
                if (points.Count > 0)
                    g.DrawLines(LineStyle, points.ToArray());
            }

            //****************************************************************

            points.Add(GraphArea.GetBottomRight());
            points.Add(new Point(GraphArea.Left, GraphArea.Bottom));

            byte[] types = new byte[points.Count];
            for (int i = 0; i < types.Length; i++)
                types[i] = (byte)PathPointType.Line;

            GraphicsPath path = new GraphicsPath(points.ToArray(), types);
            path.CloseAllFigures();

            if ((style == DrawStyle.Both) || (style == DrawStyle.Faces))
            {
                g.FillPath(FillStyle, path);
            }
        }
    }

    /// @}
}
