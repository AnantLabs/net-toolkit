using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class SByteExtensions
    {
        public unsafe static IntPtr ToPointer(this sbyte b)
        {
            return new IntPtr(&b);
        }

        public static String ToString(this sbyte value, IntegerStringFormatType type)
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
        public static int GetSetBits(this sbyte value)
        {
            return value.ToString(IntegerStringFormatType.Binary).GetCountOf('1');
        }
    }
    /// @}
}
