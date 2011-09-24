using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics2D
{
    /// \addtogroup graphics2d
    /// @{

    /// <summary>
    /// Dimension for a coordinate system and a graph
    /// </summary>
    public struct Dimension
    {
        private double minX, maxX;
        private double minY, maxY;

        /// <summary>
        /// Gets minimum value for x (left site) 
        /// </summary>
        public double MinimumX { get { return minX; } }
        /// <summary>
        /// Gets minimum value for y (bottom site)
        /// </summary>
        public double MinimumY { get { return minY; } }
        /// <summary>
        /// Gets maximum value for x (right site)
        /// </summary>
        public double MaximumX { get { return maxX; } }
        /// <summary>
        /// Gets maximum value for y (top site)
        /// </summary>
        public double MaximumY { get { return maxY; } }

        /// <summary>
        /// Gets the different of x borders
        /// </summary>
        public double XDifference { get { return Math.Abs(maxX - minX); } }
        /// <summary>
        /// Gets the difference of y borders
        /// </summary>
        public double YDifference { get { return Math.Abs(maxY - minY); } }

        public Dimension(double minX, double minY, double maxX, double maxY)
        {
            if (minX > maxX)
                throw new ArgumentException("maxX must be greater than minX!");
            if (minY > maxY)
                throw new ArgumentException("maxY must be greater than minY!");

            this.minX = minX;
            this.minY = minY;
            this.maxX = maxX;
            this.maxY = maxY;
        }

        public override bool Equals(object obj)
        {
            return EHCBuilder.Equals(this, obj);
        }

        public override int GetHashCode()
        {
            return EHCBuilder.GetHashCode(this);
        }

        public override string ToString()
        {
            return "[Minimum: " + minX + "x" + minY + "; Maximum: " + maxX + "x" + maxY + "]";
        }

        /// <summary>
        /// Check the value is between minimum x and maximum x
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns></returns>
        public bool IsBetweenXBorders(double value)
        {
            return value.IsBetween(MinimumX, MaximumX);
        }

        /// <summary>
        /// Check the value is between minimum y and maximum y
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns></returns>
        public bool IsBetweenYBorders(double value)
        {
            return value.IsBetween(MinimumY, MaximumY);
        }
    }

    /// @}
}
