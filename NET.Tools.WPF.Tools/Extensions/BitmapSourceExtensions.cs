using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Media.Effects;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class BitmapSourceExtensions
    {
        /// <summary>
        /// Convert a Bitmap-Source to a System.Drawing.Bitmap
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static System.Drawing.Image ToBitmap(this BitmapSource source)
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

        /// <summary>
        /// Convert a Bitmap-Source to a System.Drawing.Icon
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static System.Drawing.Icon ToIcon(this BitmapSource source)
        {
            return System.Drawing.Icon.FromHandle(
                (source.ToBitmap() as System.Drawing.Bitmap).GetHicon());
        }

        /// <summary>
        /// Rotate or / and Flip the bitmap source to a new source
        /// </summary>
        /// <param name="source"></param>
        /// <param name="type">RoateFlipType</param>
        /// <returns></returns>
        public static BitmapSource RotateFlip(this BitmapSource source, System.Drawing.RotateFlipType type)
        {
            System.Drawing.Image img = source.ToBitmap();
            img.RotateFlip(type);
            return img.ToBitmapSource();
        }

        public static BitmapSource UseEffect(this BitmapSource source, Effect effect, double dpiX, double dpiY)
        {
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)source.PixelWidth, 
                (int)source.PixelHeight, dpiX, dpiY, 
                PixelFormats.Pbgra32);
            Border image = new Border();
            image.RenderSize = new Size(source.Width, source.Height);
            image.Background = new ImageBrush(source);
            image.Effect = effect;
            image.Measure(new Size(source.Width, source.Height));
            image.Arrange(new Rect(new Size(source.Width, source.Height)));
            bmp.Render(image);

            return BitmapFrame.Create(bmp);
        }

        public static BitmapSource UseEffect(this BitmapSource source, Effect effect)
        {
            return UseEffect(source, effect, source.DpiX, source.DpiY);
        }

        /// <summary>
        /// Create an effect on a bitmap source
        /// </summary>
        /// <param name="source"></param>
        /// <param name="effect">The effect</param>
        /// <param name="visual">A visual to get the dpi from it</param>
        /// <returns>bitmap source with effect</returns>
        public static BitmapSource UseEffect(this BitmapSource source, Effect effect, Visual visual)
        {
            Matrix mat = PresentationSource.FromVisual(visual).CompositionTarget.TransformToDevice;
            return UseEffect(source, effect, mat.M11, mat.M22);
        }

        public static BitmapSource GetThumbnailImage(this BitmapSource source, double percent, double dpiX, double dpiY)
        {
            double width = source.PixelWidth, height = source.PixelHeight;

            Algorithm.Math.ToPercentSize(percent, ref width, ref height);

            RenderTargetBitmap bmp = new RenderTargetBitmap((int)width, (int)height,
                dpiX, dpiY, PixelFormats.Pbgra32);
            Border image = new Border();
            image.RenderSize = new Size(width, height);
            image.Background = new ImageBrush(source);
            image.Measure(new Size(width, height));
            image.Arrange(new Rect(new Size(width, height)));
            bmp.Render(image);
     
            return BitmapFrame.Create(bmp);
        }

        public static BitmapSource GetThumbnailImage(this BitmapSource source, double percent)
        {
            return GetThumbnailImage(source, percent, source.DpiX, source.DpiY);
        }

        /// <summary>
        /// Create a thumbnail with the percent from the original image
        /// </summary>
        /// <param name="source"></param>
        /// <param name="percent">Percent</param>
        /// <param name="visual">A visual to get the dpi from it</param>
        /// <returns>Thumbnail image</returns>
        public static BitmapSource GetThumbnailImage(this BitmapSource source, double percent, Visual visual)
        {
            Matrix mat = PresentationSource.FromVisual(visual).CompositionTarget.TransformToDevice;
            return GetThumbnailImage(source, percent, mat.M11, mat.M22);
        }

        public static BitmapSource GetThumbnailImage(this BitmapSource source, int maxWidth, int maxHeight, double dpiX, double dpiY)
        {
            double pixelWidth = source.PixelWidth, pixelHeight = source.PixelHeight;

            Algorithm.Math.ToProportionalSize(maxWidth, maxHeight, ref pixelWidth, ref pixelHeight);

            RenderTargetBitmap bmp = new RenderTargetBitmap((int)pixelWidth, (int)pixelHeight,
                dpiX, dpiY, PixelFormats.Pbgra32);
            Border image = new Border();
            image.RenderSize = new Size(pixelWidth, pixelHeight);
            image.Background = new ImageBrush(source);
            image.Measure(new Size(pixelWidth, pixelHeight));
            image.Arrange(new Rect(new Size(pixelWidth, pixelHeight)));
            bmp.Render(image);

            return BitmapFrame.Create(bmp);
        }

        public static BitmapSource GetThumbnailImage(this BitmapSource source, int maxWidth, int maxHeight)
        {
            return GetThumbnailImage(source, maxWidth, maxHeight, source.DpiX, source.DpiY);
        }

        /// <summary>
        /// Create a thumbnail with the maximum dimension in uniform mode
        /// </summary>
        /// <param name="source"></param>
        /// <param name="maxWidth">Maximum width</param>
        /// <param name="maxHeight">Maximum height</param>
        /// <param name="visual">A visual to get the dpi from it</param>
        /// <returns>Thumbnail image</returns>
        public static BitmapSource GetThumbnailImage(this BitmapSource source, int maxWidth, int maxHeight, Visual visual)
        {
            Matrix mat = PresentationSource.FromVisual(visual).CompositionTarget.TransformToDevice;
            return GetThumbnailImage(source, maxWidth, maxHeight, mat.M11, mat.M22);
        }

        public static BitmapSource GetThumbnailImage(this BitmapSource source, int width, int height, double dpiX, double dpiY,
            System.Drawing.Image.GetThumbnailImageAbort callback, IntPtr callbackData)
        {
            RenderTargetBitmap bmp = new RenderTargetBitmap(width, height,
                dpiX, dpiY, PixelFormats.Pbgra32);
            Border image = new Border();
            image.RenderSize = new Size(width, height);
            image.Background = new ImageBrush(source);
            image.Measure(new Size(width, height));
            image.Arrange(new Rect(new Size(width, height)));
            bmp.Render(image);

            return BitmapFrame.Create(bmp);
        }

        public static BitmapSource GetThumbnailImage(this BitmapSource source, int width, int height,
            System.Drawing.Image.GetThumbnailImageAbort callback, IntPtr callbackData)
        {
            return GetThumbnailImage(source, width, height, source.DpiX, source.DpiY, callback, callbackData);
        }

        /// <summary>
        /// Create a thumbnail with the given width and height (stretch)
        /// </summary>
        /// <param name="source"></param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <param name="callback"></param>
        /// <param name="callbackData"></param>
        /// <param name="visual">A visual to get the dpi from it</param>
        /// <returns>Thumbnail image</returns>
        public static BitmapSource GetThumbnailImage(this BitmapSource source, int width, int height, Visual visual,
            System.Drawing.Image.GetThumbnailImageAbort callback, IntPtr callbackData)
        {
            Matrix mat = PresentationSource.FromVisual(visual).CompositionTarget.TransformToDevice;
            return GetThumbnailImage(source, width, height, mat.M11, mat.M22, callback, callbackData);
        }

        public static void Save(this BitmapSource source, Stream stream, BitmapEncoding enc, BitmapMetadata data)
        {
            BitmapEncoder encorder = null;

            switch (enc)
            {
                case BitmapEncoding.Bmp:
                    encorder = new BmpBitmapEncoder();
                    break;
                case BitmapEncoding.Png:
                    encorder = new PngBitmapEncoder();
                    break;
                case BitmapEncoding.Jpg:
                    encorder = new JpegBitmapEncoder();
                    break;
                case BitmapEncoding.Tiff:
                    encorder = new TiffBitmapEncoder();
                    break;
                case BitmapEncoding.Gif:
                    encorder = new GifBitmapEncoder();
                    break;
                case BitmapEncoding.Wmp:
                    encorder = new WmpBitmapEncoder();
                    break;
                case BitmapEncoding.Icon:
                    throw new NotSupportedException("The icon format can only load!");
                default:
                    throw new NotImplementedException();
            }

            encorder.Frames.Add(BitmapFrame.Create(source));
            if (data != null)
                encorder.Metadata = data;
            encorder.Save(stream);
        }

        public static void Save(this BitmapSource source, Stream stream, BitmapEncoding enc)
        {
            Save(source, stream, enc, null);
        }

        public static void Save(this BitmapSource source, Stream stream)
        {
            Save(source, stream, BitmapEncoding.Png);
        }

        public static void Save(this BitmapSource source, Stream stream, BitmapMetadata data)
        {
            Save(source, stream, BitmapEncoding.Png, data);
        }

        public static void Save(this BitmapSource source, String fileName, BitmapEncoding enc, BitmapMetadata data)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                Save(source, stream, enc, data);
            }
        }

        public static void Save(this BitmapSource source, String fileName, BitmapEncoding enc)
        {
            Save(source, fileName, enc, null);
        }

        public static void Save(this BitmapSource source, String fileName)
        {
            Save(source, fileName, GetEncodingFromExt(fileName));
        }

        public static void Save(this BitmapSource source, String fileName, BitmapMetadata data)
        {
            Save(source, fileName, GetEncodingFromExt(fileName), data);
        }

        private static BitmapSource Load(object obj, BitmapEncoding enc, 
            BitmapCreateOptions create, BitmapCacheOption cache, out BitmapMetadata data)
        {
            BitmapDecoder dec = null;

            if (obj is Stream)
            {
                Stream stream = obj as Stream;

                switch (enc)
                {
                    case BitmapEncoding.Bmp:
                        dec = new BmpBitmapDecoder(stream, create, cache);
                        break;
                    case BitmapEncoding.Png:
                        dec = new PngBitmapDecoder(stream, create, cache);
                        break;
                    case BitmapEncoding.Jpg:
                        dec = new JpegBitmapDecoder(stream, create, cache);
                        break;
                    case BitmapEncoding.Tiff:
                        dec = new TiffBitmapDecoder(stream, create, cache);
                        break;
                    case BitmapEncoding.Gif:
                        dec = new GifBitmapDecoder(stream, create, cache);
                        break;
                    case BitmapEncoding.Wmp:
                        dec = new WmpBitmapDecoder(stream, create, cache);
                        break;
                    case BitmapEncoding.Icon:
                        dec = new IconBitmapDecoder(stream, create, cache);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            else if (obj is Uri)
            {
                Uri stream = obj as Uri;

                switch (enc)
                {
                    case BitmapEncoding.Bmp:
                        dec = new BmpBitmapDecoder(stream, create, cache);
                        break;
                    case BitmapEncoding.Png:
                        dec = new PngBitmapDecoder(stream, create, cache);
                        break;
                    case BitmapEncoding.Jpg:
                        dec = new JpegBitmapDecoder(stream, create, cache);
                        break;
                    case BitmapEncoding.Tiff:
                        dec = new TiffBitmapDecoder(stream, create, cache);
                        break;
                    case BitmapEncoding.Gif:
                        dec = new GifBitmapDecoder(stream, create, cache);
                        break;
                    case BitmapEncoding.Wmp:
                        dec = new WmpBitmapDecoder(stream, create, cache);
                        break;
                    case BitmapEncoding.Icon:
                        dec = new IconBitmapDecoder(stream, create, cache);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            else
                throw new ArgumentException();

            data = dec.Metadata;
            return dec.Frames[0];
        }

        public static BitmapSource Load(this BitmapSource source, Stream stream, BitmapEncoding enc,
            BitmapCreateOptions create, BitmapCacheOption cache, out BitmapMetadata data)
        {
            return Load(stream, enc, create, cache, out data);
        }

        public static BitmapSource Load(this BitmapSource source, Stream stream, BitmapEncoding enc,
            out BitmapMetadata data)
        {
            return Load(source, stream, enc, BitmapCreateOptions.None, BitmapCacheOption.None, out data);
        }

        public static BitmapSource Load(this BitmapSource source, Stream stream, BitmapEncoding enc)
        {
            BitmapMetadata tmp;
            return Load(source, stream, enc, out tmp);
        }

        public static BitmapSource Load(this BitmapSource source, Stream stream)
        {
            return Load(source, stream, BitmapEncoding.Png);
        }

        public static BitmapSource Load(this BitmapSource source, String fileName, BitmapEncoding enc,
            BitmapCreateOptions create, BitmapCacheOption cache, out BitmapMetadata data)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                return Load(source, stream, enc, create, cache, out data);
            }
        }

        public static BitmapSource Load(this BitmapSource source, String fileName, BitmapEncoding enc,
            out BitmapMetadata data)
        {
            return Load(source, fileName, enc, BitmapCreateOptions.None, BitmapCacheOption.None, out data);
        }

        public static BitmapSource Load(this BitmapSource source, String fileName, BitmapEncoding enc)
        {
            BitmapMetadata tmp;
            return Load(source, fileName, enc, out tmp);
        }

        public static BitmapSource Load(this BitmapSource source, String fileName)
        {
            return Load(source, fileName, BitmapEncoding.Png);
        }

        public static BitmapSource Load(this BitmapSource source, Uri uri, BitmapEncoding enc,
            BitmapCreateOptions create, BitmapCacheOption cache, out BitmapMetadata data)
        {
            return Load(uri, enc, create, cache, out data);
        }

        public static BitmapSource Load(this BitmapSource source, Uri uri, BitmapEncoding enc,
            out BitmapMetadata data)
        {
            return Load(source, uri, enc, BitmapCreateOptions.None, BitmapCacheOption.None, out data);
        }

        public static BitmapSource Load(this BitmapSource source, Uri uri, BitmapEncoding enc)
        {
            BitmapMetadata tmp;
            return Load(source, uri, enc, out tmp);
        }

        public static BitmapSource Load(this BitmapSource source, Uri uri)
        {
            return Load(source, uri, BitmapEncoding.Png);
        }

        public static void SaveGIF(this BitmapSource source, Stream stream, BitmapMetadata data, params BitmapSource[] additionals)
        {
            BitmapEncoder enc = new GifBitmapEncoder();
            enc.Frames.Add(BitmapFrame.Create(source));
            foreach(BitmapSource bs in additionals)
                enc.Frames.Add(BitmapFrame.Create(bs));
            if (data != null)
                enc.Metadata = data;
            enc.Save(stream);
        }

        public static void SaveGIF(this BitmapSource source, Stream stream, params BitmapSource[] additionals)
        {
            SaveGIF(source, stream, null, additionals);
        }

        public static void SaveGIF(this BitmapSource source, String fileName, BitmapMetadata data, params BitmapSource[] additionals)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                SaveGIF(source, stream, data, additionals);
            }
        }

        public static void SaveGIF(this BitmapSource source, String fileName, params BitmapSource[] additionals)
        {
            SaveGIF(source, fileName, null, additionals);
        }

        public static BitmapSource[] OpenGIF(this BitmapSource source, Stream stream,
            BitmapCreateOptions create, BitmapCacheOption cache, out BitmapMetadata data)
        {
            BitmapDecoder dec = new GifBitmapDecoder(stream, create, cache);
            data = dec.Metadata;
            return dec.Frames.ToArray();
        }

        public static BitmapSource[] OpenGIF(this BitmapSource source, Stream stream,
            out BitmapMetadata data)
        {
            return OpenGIF(source, stream, BitmapCreateOptions.None, BitmapCacheOption.None, out data);
        }

        public static BitmapSource[] OpenGIF(this BitmapSource source, Stream stream)
        {
            BitmapMetadata tmp;
            return OpenGIF(source, stream, out tmp);
        }

        public static BitmapSource[] OpenGIF(this BitmapSource source, String fileName,
            BitmapCreateOptions create, BitmapCacheOption cache, out BitmapMetadata data)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                return OpenGIF(source, stream, create, cache, out data);
            }
        }

        public static BitmapSource[] OpenGIF(this BitmapSource source, String fileName,
            out BitmapMetadata data)
        {
            return OpenGIF(source, fileName, BitmapCreateOptions.None, BitmapCacheOption.None, out data);
        }

        public static BitmapSource[] OpenGIF(this BitmapSource source, String fileName)
        {
            BitmapMetadata tmp;
            return OpenGIF(source, fileName, out tmp);
        }

        public static BitmapSource[] OpenGIF(this BitmapSource source, Uri uri,
            BitmapCreateOptions create, BitmapCacheOption cache, out BitmapMetadata data)
        {
            BitmapDecoder dec = new GifBitmapDecoder(uri, create, cache);
            data = dec.Metadata;
            return dec.Frames.ToArray();
        }

        public static BitmapSource[] OpenGIF(this BitmapSource source, Uri uri,
            out BitmapMetadata data)
        {
            return OpenGIF(source, uri, BitmapCreateOptions.None, BitmapCacheOption.None, out data);
        }

        public static BitmapSource[] OpenGIF(this BitmapSource source, Uri uri)
        {
            BitmapMetadata tmp;
            return OpenGIF(source, uri, out tmp);
        }

        #region Private

        private static BitmapSource ToBitmapSource(this System.Drawing.Image img)
        {
            BitmapSource res = null;

            MemoryStream input = new MemoryStream();
            //using (MemoryStream input = new MemoryStream())
            //{
            img.Save(input, System.Drawing.Imaging.ImageFormat.Png);
            input.Seek(0, SeekOrigin.Begin);

            BitmapDecoder dec = new PngBitmapDecoder(input, BitmapCreateOptions.None, BitmapCacheOption.None);
            res = dec.Frames[0];
            //}

            return res;
        }

        private static BitmapEncoding GetEncodingFromExt(String fileName)
        {
            if (fileName.ToLower().EndsWith(".jpg"))
                return BitmapEncoding.Jpg;
            else if (fileName.ToLower().EndsWith(".png"))
                return BitmapEncoding.Png;
            else if (fileName.ToLower().EndsWith(".bmp"))
                return BitmapEncoding.Bmp;
            else if (fileName.ToLower().EndsWith(".gif"))
                return BitmapEncoding.Gif;
            else if (fileName.ToLower().EndsWith(".ico"))
                return BitmapEncoding.Icon;
            else if (fileName.ToLower().EndsWith(".tiff"))
                return BitmapEncoding.Tiff;
            else if (fileName.ToLower().EndsWith(".wmp"))
                return BitmapEncoding.Wmp;
            else
                return BitmapEncoding.Png;
        }

        #endregion
    }
    /// @}

    /// <summary>
    /// \addtogroup enums
    /// @{
    /// </summary>
    public enum BitmapEncoding
    {
        Bmp,
        Png,
        Jpg,
        Tiff,
        Gif,
        Wmp,
        Icon
    }
    /// @}
}
