using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace NET.Tools.OS
{
    /// <summary>
    /// Constants for all COM Actions
    /// </summary>
    public static class COMConstants
    {
        [DllImport("user32.dll", EntryPoint = "RegisterWindowMessage", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern uint RegisterWindowMessage([MarshalAs(UnmanagedType.LPWStr)] string lpString);

        public static class COMCommands
        {
            private static readonly uint wmTaskbarButtonCreated = RegisterWindowMessage("TaskbarButtonCreated");
            public static uint WmTaskbarButtonCreated { get { return wmTaskbarButtonCreated; } }

            public const int WmCommand = 0x0111;
        }

        public static class COMInput
        {
            public static class COMMouse
            {
                public const int Clicked = 0x1800;
            }
        }
    }
}
