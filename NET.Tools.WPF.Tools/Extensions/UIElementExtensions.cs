using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class UIElementExtensions
    {
        public static void Refresh(this UIElement element)
        {
            element.Dispatcher.Invoke(new Action(() => { }), null);
        }

        public static void Invoke(this UIElement element, Action action)
        {
            element.Dispatcher.Invoke(action, null);
        }

        public static T Invoke<T>(this UIElement element, Func<T> action)
        {
            return (T)element.Dispatcher.Invoke(action, null);
        }

        #region Save

        public static void SaveAsImage(this UIElement element, Stream stream, BitmapEncoding encoding, BitmapMetadata metadata, int width, int height, double dpiX, double dpiY, PixelFormat pixelFormat)
        {
            element.Measure(new Size(width, height));
            element.Arrange(new Rect(new Size(width, height)));

            RenderTargetBitmap bitmap = new RenderTargetBitmap(
                width, height, dpiX, dpiY, pixelFormat);
            bitmap.Render(element);

            bitmap.Save(stream, encoding, metadata);
        }

        public static void SaveAsImage(this UIElement element, Stream stream, BitmapEncoding encoding, int width, int height, double dpiX, double dpiY, PixelFormat pixelFormat)
        {
            SaveAsImage(element, stream, encoding, null, width, height, dpiX, dpiY, pixelFormat);
        }

        public static void SaveAsImage(this UIElement element, Stream stream, BitmapEncoding encoding, BitmapMetadata metadata, int width, int height, double dpiX, double dpiY)
        {
            SaveAsImage(element, stream, encoding, metadata, width, height, dpiX, dpiY, PixelFormats.Pbgra32);
        }

        public static void SaveAsImage(this UIElement element, Stream stream, BitmapEncoding encoding, int width, int height, double dpiX, double dpiY)
        {
            SaveAsImage(element, stream, encoding, null, width, height, dpiX, dpiY);
        }

        public static void SaveAsImage(this UIElement element, Stream stream, BitmapEncoding encoding, int width, int height)
        {
            SaveAsImage(element, stream, encoding, width, height, 96d, 96d);
        }

        #endregion
    }
    /// @}
}
