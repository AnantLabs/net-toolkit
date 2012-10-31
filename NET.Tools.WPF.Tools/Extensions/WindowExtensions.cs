using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        /// <summary>
        /// Run the action after window is completely loading
        /// </summary>
        /// <param name="window"></param>
        /// <param name="action">Action to do after loading is completed (thread safe)</param>
        public static void RunAfterLoad(this Window window, Action action)
        {
            new Thread(() =>
                {
                    while ((bool)window.Dispatcher.Invoke(new Func<bool>(() => !window.IsLoaded)))
                    {
                        Thread.Sleep(10);
                    }

                    window.Dispatcher.Invoke(action);
                }).Start();
        }
    }
}
