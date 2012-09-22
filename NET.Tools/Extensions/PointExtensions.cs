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
    public static class PointExtensions
    {
        /// <summary>
        /// Verifies that the point is in all rects
        /// </summary>
        /// <param name="p"></param>
        /// <param name="rect">Rectangle(s) to check</param>
        /// <returns>TRUE, if the point in all rectangles</returns>
        public static bool IsPointInRect(this Point p, params Rectangle[] rect)
        {
            for (int i = 0; i < rect.Length; i++)
                if (!Algorithm.Logic.IsPointInRect(p.X, p.Y, 
                    rect[i].Left, rect[i].Top, rect[i].Width, rect[i].Height))
                    return false;

            return true;
        }

        public static System.Windows.Point ToWPFPoint(this Point p)
        {
            return new System.Windows.Point(p.X, p.Y);
        }
    }
    /// @}
}
