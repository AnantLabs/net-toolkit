using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;
using System.Drawing;
using System.Windows.Media.Effects;

namespace NET.Tools
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Extensions for Images
    /// </summary>
    public static class ImageExtensions
    {
        /// <summary>
        /// Use an effect on this image
        /// </summary>
        /// <param name="img"></param>
        /// <param name="effect">The effect from the wpf-framework to use</param>
        /// <returns>A new System.Drawing.Image with the effect</returns>
        public static System.Drawing.Image UseEffect(this System.Drawing.Image img, Effect effect)
        {
            return img.ToBitmapSource().UseEffect(effect).ToBitmap();
        }

        /// <summary>
        /// Converts a System.Drawing.Bitmap to a Bitmap-Source
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static BitmapSource ToBitmapSource(this System.Drawing.Image img)
        {
            BitmapSource res = null;

            MemoryStream input = new MemoryStream();
            //using (MemoryStream input = new MemoryStream())
            //{
            img.Save(input, ImageFormat.Png);
            input.Seek(0, SeekOrigin.Begin);

            BitmapDecoder dec = new PngBitmapDecoder(input, BitmapCreateOptions.None, BitmapCacheOption.None);
            res = dec.Frames[0];
            //}

            return res;
        }

        /// <summary>
        /// Convert the image in a WPF-Image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="width">Width of new Image</param>
        /// <param name="height">Height of new Image</param>
        /// <returns>WPF-Image-Control</returns>
        public static System.Windows.Controls.Image ToWPFImage(this System.Drawing.Image image, int width, int height)
        {
            System.Windows.Controls.Image img = new System.Windows.Controls.Image();
            img.Width = width;
            img.Height = height;
            img.Source = image.ToBitmapSource();

            return img;
        }

        public static System.Drawing.Image GetThumbnailImage(this System.Drawing.Image img, double percent)
        {
            double width = img.Width, height = img.Height;

            Algorithm.Math.ToPercentSize(percent, ref width, ref height);

            return img.GetThumbnailImage((int)width, (int)height, null, IntPtr.Zero);
        }

        public static System.Drawing.Image GetThumbnailImage(this System.Drawing.Image img, int maxWidth, int maxHeight)
        {
            double width = img.Width, height = img.Height;

            Algorithm.Math.ToProportionalSize(maxWidth, maxHeight, ref width, ref height);

            return img.GetThumbnailImage((int)width, (int)height, null, IntPtr.Zero);
        }

        public static System.Drawing.Image Resize(this System.Drawing.Image img, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height, img.PixelFormat);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(img, new Rectangle(0, 0, width, height));
            }

            return bmp;
        }

        public static System.Drawing.Image ResizePercent(this System.Drawing.Image img, double percent)
        {
            double width = img.Width, height = img.Height;
            Algorithm.Math.ToPercentSize(percent, ref width, ref height);

            Bitmap bmp = new Bitmap((int)width, (int)height, img.PixelFormat);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(img, new Rectangle(0, 0, (int)width, (int)height));
            }

            return bmp;
        }

        public static System.Drawing.Image ResizeProportional(this System.Drawing.Image img, int maxWidth, int maxHeight)
        {
            double width = img.Width, height = img.Height;
            Algorithm.Math.ToProportionalSize(maxWidth, maxHeight, ref width, ref height);

            Bitmap bmp = new Bitmap((int)width, (int)height, img.PixelFormat);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(img, new Rectangle(0, 0, (int)width, (int)height));
            }

            return bmp;
        }

        /// <summary>
        /// Save the image to the given file and set the image format in depends on his extension
        /// </summary>
        /// <param name="filename">The file to save</param>
        /// <param name="image"></param>
        /// <exception cref="NotSupportedException">
        /// Is thrown if the filename extension is unknown
        /// </exception>
        public static void SaveDependsOnExt(this System.Drawing.Image image, String filename)
        {
            image.Save(filename, GetImageFormatFromExt(filename));
        }

        #region Private

        private static BitmapSource UseEffect(this BitmapSource source, Effect effect)
        {
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)source.Width,
                (int)source.Height, Math.Round(source.DpiX), Math.Round(source.DpiY),
                PixelFormats.Pbgra32);
            Border image = new Border();
            image.RenderSize = new System.Windows.Size(source.Width, source.Height);
            image.Background = new ImageBrush(source);
            image.Effect = effect;
            image.Measure(new System.Windows.Size(source.Width, source.Height));
            image.Arrange(new Rect(new System.Windows.Size(source.Width, source.Height)));
            bmp.Render(image);

            return BitmapFrame.Create(bmp);
        }

        private static System.Drawing.Image ToBitmap(this BitmapSource source)
        {
            System.Drawing.Image res = null;

            using (MemoryStream input = new MemoryStream())
            {
                BitmapEncoder enc = new PngBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(source));
                enc.Save(input);

                input.Seek(0, SeekOrigin.Begin);
                res = System.Drawing.Bitmap.FromStream(input);
            }

            return res;
        }

        private static ImageFormat GetImageFormatFromExt(String filename)
        {
            filename = filename.ToLower();

            if (filename.EndsWith(".bmp"))
                return ImageFormat.Bmp;
            else if (filename.EndsWith(".jpg") || filename.EndsWith(".jpeg"))
                return ImageFormat.Jpeg;
            else if (filename.EndsWith(".png"))
                return ImageFormat.Png;
            else if (filename.EndsWith(".ico"))
                return ImageFormat.Icon;
            else if (filename.EndsWith(".tif") || filename.EndsWith(".tiff"))
                return ImageFormat.Tiff;
            else if (filename.EndsWith(".gif"))
                return ImageFormat.Gif;
            else if (filename.EndsWith(".wmmf"))
                return ImageFormat.Wmf;
            else if (filename.EndsWith(".emf"))
                return ImageFormat.Emf;
            else
                throw new NotSupportedException("The extension is not supported!");
        }

        #endregion
    }
    /// @}
}
