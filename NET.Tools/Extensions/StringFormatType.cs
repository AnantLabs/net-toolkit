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
        ToHexBinary,
        /// <summary>
        /// To Decimal (e. g. 255)
        /// </summary>
        ToDecimal,
        /// <summary>
        /// To Octed (e. g. 8888)
        /// </summary>
        ToOcted,
        /// <summary>
        /// To Binary (e. g. 11111111)
        /// </summary>
        ToBinary
    }
}
