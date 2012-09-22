using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace NET.Tools.OS
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Extensions for window (WPF) for Windows 7 taskbar tools
    /// </summary>
    public static class WindowExtensions
    {
        public static void SetTaskBarProgressStyle(this Window win, TaskbarProgressBarStyle style)
        {
            Windows7TaskBar.SetProgressStyle(win.GetHandle(), style);
        }

        public static void SetTaskBarProgressValue(this Window win, ulong value, ulong max)
        {
            Windows7TaskBar.SetProgressValue(win.GetHandle(), value, max);
        }

        public static void SetThumbnailToolTip(this Window win, string tooltip)
        {
            Windows7TaskBar.SetThumbnailToolTip(win.GetHandle(), tooltip);
        }

        public static void SetThumbnailClip(this Window win, Rect rect)
        {
            Windows7TaskBar.SetThumbnailClip(win.GetHandle(), (rect == Rect.Empty ? (NativeRect?)null : rect));
        }

        public static void SetOverlayIcon(this Window win, BitmapSource icon, string description)
        {
            Windows7TaskBar.SetOverlayIcon(win.GetHandle(), icon.ToIcon().Handle, description);
        }
    }

    /// @}
}
