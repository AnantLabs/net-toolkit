using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace NET.Tools.WPF.Dialogs
{
    internal static class User32Net
    {
        #region External Import
        [DllImport("user32", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int MessageBeep(int uType);
        public const int SOUND_ERROR = 0x00000010;
        public const int SOUND_INFO = 0x00000040;
        public const int SOUND_QUESTION = 0x00000020;
        public const int SOUND_WARN = 0x00000030;
        public const int SOUND_OK = 0x00000000;
        #endregion
    }
}
