using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Organizer
{
    /// <summary>
    /// Repeater factory
    /// </summary>
    public static class Repeaters
    {
        public static IRepeater CreateSecondRepeater(uint value)
        {
            return new Repeater(RepeatType.Second, value);
        }

        public static IRepeater CreateMinuteRepeater(uint value)
        {
            return new Repeater(RepeatType.Minute, value);
        }

        public static IRepeater CreateHourRepeater(uint value)
        {
            return new Repeater(RepeatType.Hour, value);
        }

        public static IRepeater CreateDayRepeater(uint value)
        {
            return new Repeater(RepeatType.Day, value);
        }

        public static IRepeater CreateWeekRepeater(uint value)
        {
            return new Repeater(RepeatType.Week, value);
        }

        public static IRepeater CreateMonthRepeater(uint value)
        {
            return new Repeater(RepeatType.Month, value);
        }

        public static IRepeater CreateYearRepeater(uint value)
        {
            return new Repeater(RepeatType.Year, value);
        }
    }
}
