using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    public static class MathUtils
    {
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
    }
}
