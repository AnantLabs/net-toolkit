using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    /// <summary>
    /// Format type for formatting of integers
    /// </summary>
    public enum IntegerStringFormatType
    {
        /// <summary>
        /// To Hex-Binary (e. g. 0xFF)
        /// </summary>
        HexBinary,
        /// <summary>
        /// To Decimal (e. g. 255)
        /// </summary>
        Decimal,
        /// <summary>
        /// To Octed (e. g. 8888)
        /// </summary>
        Octed,
        /// <summary>
        /// To Binary (e. g. 11111111)
        /// </summary>
        Binary,
        /// <summary>
        /// To Roman Numeral (e. g. XIV)
        /// </summary>
        RomanNumeral,
    }
}
