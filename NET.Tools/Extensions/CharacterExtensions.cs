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
            return BitConverter.GetBytes(c);
        }

        public static char FromBytes(this char c, byte[] buffer, int startIndex)
        {
            return BitConverter.ToChar(buffer, startIndex);
        }

        public static char FromBytes(this char c, byte[] buffer)
        {
            return c.FromBytes(buffer, 0);
        }

        public static String ToString(this char value, IntegerStringFormatType type)
        {
            switch (type)
            {
                case IntegerStringFormatType.ToHexBinary:
                    return Convert.ToString(value, 16);
                case IntegerStringFormatType.ToDecimal:
                    return Convert.ToString(value, 10);
                case IntegerStringFormatType.ToOcted:
                    return Convert.ToString(value, 8);
                case IntegerStringFormatType.ToBinary:
                    return Convert.ToString(value, 2);
                default:
                    throw new NotImplementedException();
            }
        }

        public static short FromString(this char value, String str, IntegerStringFormatType type)
        {
            switch (type)
            {
                case IntegerStringFormatType.ToHexBinary:
                    return Convert.ToInt16(str, 16);
                case IntegerStringFormatType.ToDecimal:
                    return Convert.ToInt16(str, 10);
                case IntegerStringFormatType.ToOcted:
                    return Convert.ToInt16(str, 8);
                case IntegerStringFormatType.ToBinary:
                    return Convert.ToInt16(str, 2);
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets the number of set bits (1)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetSetBits(this char value)
        {
            return value.ToString(IntegerStringFormatType.ToBinary).GetCountOf('1');
        }
    }
    /// @}
}
