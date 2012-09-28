using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Security.Cryptography;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;

namespace NET.Tools
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Extensions for Strings
    /// </summary>
    public static class StringExtensions
    {
        public static byte[] ToByteArrayFromBase64String(this String str)
        {
            return Convert.FromBase64String(str);
        }

        public static byte[] ToByteArrayFromHexString(this String str)
        {
            if (str.Length % 2 != 0)
                throw new ArgumentException("The string is not a full hex-string!");

            byte[] bytes = new byte[str.Length / 2];

            for (int i = 0; i < str.Length; i += 2)
            {
                char c1 = str[i + 0];
                char c2 = str[i + 1];

                bytes[i / 2] = Byte.Parse("" + c1 + c2, NumberStyles.HexNumber);
            }

            return bytes;
        }

        public static byte ToByteValue(this String str)
        {
            return Byte.Parse(str);
        }

        public static byte ToByteValue(this String str, NumberStyles ns)
        {
            return Byte.Parse(str, ns);
        }

        public static int ToInt32Value(this String str)
        {
            return Int32.Parse(str);
        }

        public static int ToInt32Value(this String str, NumberStyles ns)
        {
            return Int32.Parse(str, ns);
        }

        public static uint ToUInt32Value(this String str)
        {
            return UInt32.Parse(str);
        }

        public static uint ToUInt32Value(this String str, NumberStyles ns)
        {
            return UInt32.Parse(str, ns);
        }

        public static long ToInt64Value(this String str)
        {
            return Int64.Parse(str);
        }

        public static long ToInt64Value(this String str, NumberStyles ns)
        {
            return Int64.Parse(str, ns);
        }

        public static ulong ToUInt64Value(this String str)
        {
            return UInt64.Parse(str);
        }

        public static ulong ToUInt64Value(this String str, NumberStyles ns)
        {
            return UInt64.Parse(str, ns);
        }

        public static short ToInt16Value(this String str)
        {
            return Int16.Parse(str);
        }

        public static short ToInt16Value(this String str, NumberStyles ns)
        {
            return Int16.Parse(str, ns);
        }

        public static ushort ToUInt16Value(this String str)
        {
            return UInt16.Parse(str);
        }

        public static ushort ToUInt16Value(this String str, NumberStyles ns)
        {
            return UInt16.Parse(str, ns);
        }

        public static double ToDoubleValue(this String str)
        {
            return Double.Parse(str);
        }

        public static double ToDoubleValue(this String str, NumberStyles ns)
        {
            return Double.Parse(str, ns);
        }

        public static float ToFloatValue(this String str)
        {
            return Single.Parse(str);
        }

        public static float ToFloatValue(this String str, NumberStyles ns)
        {
            return Single.Parse(str, ns);
        }

        public static decimal ToDecimalValue(this String str)
        {
            return Decimal.Parse(str);
        }

        public static decimal ToDecimalValue(this String str, NumberStyles ns)
        {
            return Decimal.Parse(str, ns);
        }

        public static bool ToBooleanValue(this String str)
        {
            return Boolean.Parse(str);
        }

        public static byte[] ToByteArray(this String str, Encoding enc)
        {
            byte[] buffer = null;

            using (MemoryStream stream = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(stream, enc))
                {
                    writer.Write(str);
                    stream.Seek(0, SeekOrigin.Begin);
                    buffer = stream.ToArray();
                }
            }

            return buffer;
        }

        public static byte[] ToByteArray(this String str)
        {
            return ToByteArray(str, Encoding.Default);
        }

        public static String FromByteArray(this String str, byte[] bytes, Encoding enc)
        {
            String res = "";

            using (MemoryStream stream = new MemoryStream(bytes))
            {
                using (StreamReader reader = new StreamReader(stream, enc))
                {
                    res = reader.ReadToEnd();
                }
            }

            return res;
        }

        public static String FromByteArray(this String str, byte[] bytes)
        {
            return FromByteArray(str, bytes, Encoding.Default);
        }

        public static byte[] EncodeWithMD5(this String str)
        {
            MD5 md5 = MD5.Create();
            return md5.ComputeHash(str.ToByteArray());
        }

        public static byte[] EncodeWithSHA1(this String str)
        {
            SHA1 sha1 = SHA1.Create();
            return sha1.ComputeHash(str.ToByteArray());
        }

        public static bool EqualsIgnoreCase(this String str, String str2)
        {
            return str.ToLower().Equals(str2.ToLower());
        }

        public static bool StartsWithIgnoreCase(this String str, String str2)
        {
            return str.ToLower().StartsWith(str2);
        }

        public static bool EndsWithIgnoreCase(this String str, String str2)
        {
            return str.ToLower().EndsWith(str2);
        }

        public static String GetShortString(this String str, int maxLength)
        {
            if (str.Length <= maxLength)
                return str;

            return str.Substring(0, maxLength - 3) + "...";
        }

        public static bool IsEmpty(this String str)
        {
            return str.Length == 0;
        }

        /// <summary>
        /// Parse an as string given calculation
        /// 
        /// It will use the static method from the StringCalculator.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="valueList">An optional list to replace characters with the given numbers</param>
        /// <param name="decimals">Count of digits</param>
        /// <returns>The calculation result</returns>
        /// <example>
        /// This example shows you to use this extension method:
        /// <code>
        /// String calc = "21*x/3";
        /// double result = 0d;
        /// 
        /// for(double i = -1.0d; i &lt;= 1.0d; i += 0.01d)
        /// {
        ///     Dictionary{String, double} dic = new Dictionary{String, double}();
        ///     dic.Add("x", i);
        /// 
        ///     result += calc.ParseCalculationString(dic);
        /// }
        /// </code>
        /// </example>
        /// <exception cref="ParserException">
        /// Is thrown if the parser cannot parse the string
        /// </exception>
        /// <exception cref="NumberParserException">
        /// Is thrown if an number cannot be parsed
        /// </exception>
        /// <seealso cref="StringCalculator"/>
        public static double ParseCalculationString(this String str, IDictionary<String, double> valueList, int decimals)
        {
            return StringCalculator.ParseCalculationString(str, valueList, decimals);
        }

        public static double ParseCalculationString(this String str, IDictionary<String, double> valueList)
        {
            return str.ParseCalculationString(valueList, 6);
        }

        public static double ParseCalculationString(this String str, int decimals)
        {
            return str.ParseCalculationString(new Dictionary<string, double>(), decimals);
        }

        public static double ParseCalculationString(this String str)
        {
            return str.ParseCalculationString(new Dictionary<string, double>());
        }

        /// <summary>
        /// Split the string after the given lengths
        /// </summary>
        /// <param name="str"></param>
        /// <param name="lengths">A length list as params list</param>
        /// <returns></returns>
        public static String[] Split(this String str, params int[] lengths)
        {
            List<String> res = new List<string>();

            int pos = 0;
            foreach (int i in lengths)
            {
                res.Add(str.Substring(pos, i));
                pos += i;
            }
            //Last string part
            if (str.Substring(pos).Length > 0)
                res.Add(str.Substring(pos));

            return res.ToArray();
        }

        /// <summary>
        /// Removes all sapces (' '), tabs ('\\t') and wraps ('\\n', '\\r')
        /// </summary>
        /// <param name="str"></param>
        /// <returns>A string without spaces, tabs and wraps</returns>
        public static String RemoveAllSpaces(this String str)
        {
            StringBuilder res = new StringBuilder();

            foreach (char c in str)
            {
                if (c.IsNotIn(' ', '\t', '\r', '\n'))
                    res.Append(c);
            }

            return res.ToString();
        }

        /// <summary>
        /// Gets the count of the character
        /// </summary>
        /// <param name="c">Character to count</param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetCountOf(this String str, char c)
        {
            return GetCountOf(str, c, false);
        }

        /// <summary>
        /// Gets the count of the character
        /// </summary>
        /// <param name="c">Character to count</param>
        /// <param name="ignoreCase">Ignore the cases</param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetCountOf(this String str, char c, bool ignoreCase)
        {
            int counter = 0;

            foreach (char part in str)
            {
                if (ignoreCase)
                {
                    if (Char.ToUpper(part) == Char.ToUpper(c))
                        counter++;
                }
                else
                {
                    if (part == c)
                        counter++;
                }
            }

            return counter;
        }

        /// <summary>
        /// Gets the count of the string
        /// </summary>
        /// <param name="s">String sequence to count</param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetCountOf(this String str, String s)
        {
            return GetCountOf(str, s, false);
        }

        /// <summary>
        /// Gets the count of the String
        /// </summary>
        /// <param name="s">String sequence to count</param>
        /// <param name="ignoreCase">Ignore the cases</param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetCountOf(this String str, String s, bool ignoreCase)
        {
            int counter = 0;

            while (true)
            {
                int index = -1;
                if (ignoreCase)
                    index = str.IndexOf(s, StringComparison.CurrentCultureIgnoreCase);
                else
                    index = str.IndexOf(s, StringComparison.CurrentCulture);
                if (index < 0)
                    break;

                counter++;
                str = str.Remove(index, s.Length);
            }

            return counter;
        }

        /// <summary>
        /// Gets the count of the string regex
        /// </summary>
        /// <param name="regex">Regex to count</param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetCountOfMatches(this String str, String regex)
        {
            return str.GetMaches(regex).Count;
        }

        public static MatchCollection GetMaches(this String str, String regex)
        {
            return new Regex(regex).Matches(str);
        }
    }
    /// @}
}
