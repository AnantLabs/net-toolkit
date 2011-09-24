using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Organizer
{
    /// <summary>
    /// Conditions factory
    /// </summary>
    public static class Conditions
    {
        public static MonthCondition CreateMonthDayCondition(ushort days, CounterType type, MonthOfYear month)
        {
            return MonthCondition.CreateDayCondition(days, type, month);
        }

        public static MonthCondition CreateMonthWeekCondition(byte weeks, DayOfWeek dayOfWeek, CounterType type, MonthOfYear month)
        {
            return MonthCondition.CreateWeekCondition(weeks, dayOfWeek, type, month);
        }

        public static YearCondition CreateYearDayCondition(ushort days, CounterType type, ushort year)
        {
            return YearCondition.CreateDayCondition(days, type, year);
        }

        public static YearCondition CreateYearWeekCondition(byte weeks, DayOfWeek dayOfWeek, CounterType type, ushort year)
        {
            return YearCondition.CreateWeekCondition(weeks, dayOfWeek, type, year);
        }
    }
}
