using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace NET.Tools.OS
{
    internal static class Kernel32
    {
        [DllImport("kernel32.dll",EntryPoint="ReadConsoleInputW",CharSet=CharSet.Unicode)]
        public static extern bool ReadConsoleInput(IntPtr hwnd, [Out] NativeInput[] buffer, uint legnth, out uint numberOfEventsRead);
        [DllImport("Kernel32.dll")]
        public static extern IntPtr GetStdHandle(uint stdHandle);
    }
}
