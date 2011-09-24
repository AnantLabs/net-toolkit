using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class CharacterExtensions
    {
        public unsafe static IntPtr ToPointer(this char c)
        {
            return new IntPtr(&c);
        }

        public static byte[] ToBytes(this char c)
        {
            //Copy to pocharer
            IntPtr ptr = Marshal.AllocHGlobal(sizeof(char));
            Marshal.Copy(new char[] { c }, 0, ptr, 1);

            //Copy from pocharer to buffer
            byte[] buffer = new byte[sizeof(char)];
            Marshal.Copy(ptr, buffer, 0, sizeof(char));
            Marshal.FreeHGlobal(ptr);

            return buffer;
        }

        public static char FromBytes(this char c, byte[] buffer)
        {
            //Copy to pocharer
            IntPtr ptr = Marshal.AllocHGlobal(sizeof(char));
            Marshal.Copy(buffer, 0, ptr, sizeof(char));

            //Copy from pocharer to char
            char[] res = new char[1];
            Marshal.Copy(ptr, res, 0, 1);
            Marshal.FreeHGlobal(ptr);

            return res[0];
        }
    }
    /// @}
}
