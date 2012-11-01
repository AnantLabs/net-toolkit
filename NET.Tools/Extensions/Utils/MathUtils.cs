using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    internal static class MathUtils
    {
        #region Constants

        private const char MILLE = 'M';
        private const char HALF_MILLE = 'D';
        private const char CENT = 'C';
        private const char HALF_CENT = 'L';
        private const char TEN = 'X';
        private const char HALF_TEN = 'V';
        private const char ONE = 'I';

        #endregion

        #region Inner Classes

        private sealed class RomanNumeralResult
        {
            public bool SkipNextNumber { get; private set; }
            public long CalculatedNumber { get; private set; }

            public RomanNumeralResult(bool skipNextNumber, long calculatedNumber)
            {
                SkipNextNumber = skipNextNumber;
                CalculatedNumber = calculatedNumber;
            }
        }

        #endregion


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

        #region Roman Numeral Parsing

        /// <summary>
        /// Parse roman numbers
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        public static long FromRomanNumerals(String str)
        {
            long number = 0;

            ValidateRomanNumeral(str);

            for (int i = str.Length - 1; i >= 0; i--)
            {
                char romanNumeral = str[i];
                char? prevRomanNumeral = i > 0 ? str[i - 1] : (char?) null;

                RomanNumeralResult result = null;
                switch (romanNumeral)
                {
                    case MILLE:
                    case HALF_MILLE:
                        result = CalculateNumber(romanNumeral, prevRomanNumeral, CENT);
                        break;
                    case CENT:
                    case HALF_CENT:
                        result = CalculateNumber(romanNumeral, prevRomanNumeral, TEN);
                        break;
                    case TEN:
                    case HALF_TEN:
                        result = CalculateNumber(romanNumeral, prevRomanNumeral, ONE);
                        break;
                    case ONE:
                        result = new RomanNumeralResult(false, 1L);
                        break;
                    default:
                        throw new ArgumentException("Unknown roman numeral: " + romanNumeral);
                }

                number += result.CalculatedNumber;
                if (result.SkipNextNumber)
                {
                    i--;
                }
            }

            return number;
        }

        private static void ValidateRomanNumeral(String str)
        {
            for (int i = str.Length - 1; i >= 0; i--)
            {
                char romanNumeral = str[i];
                char? prevRomanNumeral = i > 0 ? str[i - 1] : (char?) null;

                if (prevRomanNumeral != null)
                {
                    switch (romanNumeral)
                    {
                        case MILLE:
                            if (prevRomanNumeral.Value != CENT && prevRomanNumeral.Value != MILLE)
                                throw new FormatException("Cannot read roman numerals: '" + str +
                                                          "': Wrong character before 'M'!");
                            break;
                        case HALF_MILLE:
                            if (prevRomanNumeral.Value != CENT && prevRomanNumeral.Value != MILLE)
                                throw new FormatException("Cannot read roman numerals: '" + str +
                                                          "': Wrong character before 'D'!");
                            break;
                        case CENT:
                            if (prevRomanNumeral.Value != MILLE && prevRomanNumeral.Value != HALF_MILLE &&
                                prevRomanNumeral.Value != TEN && prevRomanNumeral.Value != CENT)
                                throw new FormatException("Cannot read roman numerals: '" + str +
                                                          "': Wrong character before 'C'!");
                            break;
                        case HALF_CENT:
                            if (prevRomanNumeral.Value != MILLE && prevRomanNumeral.Value != HALF_MILLE &&
                                prevRomanNumeral.Value != TEN && prevRomanNumeral.Value != CENT)
                                throw new FormatException("Cannot read roman numerals: '" + str +
                                                          "': Wrong character before 'L'!");
                            break;
                        case TEN:
                            if (prevRomanNumeral.Value == HALF_TEN)
                                throw new FormatException("Cannot read roman numerals: '" + str +
                                                          "': Wrong character before 'X'!");
                            break;
                        case HALF_TEN:
                            if (prevRomanNumeral.Value == HALF_TEN)
                                throw new FormatException("Cannot read roman numerals: '" + str +
                                                          "': Wrong character before 'V'!");
                            break;
                        case ONE:
                            //Nothing
                            break;
                        default:
                            throw new ArgumentException("Unknown roman numeral: " + romanNumeral);
                    }
                }
            }
        }

        private static RomanNumeralResult CalculateNumber(char romanNumeral, char? prevRomanNumeral, char smallerRomanNumeral)
        {
            if (prevRomanNumeral != null && prevRomanNumeral == smallerRomanNumeral) //Subtraction
            {
                long sub = GetNumber(romanNumeral) - GetNumber(prevRomanNumeral.Value);
                return new RomanNumeralResult(true, sub);
            }

            return new RomanNumeralResult(false, GetNumber(romanNumeral));
        }

        private static long GetNumber(char romanNumeral)
        {
            switch (romanNumeral)
            {
                case MILLE:
                    return 1000;
                case HALF_MILLE:
                    return 500;
                case CENT:
                    return 100;
                case HALF_CENT:
                    return 50;
                case TEN:
                    return 10;
                case HALF_TEN:
                    return 5;
                case ONE:
                    return 1;
                default:
                    throw new ArgumentException("Unknown roman numeral: " + romanNumeral);
            }
        }

        #endregion


        #region Roman Numerals Creation

        public static String ToRomanNumerals(long number)
        {
            StringBuilder sb = new StringBuilder();
            long current = number;

            //Mille
            String mille = CalculateRomanNumerals(current, 1000);
            sb.Append(mille);
            current = current%1000;

            //Cent
            String cent = CalculateRomanNumerals(current, 100);
            sb.Append(cent);
            current = current%100;

            //Ten
            String ten = CalculateRomanNumerals(current, 10);
            sb.Append(ten);
            current = current%10;

            //One
            String one = CalculateRomanNumerals(current, 1);
            sb.Append(one);

            return sb.ToString();
        }

        private static String CalculateRomanNumerals(long current, long divider)
        {
            StringBuilder sb = new StringBuilder();

            long count = current/divider;

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
                char romanNumberNextHalf = GetRomanNumeral(divider*10, true);
                char romanNumberNext = GetRomanNumeral(divider*10, false);

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

        #endregion

    }
}
