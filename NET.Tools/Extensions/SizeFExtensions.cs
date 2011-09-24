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
    public static class SizeFExtensions
    {
        public static System.Windows.Size ToWPFSize(this SizeF size)
        {
            return new System.Windows.Size(size.Width, size.Height);
        }

        public static SizeF ToProportionalSize(this SizeF size, int maxWidth, int maxHeight)
        {
            double width = size.Width, height = size.Height;

            Algorithm.Math.ToProportionalSize(maxWidth, maxHeight, ref width, ref height);

            return new SizeF((float)width, (float)height);
        }

        public static SizeF ToPercentSize(this SizeF size, double percent)
        {
            double width = size.Width, height = size.Height;

            Algorithm.Math.ToPercentSize(percent, ref width, ref height);

            return new SizeF((float)width, (float)height);
        }
    }
    /// @}
}
