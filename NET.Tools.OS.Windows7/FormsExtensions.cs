using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace NET.Tools.OS
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Forms extensions for windows 7 taskbar tools
    /// </summary>
    public static class FormsExtensions
    {
        public static void SetTaskBarProgressStyle(this Form form, TaskbarProgressBarStyle style)
        {
            Windows7TaskBar.SetProgressStyle(form.Handle, style);
        }

        public static void SetTaskBarProgressValue(this Form form, ulong value, ulong max)
        {
            Windows7TaskBar.SetProgressValue(form.Handle, value, max);
        }

        public static void SetThumbnailToolTip(this Form form, string tooltip)
        {
            Windows7TaskBar.SetThumbnailToolTip(form.Handle, tooltip);
        }

        public static void SetThumbnailClip(this Form form, Rectangle rect)
        {
            Windows7TaskBar.SetThumbnailClip(form.Handle, (rect == Rectangle.Empty ? (NativeRect?)null : rect));
        }

        public static void SetOverlayIcon(this Form form, Icon icon, string description)
        {
            Windows7TaskBar.SetOverlayIcon(form.Handle, icon.Handle, description);
        }
    }

    /// @}
}
