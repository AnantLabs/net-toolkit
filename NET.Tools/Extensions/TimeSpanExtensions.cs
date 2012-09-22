using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    /// \addtogroup extensions
    /// @{

    ///<summary>
    ///TimeSpan extensions
    ///</summary>
    public static class TimeSpanExtensions
    {
        public static TimeSpan AddMilliseconds(this TimeSpan timeSpan, double value)
        {
            return timeSpan.Add(TimeSpan.FromMilliseconds(value));
        }

        public static TimeSpan AddSeconds(this TimeSpan timeSpan, double value)
        {
            return timeSpan.Add(TimeSpan.FromSeconds(value));
        }

        public static TimeSpan AddMinutes(this TimeSpan timeSpan, double value)
        {
            return timeSpan.Add(TimeSpan.FromMinutes(value));
        }

        public static TimeSpan AddHours(this TimeSpan timeSpan, double value)
        {
            return timeSpan.Add(TimeSpan.FromHours(value));
        }

        public static TimeSpan AddDays(this TimeSpan timeSpan, double value)
        {
            return timeSpan.Add(TimeSpan.FromDays(value));
        }

        public static TimeSpan AddTicks(this TimeSpan timeSpan, long value)
        {
            return timeSpan.Add(TimeSpan.FromTicks(value));
        }

        public static TimeSpan AddWeeks(this TimeSpan timeSpan, double value)
        {
            return timeSpan.AddDays(value * 7);
        }

        public static int GetWeeks(this TimeSpan timeSpan)
        {
            return timeSpan.Days / 7;
        }

        public static double GetTotalWeeks(this TimeSpan timeSpan)
        {
            return timeSpan.TotalDays / 7d;
        }

        public static String ToString(this TimeSpan timeSpan, TimeSpanStringType type)
        {
            switch (type)
            {
                case TimeSpanStringType.Full:
                    return
                        timeSpan.Days + ", " +
                        timeSpan.Hours + ":" +
                        timeSpan.Minutes + ":" +
                        timeSpan.Seconds + "," +
                        timeSpan.Milliseconds;
                case TimeSpanStringType.Normal:
                    return
                        (int)timeSpan.TotalHours + ":" +
                        timeSpan.Minutes + ":" +
                        timeSpan.Seconds;
                case TimeSpanStringType.Minimal:
                    return
                        (int)timeSpan.TotalMinutes + ":" +
                        timeSpan.Seconds;
                case TimeSpanStringType.OnlyLast:
                    if (timeSpan.Days > 0)
                        return timeSpan.Days + " Days";
                    else if (timeSpan.Hours > 0)
                        return timeSpan.Hours + " Hours";
                    else if (timeSpan.Minutes > 0)
                        return timeSpan.Minutes + " Min";
                    else if (timeSpan.Seconds > 0)
                        return timeSpan.Seconds + " Sec";
                    else
                        return "A little moment";
                case TimeSpanStringType.Default:
                    return timeSpan.ToString();
                default:
                    throw new NotImplementedException();
            }
        }
    }
    /// @}

    /// \addtogroup enums
    /// @{

    /// <summary>
    /// All types for the to string extension method for time span
    /// </summary>
    public enum TimeSpanStringType
    {
        /// <summary>
        /// Full time span: Days, Hours:Minutes:Seconds:Milliseconds
        /// </summary>
        Full,
        /// <summary>
        /// Normal time span: Hours:Minutes:Seconds
        /// </summary>
        Normal,
        /// <summary>
        /// Minimal time span: Minutes:Seconds
        /// </summary>
        Minimal,
        /// <summary>
        /// Only the last object is shown: E. g. 3 Days, 5 Min, 10 Seconds, ect.
        /// </summary>
        OnlyLast,
        /// <summary>
        /// The default toString method is used
        /// </summary>
        Default
    }
    /// @}
}
