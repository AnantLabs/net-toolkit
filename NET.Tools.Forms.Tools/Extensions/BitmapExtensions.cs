using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Controls;
using System.IO;
using System.Drawing.Imaging;
using System.Windows;

namespace NET.Tools
{
    /// \defgroup extensions Extensions
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Extensions for bitmaps
    /// </summary>
    public static class BitmapExtensions
    {
        public static Icon ToIcon(this Bitmap bmp)
        {
            return Icon.FromHandle(bmp.GetHicon());
        }

        /// <summary>
        /// Gets the average color. This process needs time
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns>The average color</returns>
        public static System.Drawing.Color GetAverageColor(this Bitmap bmp)
        {
            EditableImage img = new EditableImage(bmp);

            long r = 0, g = 0, b = 0;

            for(int y = 0; y < img.Height; y++)
                for (int x = 0; x < img.Width; x++)
                {
                    System.Drawing.Color color = img.GetPixel(x, y);

                    r += color.R;
                    g += color.G;
                    b += color.B;
                }

            long count = img.Width * img.Height;
            return System.Drawing.Color.FromArgb(
                (int)(r / count).PutInto(0, 255),
                (int)(g / count).PutInto(0, 255),
                (int)(b / count).PutInto(0, 255));
        }
    }
    /// @}
}
