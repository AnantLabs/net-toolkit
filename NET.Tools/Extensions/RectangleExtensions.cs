using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class RectangleExtensions
    {
        /// <summary>
        /// Verifies that all points are in the rect
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="p">List of points to check</param>
        /// <returns></returns>
        public static bool IsPointInRect(this Rectangle rect, params Point[] p)
        {
            for (int i = 0; i < p.Length; i++)
                if (!Algorithm.Logic.IsPointInRect(p[i].X, p[i].Y,
                    rect.Left, rect.Top, rect.Width, rect.Height))
                    return false;

            return true;
        }

        /// <summary>
        /// Verifies that all rects are in the given rect
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="r">List of rectangles to check</param>
        /// <returns></returns>
        public static bool IsRectInRect(this Rectangle rect, params Rectangle[] r)
        {
            for (int i = 0; i < r.Length; i++)
                if (!Algorithm.Logic.IsRectInRect(rect.Left, rect.Top, rect.Width, rect.Height,
                    r[i].Left, r[i].Top, r[i].Width, r[i].Height))
                    return false;

            return true;
        }

        /// <summary>
        /// Gets the Location at point right / bottom
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static Point GetBottomRight(this Rectangle rect)
        {
            return new Point(rect.Right, rect.Bottom);
        }

        public static System.Windows.Rect ToWPFRect(this Rectangle rect)
        {
            return new System.Windows.Rect(
                rect.X, rect.Y,
                rect.Width, rect.Height);
        }
    }
    /// @}
}
