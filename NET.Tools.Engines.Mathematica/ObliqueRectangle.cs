using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NET.Tools.Engines.Mathematica
{
    /// <summary>
    /// Represent a rectangle for obliquely objects
    /// 
    /// Contains values x, y, width, height, depth
    /// </summary>
    public struct ObliqueRectangle
    {
        /// <summary>
        /// Gets an empty object from this type
        /// </summary>
        public static ObliqueRectangle Empty { get { return new ObliqueRectangle(0, 0, 0, 0, 0); } }

        private int x, y, width, height, depth;

        /// <summary>
        /// X
        /// </summary>
        public int X { get { return x; } set { x = value; } }
        /// <summary>
        /// Y
        /// </summary>
        public int Y { get { return y; } set { y = value; } }
        /// <summary>
        /// Width
        /// </summary>
        public int Width { get { return width; } set { width = value; } }
        /// <summary>
        /// Height
        /// </summary>
        public int Height { get { return height; } set { height = value; } }
        /// <summary>
        /// Depth
        /// </summary>
        public int Depth { get { return depth; } set { depth = value; } }

        /// <summary>
        /// Check the object is empty
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return
                    (x == 0) &&
                    (y == 0) &&
                    (width == 0) &&
                    (height == 0) &&
                    (depth == 0);
            }
        }

        /// <summary>
        /// Orientation (X/Y)
        /// </summary>
        public Point Orientation
        {
            get { return new Point(x, y); }
            set { x = value.X; y = value.Y; }
        }

        /// <summary>
        /// Size as Size3D (width/height/depth)
        /// </summary>
        public Size3D Size
        {
            get { return new Size3D(width, height, depth); }
            set { width = value.Width; height = value.Height; depth = value.Depth; }
        }

        public ObliqueRectangle(int x, int y, int width, int height, int depth)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.depth = depth;
        }

        public ObliqueRectangle(Point orientation, Size3D size)
            : this(orientation.X, orientation.Y, size.Width, size.Height, size.Depth)
        {
        }

        public override string ToString()
        {
            return X + "x" + Y + "-" + width + "x" + height + "x" + depth;
        }

        public override bool Equals(object obj)
        {
            return EHCBuilder.Equals(this, obj);
        }

        public override int GetHashCode()
        {
            return EHCBuilder.GetHashCode(this);
        }
    }
}
