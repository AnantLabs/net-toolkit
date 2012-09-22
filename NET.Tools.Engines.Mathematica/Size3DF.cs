using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// <summary>
    /// Represent a 3d-size with float-values
    /// 
    /// Contains width, height, depth
    /// </summary>
    public struct Size3DF
    {
        #region Static

        /// <summary>
        /// Gets an empty size object
        /// </summary>
        public static Size3DF Empty { get { return new Size3DF(0, 0, 0); } }

        #endregion

        private float width, height, depth;

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

        public Size3DF(float width, float height, float depth)
        {
            this.width = width;
            this.height = height;
            this.depth = depth;
        }

        public static Size3DF operator +(Size3DF val1, Size3DF val2)
        {
            return new Size3DF(
                val1.width + val2.width,
                val1.height + val2.height,
                val1.depth + val2.depth);
        }

        public static Size3DF operator -(Size3DF val1, Size3DF val2)
        {
            return new Size3DF(
                val1.width - val2.width,
                val1.height - val2.height,
                val1.depth - val2.depth);
        }

        public static Size3DF operator *(Size3DF val1, Size3DF val2)
        {
            return new Size3DF(
                val1.width * val2.width,
                val1.height * val2.height,
                val1.depth * val2.depth);
        }

        public static Size3DF operator /(Size3DF val1, Size3DF val2)
        {
            return new Size3DF(
                val1.width / val2.width,
                val1.height / val2.height,
                val1.depth / val2.depth);
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
