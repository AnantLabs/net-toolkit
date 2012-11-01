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
                case IntegerStringFormatType.HexBinary:
                    return Convert.ToString(value, 16);
                case IntegerStringFormatType.Decimal:
                    return Convert.ToString(value, 10);
                case IntegerStringFormatType.Octed:
                    return Convert.ToString(value, 8);
                case IntegerStringFormatType.Binary:
                    return Convert.ToString(value, 2);
                case IntegerStringFormatType.RomanNumeral:
                    return MathUtils.ToRomanNumerals(value);
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
            return value.ToString(IntegerStringFormatType.Binary).GetCountOf('1');
        }
    }
    /// @}
}
