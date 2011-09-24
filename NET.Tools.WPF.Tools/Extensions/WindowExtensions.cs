using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace NET.Tools
{
    /// <summary>
    /// Window Extensions
    /// 
    /// Contains this tool methods:
    /// - Windows 7 TaskBar Control
    /// </summary>
    public static class WindowExtensions
    {
        /// <summary>
        /// Gets the GetHandle() of this WPF window
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        public static IntPtr GetHandle(this Window window)
        {
            return new WindowInteropHelper(window).Handle;
        }
    }
}
