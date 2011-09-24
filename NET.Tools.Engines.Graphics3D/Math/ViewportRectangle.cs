using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Represent a viewport rectangle
    /// </summary>
    public struct ViewportRectangle
    {
        private double x1, y1, x2, y2;

        /// <summary>
        /// Left position of the viewport
        /// </summary>
        public double X1 { get { return x1; } }
        /// <summary>
        /// Right position of the viewport
        /// </summary>
        public double X2 { get { return x2; } }
        /// <summary>
        /// Top position of teh viewport
        /// </summary>
        public double Y1 { get { return y1; } }
        /// <summary>
        /// Bottom position of the viewport
        /// </summary>
        public double Y2 { get { return y2; } }

        public ViewportRectangle(double x1, double y1, double x2, double y2)
        {
            if ((x1 < 0) || (x1 > 1) || (x2 < 0) || (x2 > 1) ||
                (y1 < 0) || (y1 > 1) || (y2 < 0) || (y2 > 1))
                throw new ArgumentException("All values must be between 0 and 1!");

            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }
    }

    /// @}
}
