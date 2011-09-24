using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Organizer
{
    /// <summary>
    /// Represent the repeater
    /// </summary>
    public class Repeater : IRepeater
    {
        public Repeater(RepeatType type, uint value)
        {
            Type = type;
            Value = value;
        }

        #region IRepeater Member

        public uint Value
        {
            get;
            set;
        }

        public NextRepeating GetNextRepeating(DateTime date, uint repeatCount)
        {
            TimeSpan timeSpan = TimeSpan.Zero;

            switch (Type)
            {
                case RepeatType.Second:
                    timeSpan = TimeSpan.FromSeconds(Value * repeatCount);
                    break;
                case RepeatType.Minute:
                    timeSpan = TimeSpan.FromMinutes(Value * repeatCount);
                    break;
                case RepeatType.Hour:
                    timeSpan = TimeSpan.FromHours(Value * repeatCount);
                    break;
                case RepeatType.Day:
                    timeSpan = TimeSpan.FromDays(Value * repeatCount);
                    break;
                case RepeatType.Week:
                    timeSpan = TimeSpan.FromDays(Value * 7 * repeatCount);
                    break;
                case RepeatType.Month:
                    timeSpan = date - date.AddMonths((int)(Value * repeatCount));
                    break;
                case RepeatType.Year:
                    timeSpan = date - date.AddYears((int)(Value * repeatCount));
                    break;
                default:
                    throw new NotImplementedException();
            }

            return new NextRepeating(date, timeSpan);
        }

        #endregion

        /// <summary>
        /// Type of repeating
        /// </summary>
        public RepeatType Type
        {
            get;
            set;
        }
    }

    /// \addtogroup enums
    /// @{

    public enum RepeatType
    {
        Second,
        Minute,
        Hour,
        Day,
        Week,
        Month,
        Year
    }

    /// @}
}
