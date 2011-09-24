using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class ByteArrayExtensions
    {
        public static String ToBase64String(this byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        public static String ToHexString(this byte[] bytes)
        {
            String res = "";

            foreach (byte b in bytes)
            {
                res += b.ToString("x").PadLeft(2,'0');
            }

            return res;
        }

        public static byte[] EncodeWithMD5(this byte[] bytes)
        {
            MD5 md5 = MD5.Create();
            return md5.ComputeHash(bytes);
        }

        public static byte[] EncodeWithMD5(this byte[] bytes, int off, int count)
        {
            MD5 md5 = MD5.Create();
            return md5.ComputeHash(bytes, off, count);
        }

        public static byte[] EncodeWithSHA1(this byte[] bytes)
        {
            SHA1 sha1 = SHA1.Create();
            return sha1.ComputeHash(bytes);
        }

        public static byte[] EncodeWithSHA1(this byte[] bytes, int off, int count)
        {
            SHA1 sha1 = SHA1.Create();
            return sha1.ComputeHash(bytes, off, count);
        }

        public static long GetCheckSum(this byte[] bytes)
        {
            long counter = 0;

            foreach (byte b in bytes)
                counter += b;

            return counter;
        }

        public static char[] ToCharacterArray(this byte[] buf)
        {
            byte[] buffer = null;
            if (buf.Length % 2 != 0) //Check for odd
            {
                buffer = new byte[buf.Length + 1];
                buffer[buffer.Length - 1] = 0;
            }
            else
                buffer = new byte[buf.Length];
            buf.CopyTo(buffer, 0);

            IntPtr ptr = Marshal.AllocHGlobal(sizeof(byte) * buffer.Length);
            Marshal.Copy(buffer, 0, ptr, sizeof(byte) * buffer.Length);

            char[] array = new char[(sizeof(byte) * buffer.Length) / sizeof(char)];
            Marshal.Copy(ptr, array, 0, (sizeof(byte) * buffer.Length) / sizeof(char));
            Marshal.FreeHGlobal(ptr);

            return array;
        }
    }
    /// @}
}
