using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace NET.Tools
{
    /// <summary>
    /// Contains internal algorithms
    /// </summary>
    public static class Algorithm
    {
        /// <summary>
        /// Mathematical algorithms
        /// </summary>
        public static class Math
        {
            /// <summary>
            /// Color algorithms
            /// </summary>
            public static class Color
            {
                public static void ToGrayScale(ref byte r, ref byte g, ref byte b)
                {
                    byte val = (byte)((r + g + b) / 3);

                    r = val;
                    g = val;
                    b = val;
                }

                public static void ToRedGrayScale(ref byte r, ref byte g, ref byte b)
                {
                    g = r;
                    b = r;
                }

                public static void ToGreenGrayScale(ref byte r, ref byte g, ref byte b)
                {
                    r = g;
                    b = g;
                }

                public static void ToBlueGrayScale(ref byte r, ref byte g, ref byte b)
                {
                    r = b;
                    g = b;
                }

                public static void ToNegative(ref byte r, ref byte g, ref byte b)
                {
                    r = (byte)(255 - r);
                    g = (byte)(255 - g);
                    b = (byte)(255 - b);
                }

                public static void AddColor(ref byte r, ref byte g, ref byte b, byte ar, byte ag, byte ab, double percent)
                {
                    if ((percent < 0d) || (percent > 1d))
                        throw new ArgumentException("The value of percent must be between 0 and 1!");

                    r = (byte)(r * (percent - 1) + ar * percent);
                    g = (byte)(g * (percent - 1) + ag * percent);
                    b = (byte)(b * (percent - 1) + ab * percent);
                }

                public static void Darker(ref byte r, ref byte g, ref byte b, double div)
                {
                    if (div < 1d)
                        throw new ArgumentException("The div-value must be greater than 0!");

                    r = (byte)(r / div);
                    g = (byte)(g / div);
                    b = (byte)(b / div);
                }

                public static void Brighter(ref byte r, ref byte g, ref byte b, double div)
                {
                    if (div < 1d)
                        throw new ArgumentException("The div-value must be greater than 0!");

                    r = (byte)(r + ((255 - r) / div));
                    g = (byte)(g + ((255 - g) / div));
                    b = (byte)(b + ((255 - b) / div));
                }
            }

            public static void ToProportionalSize(double maxWidth, double maxHeight,
                ref double normWidth, ref double normHeight)
            {
                double width, height;

                //Varinate 1
                width = maxWidth;
                height = (double)normHeight * ((double)maxWidth / (double)normWidth);

                //Variante 2, wenn die neue Höhe größer als die maximale Höhe
                if (height > maxHeight)
                {
                    height = maxHeight;
                    width = (double)normWidth * ((double)maxHeight / (double)normHeight);
                }

                //Notfall
                if (width > maxWidth)
                    throw new ArithmeticException("No solution found!");

                normWidth = width;
                normHeight = height;
            }

            public static void ToPercentSize(double percent, ref double width, ref double height)
            {
                if (percent <= 0)
                    throw new ArgumentException("Percent must be greater than 0!");

                width = width * percent;
                height = height * percent;
            }
        }//Math

        public static class Logic
        {
            public static bool IsPointInRect(double x, double y, double rx, double ry,
                double rw, double rh)
            {
                if ((x >= rx) && (x <= rx + rw) &&
                    (y >= ry) && (y <= ry + rh))
                    return true;

                return false;
            }

            public static bool IsRectInRect(double rx1, double ry1, double rw1, double rh1,
                double rx2, double ry2, double rw2, double rh2)
            {
                Rect r1 = new Rect(rx1, ry1, rw1, rh1);
                Rect r2 = new Rect(rx2, ry2, rw2, rh2);

                return IsRectInRectX(r1, r2);
            }

            #region Private

            private static bool IsRectInRectX(Rect rect, Rect r)
            {
                if ((r.Left >= rect.Left) && (r.Left <= rect.Right))
                {
                    if (IsRectInRectY(rect, r))
                        return true;
                }
                else if ((r.Right >= rect.Left) && (r.Right <= rect.Right))
                {
                    if (IsRectInRectY(rect, r))
                        return true;
                }
                else if ((r.Left < rect.Left) && (r.Right > rect.Right))
                {
                    if (IsRectInRectY(rect, r))
                        return true;
                }

                return false;
            }

            private static bool IsRectInRectY(Rect rect, Rect r)
            {
                if ((r.Top >= rect.Top) && (r.Top <= rect.Bottom))
                    return true;
                else if ((r.Bottom >= rect.Top) && (r.Bottom <= rect.Bottom))
                    return true;
                else if ((r.Top < rect.Top) && (r.Bottom > rect.Bottom))
                    return true;

                return false;
            }

            #endregion
        }
    }
}
