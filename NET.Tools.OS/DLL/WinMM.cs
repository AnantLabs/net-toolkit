using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace NET.Tools.OS
{
    public static class WinMM
    {
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern bool PlaySound(string pszSound, UIntPtr hMode, uint fdwSound);
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern bool PlaySound(byte[] pszSound, UIntPtr hMode, uint fdwSound);
    }
}
