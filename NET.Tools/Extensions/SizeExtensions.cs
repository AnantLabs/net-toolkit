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
    public static class SizeExtensions
    {
        public static System.Windows.Size ToWPFSize(this Size size)
        {
            return new System.Windows.Size(size.Width, size.Height);
        }

        public static Size ToProportionalSize(this Size size, int maxWidth, int maxHeight)
        {
            double width = size.Width, height = size.Height;

            Algorithm.Math.ToProportionalSize(maxWidth, maxHeight, ref width, ref height);

            return new Size((int)width, (int)height);
        }

        public static Size ToPercentSize(this Size size, double percent)
        {
            double width = size.Width, height = size.Height;

            Algorithm.Math.ToPercentSize(percent, ref width, ref height);

            return new Size((int)width, (int)height);
        }
    }
    /// @}
}
