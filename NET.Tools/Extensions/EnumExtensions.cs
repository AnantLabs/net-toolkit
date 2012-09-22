using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    public enum Test : byte
    {
        A,
        B
    }

    public static class EnumExtensions
    {
        /// <summary>
        /// Only for flagged enumerations! Check that the type contains the value NOT IMPLEMENTED
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value">Value to check</param>
        /// <returns></returns>
        public static bool ContainsValue(this Enum obj, Enum value)
        {
            //TODO
            return false;
        }
    }
}
