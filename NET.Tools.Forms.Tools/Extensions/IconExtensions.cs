using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace NET.Tools
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Extensions for icons
    /// </summary>
    public static class IconExtensions
    {
        /// <summary>
        /// Convert a System.Drawing-Icon to a Bitmap-Source
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static BitmapSource ToBitmapSource(this Icon icon)
        {
            return icon.ToBitmap().ToBitmapSource();
        }

        /// <summary>
        /// Rotate or Flip the icon
        /// </summary>
        /// <param name="icon"></param>
        /// <param name="type">RotateFlipType</param>
        /// <returns>The new rotated or flipped icon</returns>
        public static Icon RotateFlip(this Icon icon, RotateFlipType type)
        {
            Bitmap bmp = icon.ToBitmap();
            bmp.RotateFlip(type);
            return Icon.FromHandle(bmp.GetHicon());
        }

        /// <summary>
        /// Convert the icon in a WPF-Image
        /// </summary>
        /// <param name="icon"></param>
        /// <param name="width">Width of new Image</param>
        /// <param name="height">Height of new Image</param>
        /// <returns>WPF-Image-Control</returns>
        public static System.Windows.Controls.Image ToWPFImage(this Icon icon, int width, int height)
        {
            System.Windows.Controls.Image img = new System.Windows.Controls.Image();
            img.Width = width;
            img.Height = height;
            img.Source = icon.ToBitmapSource();

            return img;
        }
    }
    /// @}
}
