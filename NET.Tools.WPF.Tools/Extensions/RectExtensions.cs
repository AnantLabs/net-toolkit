using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class RectExtensions
    {
        /// <summary>
        /// Verifies that all points are in the rect
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="p">List of points to check</param>
        /// <returns></returns>
        public static bool IsPointInRect(this Rect rect, params Point[] p)
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
        public static bool IsRectInRect(this Rect rect, params Rect[] r)
        {
            for (int i = 0; i < r.Length; i++)
                if (!Algorithm.Logic.IsRectInRect(rect.Left, rect.Top, rect.Width, rect.Height, 
                    r[i].Left, r[i].Top, r[i].Width, r[i].Height))
                    return false;

            return true;
        }

        public static System.Drawing.Rectangle ToDrawingRectangle(this Rect rect)
        {
            return new System.Drawing.Rectangle(
                (int)rect.X, (int)rect.Y, 
                (int)rect.Width, (int)rect.Height);
        }

        public static System.Drawing.RectangleF ToDrawingRectangleF(this Rect rect)
        {
            return new System.Drawing.RectangleF(
                (float)rect.X, (float)rect.Y,
                (float)rect.Width, (float)rect.Height);
        }
    }
    /// @}
}
