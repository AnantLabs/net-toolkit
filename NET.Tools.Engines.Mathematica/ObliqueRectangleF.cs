using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NET.Tools.Engines.Mathematica
{
    /// <summary>
    /// Represent a rectangle for obliquely objects width float-values
    /// </summary>
    public struct ObliqueRectangleF
    {
        /// <summary>
        /// Gets an empty object from this type
        /// 
        /// Contains values x, y, width, height, depth
        /// </summary>
        public static ObliqueRectangleF Empty { get { return new ObliqueRectangleF(0, 0, 0, 0, 0); } }

        private float x, y, width, height, depth;

        /// <summary>
        /// X
        /// </summary>
        public float X { get { return x; } set { x = value; } }
        /// <summary>
        /// Y
        /// </summary>
        public float Y { get { return y; } set { y = value; } }
        /// <summary>
        /// Width
        /// </summary>
        public float Width { get { return width; } set { width = value; } }
        /// <summary>
        /// Height
        /// </summary>
        public float Height { get { return height; } set { height = value; } }
        /// <summary>
        /// Depth
        /// </summary>
        public float Depth { get { return depth; } set { depth = value; } }

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
        public PointF Orientation
        {
            get { return new PointF(x, y); }
            set { x = value.X; y = value.Y; }
        }

        /// <summary>
        /// Size as Size3D (width/height/depth)
        /// </summary>
        public Size3DF Size
        {
            get { return new Size3DF(width, height, depth); }
            set { width = value.Width; height = value.Height; depth = value.Depth; }
        }

        public ObliqueRectangleF(float x, float y, float width, float height, float depth)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.depth = depth;
        }

        public ObliqueRectangleF(PointF orientation, Size3DF size)
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
