using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Organizer
{
    public abstract class TimeCondition : ICondition
    {
        internal TimeCondition(ValueType valueType, CounterType counter, uint value, DayOfWeek dayOfWeek)
        {
            ValueType = valueType;
            CounterType = counter;
            Value = value;
            DayOfWeek = dayOfWeek;
        }

        #region ICondition Member

        public CounterType CounterType
        {
            get;
            set;
        }

        #endregion

        internal ValueType ValueType
        {
            get; 
            private set;
        }

        public uint Value
        {
            get;
            private set;
        }

        public DayOfWeek DayOfWeek
        {
            get;
            private set;
        }

        #region ICondition Member

        public IList<DateTime> GetDates(DateTime start, DateTime end)
        {
            switch (ValueType)
            {
                case ValueType.Week:
                    return GetDatesForWeeks(start, end);
                case ValueType.Day:
                    return GetDatesForDays(start, end);
                default:
                    throw new NotImplementedException();
            }
        }

        #endregion

        protected abstract IList<DateTime> GetDatesForDays(DateTime start, DateTime end);
        protected abstract IList<DateTime> GetDatesForWeeks(DateTime start, DateTime end);
    }

    internal enum ValueType
    {
        Week,
        Day
    }
}
