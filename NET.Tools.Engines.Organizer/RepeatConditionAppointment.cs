using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Organizer
{
    /// <summary>
    /// A repeat appointment object for a condition
    /// </summary>
    public class RepeatConditionAppointment : ConditionAppointment, IRepeatAppointment
    {
        public RepeatConditionAppointment(TimeSpan time, ICondition condition, TimeSpan length,
            DateTime startDate, DateTime endDate, IRepeater repeater)
            : base(time, condition, length)
        {
            StartDate = startDate;
            EndDate = endDate;
            Repeater = repeater;
        }

        #region IRepeatAppointment Member

        public DateTime StartDate
        {
            get;
            set;
        }

        public DateTime EndDate
        {
            get;
            set;
        }

        public IRepeater Repeater
        {
            get;
            set;
        }

        #endregion

        public override IList<AppointmentEntity> CreateAppointmentEntitiesOnDate(DateTime date)
        {
            return base.CreateAppointmentEntitiesOnDate(date);
        }
    }
}
