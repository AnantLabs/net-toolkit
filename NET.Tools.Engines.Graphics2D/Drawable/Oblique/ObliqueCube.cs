using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using NET.Tools.Engines.Mathematica;

namespace NET.Tools.Engines.Graphics2D
{
    /// \addtogroup graphics2d
    /// @{

    /// <summary>
    /// Represent an obliquely cube
    /// </summary>
    public sealed class ObliqueCube : ObliqueObject
    {
        #region Enumerations

        private enum Cube3DPart
        {
            Main,
            Top,
            Bottom,
            Left,
            Right
        }

        #endregion

        /// <summary>
        /// X value of the cube (orientation of cube-image)
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Y value of the cube (orientation of cube-image)
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Width of the cube
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Height of the cube
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Depth of the cube
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// Orientation of cube-image
        /// </summary>
        public Point Orientation
        {
            get { return new Point(X, Y); }
            set { X = value.X; Y = value.Y; }
        }

        /// <summary>
        /// Size in 3d of cube
        /// </summary>
        public Size3D Size
        {
            get { return new Size3D(Width, Height, Depth); }
            set { Width = value.Width; Height = value.Height; Depth = value.Depth; }
        }

        /// <summary>
        /// Oblique Rectangle for this cube
        /// </summary>
        public ObliqueRectangle Rectangle
        {
            get { return new ObliqueRectangle(Orientation, Size); }
            set { Orientation = value.Orientation; Size = value.Size; }
        }

        internal ObliqueCube()
            : base(Brushes.White, Brushes.Black, Brushes.Gray, Pens.Black, 
                ObliqueLineStyle.HideInvisibleLines, ObliqueFaceStyle.HideInvisibleFaces)
        {
        }

        protected override void DrawLines(Graphics graphics)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddPath(
                CreateCube3DPath(Cube3DPart.Main, X, Y, Width, Height, Depth),
                true);

            path.AddPath(
                CreateCube3DPath(Cube3DPart.Right, X, Y, Width, Height, Depth),
                true);
            path.AddPath(
                CreateCube3DPath(Cube3DPart.Top, X, Y, Width, Height, Depth),
                true);

            if (ObliqueLineStyle != ObliqueLineStyle.HideInvisibleLines)
            {
                if (ObliqueLineStyle == ObliqueLineStyle.ShowInvisibleLinesDotted)
                {
                    graphics.DrawPath(LineStyle.Convert(DashStyle.Dash),
                        CreateCube3DPath(Cube3DPart.Left, X, Y, Width, Height, Depth));
                    graphics.DrawPath(LineStyle.Convert(DashStyle.Dash),
                        CreateCube3DPath(Cube3DPart.Bottom, X, Y, Width, Height, Depth));
                }
                else
                {
                    path.AddPath(
                        CreateCube3DPath(Cube3DPart.Left, X, Y, Width, Height, Depth),
                        true);
                    path.AddPath(
                        CreateCube3DPath(Cube3DPart.Bottom, X, Y, Width, Height, Depth),
                        true);
                }
            }

            graphics.DrawPath(LineStyle, path);
        }

        protected override void DrawFaces(Graphics graphics)
        {
            GraphicsPath mainPath = CreateCube3DPath(Cube3DPart.Main,
                X, Y, Width, Height, Depth);
            mainPath.FillMode = FillMode.Winding;
            graphics.FillPath(LightFaceBrush, mainPath);

            if (ObliqueFaceStyle == ObliqueFaceStyle.ShowInvisibleFaces)
            {
                GraphicsPath leftPath = CreateCube3DPath(Cube3DPart.Left,
                X, Y, Width, Height, Depth);
                leftPath.FillMode = FillMode.Winding;
                graphics.FillPath(LightFaceBrush, leftPath);

                GraphicsPath bottomPath = CreateCube3DPath(Cube3DPart.Bottom,
                    X, Y, Width, Height, Depth);
                bottomPath.FillMode = FillMode.Winding;
                graphics.FillPath(DarkFaceBrush, bottomPath);
            }

            GraphicsPath rightPath = CreateCube3DPath(Cube3DPart.Right,
                X, Y, Width, Height, Depth);
            rightPath.FillMode = FillMode.Winding;
            graphics.FillPath(DarkFaceBrush, rightPath);

            GraphicsPath topPath = CreateCube3DPath(Cube3DPart.Top,
                X, Y, Width, Height, Depth);
            topPath.FillMode = FillMode.Winding;
            graphics.FillPath(LightFaceBrush, topPath);
        }

        private GraphicsPath CreateCube3DPath(Cube3DPart part,
            int x, int y, int width, int height, int depth)
        {
            GraphicsPath path = new GraphicsPath();

            if (part == Cube3DPart.Main)
                path.AddRectangle(new Rectangle(x, y, width, height));
            else if (part == Cube3DPart.Top)
            {
                Point realDepth = GetRealDepth(depth);
                path.AddLines(new Point[] 
                {
                    new Point(x, y),
                    new Point(x + realDepth.X, y + realDepth.Y),
                    new Point(x + width + realDepth.X, y + realDepth.Y),
                    new Point(x + width, y),
                    new Point(x, y)
                });
            }
            else if (part == Cube3DPart.Right)
            {
                Point realDepth = GetRealDepth(depth);
                path.AddLines(new Point[] 
                {
                    new Point(x + width, y),
                    new Point(x + width + realDepth.X, y + realDepth.Y),
                    new Point(x + width + realDepth.X, y + height + realDepth.Y),
                    new Point(x + width, y + height),
                    new Point(x + width, y)
                });
            }
            else if (part == Cube3DPart.Bottom)
            {
                Point realDepth = GetRealDepth(depth);
                path.AddLines(new Point[] 
                {
                    new Point(x, y + height),
                    new Point(x + realDepth.X, y + height + realDepth.Y),
                    new Point(x + width + realDepth.X, y + height + realDepth.Y),
                    new Point(x + width, y + height),
                    new Point(x, y + height)
                });
            }
            else if (part == Cube3DPart.Left)
            {
                Point realDepth = GetRealDepth(depth);
                path.AddLines(new Point[] 
                {
                    new Point(x, y),
                    new Point(x + realDepth.X, y + realDepth.Y),
                    new Point(x + realDepth.X, y + height + realDepth.Y),
                    new Point(x, y + height),
                    new Point(x, y)
                });
            }
            else
                throw new NotImplementedException();

            return path;
        }
    }

    /// @}
}
