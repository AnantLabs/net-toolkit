using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace NET.Tools.OS
{
    internal static class Avifil32
    {
        [DllImport("avifil32.dll")]
        public static extern void AVIFileInit();
        [DllImport("avifil32.dll")]
        public static extern void AVIFileExit();

        [DllImport("avifil32.dll")]
        public static extern int AVIFileOpen(out IntPtr ppFile, string szFile, uint mode, int pclsidHandler);
        [DllImport("avifil32.dll")]
        public static extern void AVIFileRelease(IntPtr pFile);

        //[DllImport("avifil32.dll")]
        //public static extern int AVIFileCreateStream(IntPtr pFile, ref int ppAVI, ref );
    }
}
