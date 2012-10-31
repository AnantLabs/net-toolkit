using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Organizer
{
    /// <summary>
    /// Condition for a month point in days
    /// </summary>
    /// <example>
    /// The 5th last day in month March
    /// <code>
    /// ICondition con = new MonthDayCondition(5, CounterType.Back, MonthOfYear.March);
    /// </code>
    /// </example>
    public class MonthCondition : TimeCondition
    {
        #region Static

        public static MonthCondition CreateDayCondition(ushort days, CounterType type, MonthOfYear month)
        {
            return new MonthCondition(ValueType.Day, DayOfWeek.Sunday, days, type, month);
        }

        public static MonthCondition CreateWeekCondition(byte weeks, DayOfWeek dayOfWeek, CounterType type, MonthOfYear month)
        {
            return new MonthCondition(ValueType.Week, dayOfWeek, weeks, type, month);
        }

        #endregion

        private MonthCondition(ValueType valueType, DayOfWeek dayOfWeek, uint value, CounterType counterType, MonthOfYear month)
            : base(valueType, counterType, value, dayOfWeek)
        {
            MonthOfYear = month;
        }

        public MonthOfYear MonthOfYear
        {
            get;
            set;
        }

        protected override IList<DateTime> GetDatesForDays(DateTime start, DateTime end)
        {
            List<DateTime> res = new List<DateTime>();

            //DateTime date = DateTime.Now;
            //if (MonthOfYear == MonthOfYear.Any) //All months are integrated
            //{
            //    //Create the first date from start with condition
            //    switch (CounterType)
            //    {
            //        case CounterType.Front:
            //            date = new DateTime(start.Year, (byte)MonthOfYear, 1);
            //            date = date.AddDays(Value);
            //            break;
            //        case CounterType.Back:
            //            date = new DateTime(start.Year, (byte)MonthOfYear,
            //                DateTime.DaysInMonth(start.Year, (byte)MonthOfYear));
            //            date = date.AddDays(-Value);
            //            break;
            //        default:
            //            throw new NotImplementedException();
            //    }

            //    if (date < start) //Date is to small at start
            //        date.AddYears(1); //Add year to go next step
            //    else if (date > end) //Date is to great at start
            //        return null; //Stop routine, no date found

            //    //Search all dates in one year steps
            //    while ((date >= start) && (date <= end))
            //    {
            //        res.Add(date);
            //        date.AddYears(1);
            //    }
            //}
            //else //Fixed year are integrated
            //{
            //    //Create the fixed date from condition
            //    switch (CounterType)
            //    {
            //        case CounterType.Front:
            //            date = new DateTime(this.Year, 1, 1).AddDays(Value);
            //            break;
            //        case CounterType.Back:
            //            date = new DateTime(this.Year, 12, 31).AddDays(-Value);
            //            break;
            //        default:
            //            throw new NotImplementedException();
            //    }

            //    //If date between start and end date
            //    if ((date >= start) && (date <= end))
            //        res.Add(date); //Add it
            //}

            if (res.Count > 0)
                return res;

            return null;
        }

        protected override IList<DateTime> GetDatesForWeeks(DateTime start, DateTime end)
        {
            List<DateTime> res = new List<DateTime>();

            DateTime date = start;
            while (date < end)
            {

            }

            return res;
        }
    }

    /// \addtogroup enums
    /// @{

    /// <summary>
    /// The months of the year
    /// </summary>
    public enum MonthOfYear : byte
    {
        Januaray = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        Juny = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12,
        Any = 0
    }

    /// @}
}
