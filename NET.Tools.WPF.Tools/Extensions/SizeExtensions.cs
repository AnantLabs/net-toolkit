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
    public static class SizeExtensions
    {
        public static System.Drawing.Size ToDrawingSize(this Size size)
        {
            return new System.Drawing.Size((int)size.Width, (int)size.Height);
        }

        public static System.Drawing.SizeF ToDrawingSizeF(this Size size)
        {
            return new System.Drawing.SizeF((float)size.Width, (float)size.Height);
        }

        public static Size ToProportionalSize(this Size size, int maxWidth, int maxHeight)
        {
            double width = size.Width, height = size.Height;

            Algorithm.Math.ToProportionalSize(maxWidth, maxHeight, ref width, ref height);

            return new Size(width, height);
        }

        public static Size ToPercentSize(this Size size, double percent)
        {
            double width = size.Width, height = size.Height;

            Algorithm.Math.ToPercentSize(percent, ref width, ref height);

            return new Size(width, height);
        }
    }
    /// @}
}
