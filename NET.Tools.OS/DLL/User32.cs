using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace NET.Tools.OS
{
    internal static class User32
    {
        public const int SOUND_ERROR = 0x00000010;
        public const int SOUND_INFO = 0x00000040;
        public const int SOUND_QUESTION = 0x00000020;
        public const int SOUND_WARN = 0x00000030;
        public const int SOUND_OK = 0x00000000;

        public const int ENUM_CURRENT_SETTINGS = -1;
        public const int CDS_UPDATEREGISTRY = 0x01;
        public const int CDS_TEST = 0x02;
        public const int CDS_FULLSCREEN = 0x04;
        public const int DISP_CHANGE_SUCCESSFUL = 0;
        public const int DISP_CHANGE_RESTART = 1;
        public const int DISP_CHANGE_FAILED = -1;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SystemParametersInfo(
            int uAction, int uParam, string lpvParam, int fuWinIni);
        [DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hwndLock);
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int MessageBeep(uint uType);
        [DllImport("user32.dll", EntryPoint = "MessageBox", CharSet = CharSet.Auto)]
        public static extern int MessageBox(int hwnd, String text, String caption, uint type);
        [DllImport("user32.dll")]
        public static extern IntPtr LoadCursorFromFile(String file);
        [DllImport("user32.dll")]
        public static extern int ChangeDisplaySettings(ref DevMode mode, int dwFlags);
        [DllImport("user32.dll")]
        public static extern int EnumDisplaySettings(string deviceName, int modeNum, ref DevMode devMode);
        [DllImport("user32.dll")]
        public static extern int ShowCursor(bool show);
        [DllImport("user32.dll")]
        public static extern bool ClipCursor(ref NativeRect lpRect);
        [DllImport("user32.dll")]
        public static extern bool GetClipCursor(out NativeRect lpRect);
        [DllImport("user32.dll")]
        public static extern bool SetSystemCursor(IntPtr hCursor, uint id);
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out NativePoint lpPoint);
        [DllImport("user32.dll")]
        public static extern bool SetCaretBlinkTime(uint mSec);
        [DllImport("user32.dll")]
        public static extern uint GetCaretBlinkTime();
    }
}
