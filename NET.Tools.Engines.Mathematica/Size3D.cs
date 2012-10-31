using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// <summary>
    /// Represent a 3d-size
    /// 
    /// Contains width, height, depth
    /// </summary>
    public struct Size3D
    {
        #region Static

        /// <summary>
        /// Gets an empty size object
        /// </summary>
        public static Size3D Empty { get { return new Size3D(0, 0, 0); } }

        #endregion

        private int width, height, depth;

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
        /// Check this object is empty
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return
                    (width == 0) &&
                    (height == 0) &&
                    (depth == 0);
            }
        }

        public Size3D(int width, int height, int depth)
        {
            this.width = width;
            this.height = height;
            this.depth = depth;
        }

        public static Size3D operator +(Size3D val1, Size3D val2)
        {
            return new Size3D(
                val1.width + val2.width,
                val1.height + val2.height,
                val1.depth + val2.depth);
        }

        public static Size3D operator -(Size3D val1, Size3D val2)
        {
            return new Size3D(
                val1.width - val2.width,
                val1.height - val2.height,
                val1.depth - val2.depth);
        }

        public static Size3D operator *(Size3D val1, Size3D val2)
        {
            return new Size3D(
                val1.width * val2.width,
                val1.height * val2.height,
                val1.depth * val2.depth);
        }

        public static Size3D operator /(Size3D val1, Size3D val2)
        {
            return new Size3D(
                val1.width / val2.width,
                val1.height / val2.height,
                val1.depth / val2.depth);
        }

        public static implicit operator Size3DF(Size3D s)
        {
            return new Size3DF(s.width, s.height, s.depth);
        }

        public override string ToString()
        {
            return width + "x" + height + "x" + depth;
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
