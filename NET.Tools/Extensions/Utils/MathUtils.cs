using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    public static class MathUtils
    {
        private const char MILLE = 'M';
        private const char HALF_MILLE = 'D';
        private const char CENT = 'C';
        private const char HALF_CENT = 'L';
        private const char TEN = 'X';
        private const char HALF_TEN = 'V';
        private const char ONE = 'I';

        public static String ToByteSizeString(double d, bool makeSmaller)
        {
            if (!makeSmaller)
                return d.ToString("0.00") + " Bytes";

            if (d <= 1024f)
                return d.ToString("0.00") + "B";
            else if (d < 1024f * 1024f)
                return (d / 1024f).ToString("0.00") + "KB";
            else if (d < 1024f * 1024f * 1024f)
                return (d / (1024f * 1024f)).ToString("0.00") + "MB";
            else if (d < 1024f * 1024f * 1024f * 1024f)
                return (d / (1024f * 1024f * 1024f)).ToString("0.00") + "GB";
            else
                return (d / (1024f * 1024f * 1024f * 1024f)).ToString("0.00") + "TB";
        }

        public static String ToRomanNumerals(long number)
        {
            StringBuilder sb = new StringBuilder();
            long current = number;

            //Mille
            String mille = CalculateRomanNumerals(current, 1000);
            sb.Append(mille);
            current = current % 1000;

            //Cent
            String cent = CalculateRomanNumerals(current, 100);
            sb.Append(cent);
            current = current % 100;

            //Ten
            String ten = CalculateRomanNumerals(current, 10);
            sb.Append(ten);
            current = current % 10;

            //One
            String one = CalculateRomanNumerals(current, 1);
            sb.Append(one);

            return sb.ToString();
        }

        private static String CalculateRomanNumerals(long current, long divider)
        {
            StringBuilder sb = new StringBuilder();
            
            long count = current / divider;

            if (divider == 1000)
            {                
                for (int i = 0; i < count; i++)
                {
                    sb.Append(GetRomanNumeral(divider, false));
                }
            }
            else
            {
                char romanNumberCurrent = GetRomanNumeral(divider, false);
                char romanNumberNextHalf = GetRomanNumeral(divider * 10, true);
                char romanNumberNext = GetRomanNumeral(divider * 10, false);

                if (count == 9) //Subtraction 
                {
                    sb.Append(romanNumberCurrent).Append(romanNumberNext);
                }
                else if (count >= 5 && count <= 8) //Addition
                {
                    sb.Append(romanNumberNextHalf);
                    for (int i = 0; i < count - 5; i++)
                    {
                        sb.Append(romanNumberCurrent);
                    }
                }
                else if (count == 4) //Subtration
                {
                    sb.Append(romanNumberCurrent).Append(romanNumberNextHalf);
                }
                else //Addition
                {
                    for (int i = 0; i < count; i++)
                    {
                        sb.Append(romanNumberCurrent);
                    }
                }
            }

            return sb.ToString();
        }

        private static char GetRomanNumeral(long divider, bool half)
        {
            switch (divider)
            {
                case 1000:
                    if (half)
                        return HALF_MILLE;
                    return MILLE;
                case 100:
                    if (half)
                        return HALF_CENT;
                    return CENT;
                case 10:
                    if (half)
                        return HALF_TEN;
                    return TEN;
                case 1:
                    return ONE;
                default:
                    throw new ArgumentException("Unknown divider: " + divider);
            }
        }
    }
}
