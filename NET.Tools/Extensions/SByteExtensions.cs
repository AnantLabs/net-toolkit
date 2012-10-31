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
                case IntegerStringFormatType.ToHexBinary:
                    return Convert.ToString(value, 16);
                case IntegerStringFormatType.ToDecimal:
                    return Convert.ToString(value, 10);
                case IntegerStringFormatType.ToOcted:
                    return Convert.ToString(value, 8);
                case IntegerStringFormatType.ToBinary:
                    return Convert.ToString(value, 2);
                case IntegerStringFormatType.ToRomanNumeral:
                    return MathUtils.ToRomanNumerals(value);
                default:
                    throw new NotImplementedException();
            }
        }

        public static short FromString(this sbyte value, String str, IntegerStringFormatType type)
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
        public static int GetSetBits(this sbyte value)
        {
            return value.ToString(IntegerStringFormatType.ToBinary).GetCountOf('1');
        }
    }
    /// @}
}
