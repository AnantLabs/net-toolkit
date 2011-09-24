using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace NET.Tools
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Extensions for character arrays
    /// </summary>
    public static class CharacterArrayExtensions
    {
        public static byte[] ToByteArray(this char[] array)
        {
            IntPtr ptr = Marshal.AllocHGlobal(sizeof(char) * array.Length);
            Marshal.Copy(array, 0, ptr, array.Length);

            byte[] buffer = new byte[sizeof(char) * array.Length];
            Marshal.Copy(ptr, buffer, 0, sizeof(char) * array.Length);
            Marshal.FreeHGlobal(ptr);

            return buffer;
        }
    }

    /// @}
}
