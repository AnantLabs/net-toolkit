using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Organizer
{
    /// <summary>
    /// Condition for a year point in days
    /// </summary>
    /// <example>
    /// The 55th day in the year 2005
    /// <code>
    /// ICondition con = new YearDayCondition(55, CounterType.Front, 2005);
    /// </code>
    /// </example>
    public class YearCondition : TimeCondition
    {
        public const ushort ANYYEAR = 0;

        #region Static 

        public static YearCondition CreateDayCondition(ushort days, CounterType type, ushort year)
        {
            return new YearCondition(ValueType.Day, days, DayOfWeek.Sunday, type, year);
        }

        public static YearCondition CreateWeekCondition(byte weeks, DayOfWeek dayOfWeek, CounterType type, ushort year)
        {
            return new YearCondition(ValueType.Week, weeks, dayOfWeek, type, year);
        }

        #endregion

        private ushort year;

        private YearCondition(ValueType valueType, uint value, DayOfWeek week, CounterType type, ushort year)
            : base(valueType, type, value, week)
        {
            Year = year;
        }

        public ushort Year
        {
            get
            {
                return year;
            }
            set
            {
                if (value == ANYYEAR)
                    year = ANYYEAR;

                if ((year < DateTime.MinValue.Year) ||
                    (year > DateTime.MaxValue.Year))
                    throw new ArgumentException("Cannot work with this year! It must be between " +
                        DateTime.MinValue.Year + " and " + DateTime.MaxValue.Year + "!");

                year = value;
            }
        }

        protected override IList<DateTime> GetDatesForDays(DateTime start, DateTime end)
        {
            List<DateTime> res = new List<DateTime>();

            DateTime date = DateTime.Now;
            if (Year == ANYYEAR) //All years are integrated
            {
                //Create the first date from start with condition
                switch (CounterType)
                {
                    case CounterType.Front:
                        date = new DateTime(start.Year, 1, 1).AddDays(Value);
                        break;
                    case CounterType.Back:
                        date = new DateTime(start.Year, 12, 31).AddDays(-Value);
                        break;
                    default:
                        throw new NotImplementedException();
                }

                if (date < start) //Date is to small at start
                    date.AddYears(1); //Add year to go next step
                else if (date > end) //Date is to great at start
                    return null; //Stop routine, no date found

                //Search all dates in one year steps
                while ((date >= start) && (date <= end))
                {
                    res.Add(date);
                    date.AddYears(1);
                }
            }
            else //Fixed year are integrated
            {
                //Create the fixed date from condition
                switch (CounterType)
                {
                    case CounterType.Front:
                        date = new DateTime(this.Year, 1, 1).AddDays(Value);
                        break;
                    case CounterType.Back:
                        date = new DateTime(this.Year, 12, 31).AddDays(-Value);
                        break;
                    default:
                        throw new NotImplementedException();
                }

                //If date between start and end date
                if ((date >= start) && (date <= end))
                    res.Add(date); //Add it
            }

            if (res.Count > 0)
                return res;

            return null;
        }

        protected override IList<DateTime> GetDatesForWeeks(DateTime start, DateTime end)
        {
            List<DateTime> res = new List<DateTime>();

            DateTime date = DateTime.Now;
            if (Year == ANYYEAR) //All years are integrated
            {
                //Create the first date from start with condition
                switch (CounterType)
                {
                    case CounterType.Front:
                        date = new DateTime(start.Year, 1, 1);
                        date = date.AddDaysUntilNextDayOfWeek(this.DayOfWeek);
                        date = date.AddDays(Value * 7);
                        break;
                    case CounterType.Back:
                        date = new DateTime(start.Year, 12, 31);
                        date = date.AddDaysUntilPrevDayOfWeek(this.DayOfWeek);
                        date = date.AddDays(-(Value * 7));
                        break;
                    default:
                        throw new NotImplementedException();
                }

                if (date < start) //Date is to small at start
                    date.AddYears(1); //Add year to go next step
                else if (date > end) //Date is to great at start
                    return null; //Stop routine, no date found

                //Search all dates in one year steps
                while ((date >= start) && (date <= end))
                {
                    res.Add(date);
                    date.AddYears(1);
                }
            }
            else //Fixed year are integrated
            {
                //Create the fixed date from condition
                switch (CounterType)
                {
                    case CounterType.Front:
                        date = new DateTime(this.Year, 1, 1);
                        date = date.AddDaysUntilNextDayOfWeek(this.DayOfWeek);
                        date = date.AddDays(Value * 7);
                        break;
                    case CounterType.Back:
                        date = new DateTime(this.Year, 12, 31);
                        date = date.AddDaysUntilPrevDayOfWeek(this.DayOfWeek);
                        date = date.AddDays(-(Value * 7));
                        break;
                    default:
                        throw new NotImplementedException();
                }

                //If date between start and end date
                if ((date >= start) && (date <= end))
                    res.Add(date); //Add it
            }

            if (res.Count > 0)
                return res;

            return null;
        }
    }
}
