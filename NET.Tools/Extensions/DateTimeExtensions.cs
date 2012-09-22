using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class DateTimeExtensions
    {
        public static bool IsLeapYear(this DateTime dateTime)
        {
            return DateTime.IsLeapYear(dateTime.Year);
        }

        public static bool IsBeforeNow(this DateTime dateTime)
        {
            return dateTime.CompareTo(DateTime.Now) < 0;
        }

        public static bool IsAfterNow(this DateTime dateTime)
        {
            return dateTime.CompareTo(DateTime.Now) > 0;
        }

        public static bool IsNow(this DateTime dateTime)
        {
            return dateTime.CompareTo(DateTime.Now) == 0;
        }

        public static DateTime AddWeek(this DateTime dateTime, double value)
        {
            return dateTime.AddDays(value * 7);
        }

        /// <summary>
        /// Add all days between the datetime day of week and the next day of week.
        /// </summary>
        /// <example>
        /// For example: It is 2010-12-02 (Thursday), value is Sunday, it will be add 3 days:
        /// <code>
        /// DateTime date = new DateTime(2010, 12, 2);
        /// date = date.AddDaysUntilNextDayOfWeek(DayOfWeek.Sunday);
        /// Console.WriteLine(date.ToShortDateString());
        /// </code>
        /// It will be print out "2010-12-05"
        /// </example>
        /// <param name="dateTime"></param>
        /// <param name="value">The next day of week to compute the days</param>
        /// <param name="gotoNextIfEquals">If the day of week is equals and this parameter 
        /// is true it will be add 7 days, otherwise 0 days</param>
        /// <returns>New DateTime object</returns>
        public static DateTime AddDaysUntilNextDayOfWeek(this DateTime dateTime, DayOfWeek value, bool gotoNextIfEquals)
        {
            int days = value - dateTime.DayOfWeek;

            if (days < 0)
                days = 7 + days;
            else if (days == 0)
            {
                if (gotoNextIfEquals)
                    days = 7;
            }

            return dateTime.AddDays(days);
        }

        /// <summary>
        /// Add all days between the datetime day of week and the next day of week. 
        /// If the day of week is equals the computed days are 0
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="value">The next day of week to compute the days</param>
        /// <returns>New DateTime object</returns>
        public static DateTime AddDaysUntilNextDayOfWeek(this DateTime dateTime, DayOfWeek value)
        {
            return AddDaysUntilNextDayOfWeek(dateTime, value, false);
        }

        /// <summary>
        /// Remove all days between the datetime day of week and the last day of week.
        /// </summary>
        /// <example>
        /// For example: It is 2010-12-02 (Thursday), value is Sunday, it will be removed 4 days:
        /// <code>
        /// DateTime date = new DateTime(2010, 12, 2);
        /// date = date.AddDaysUntilPrevDayOfWeek(DayOfWeek.Sunday);
        /// Console.WriteLine(date.ToShortDateString());
        /// </code>
        /// It will be print out "2010-11-28"
        /// </example>
        /// <param name="dateTime"></param>
        /// <param name="value">The last day of week to compute the days</param>
        /// <param name="gotoNextIfEquals">If the day of week is equals and this parameter 
        /// is true it will be removed 7 days, otherwise 0 days</param>
        /// <returns>New DateTime object</returns>
        public static DateTime AddDaysUntilPrevDayOfWeek(this DateTime dateTime, DayOfWeek value, bool gotoNextIfEquals)
        {
            int days = dateTime.DayOfWeek - value;

            if (days < 0)
                days = 7 + days;
            else if (days == 0)
            {
                if (gotoNextIfEquals)
                    days = 7;
            }

            return dateTime.AddDays(-days);
        }

        /// <summary>
        /// Remove all days between the datetime day of week and the last day of week. 
        /// If the day of week is equals the computed days are 0
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="value">The last day of week to compute the days</param>
        /// <returns>New DateTime object</returns>
        public static DateTime AddDaysUntilPrevDayOfWeek(this DateTime dateTime, DayOfWeek value)
        {
            return AddDaysUntilPrevDayOfWeek(dateTime, value, false);
        }
    }
    /// @}
}
