using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    public static class TextValidator
    {
        public static bool ValidateInt32(String text)
        {
            int i;
            return Int32.TryParse(text, out i);
        }

        public static bool ValidateInt16(String text)
        {
            short i;
            return Int16.TryParse(text, out i);
        }

        public static bool ValidateInt64(String text)
        {
            long i;
            return Int64.TryParse(text, out i);
        }

        public static bool ValidateDouble(String text)
        {
            double i;
            return Double.TryParse(text, out i);
        }

        public static bool ValidateSingle(String text)
        {
            float i;
            return Single.TryParse(text, out i);
        }

        public static bool ValidateDecimal(String text)
        {
            decimal i;
            return Decimal.TryParse(text, out i);
        }

        public static bool ValidateHex(String text)
        {
            try
            {
                Int64.Parse(text, System.Globalization.NumberStyles.HexNumber);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ValidateDateTime(String text)
        {
            try
            {
                DateTime.Parse(text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
