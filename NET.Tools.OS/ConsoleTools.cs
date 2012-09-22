using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.OS
{
    /// \addtogroup dlltools
    /// @{

    /// <summary>
    /// Contains tools for console
    /// </summary>
    public static class ConsoleTools
    {
        private const int MAXREADINPUT = 256;

        /// <summary>
        /// Gets the default cmd handle
        /// </summary>
        public static IntPtr CMDHandle { get; private set; }
        
        static ConsoleTools() {
            CMDHandle = Kernel32.GetStdHandle(0xFFFFFFFF - 9);
        }

        /// <summary>
        /// Gets or sets the blink tick of the console cursor line or block
        /// </summary>
        public static uint CaretBlinkTime
        {
            get
            {
                return User32.GetCaretBlinkTime();
            }
            set
            {
                if (!User32.SetCaretBlinkTime(value))
                    throw new ArgumentException("Invalid argument for mSec!");
            }
        }

        /// <summary>
        /// Read console input informations
        /// 
        /// This method can only called if the program is a console application!
        /// </summary>
        /// <returns></returns>
        public static IList<NativeInput> ReadConsoleInput()
        {
            NativeInput[] list = new NativeInput[MAXREADINPUT];
            IList<NativeInput> result = new List<NativeInput>();

            uint readed;
            Kernel32.ReadConsoleInput(CMDHandle, list, MAXREADINPUT, out readed);

            for (int i = 0; i < readed; i++)
                result.Add(list[i]);

            return result;
        }
    }
    /// @}
}
