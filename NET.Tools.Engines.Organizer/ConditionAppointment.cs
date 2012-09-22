using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Organizer
{
    public class ConditionAppointment : IConditionAppointment
    {
        public ConditionAppointment(TimeSpan time, ICondition condition, TimeSpan length)
        {
            Condition = condition;
            Time = time;
            Length = length;
        }

        #region IConditionAppointment Member

        public ICondition Condition
        {
            get;
            set;
        }

        public TimeSpan Time
        {
            get;
            set;
        }

        #endregion

        #region IAppointment Member

        public TimeSpan Length
        {
            get;
            set;
        }

        public bool IsOnDate(DateTime date)
        {
            return CreateAppointmentEntitiesOnDate(date) != null;
        }

        public virtual IList<AppointmentEntity> CreateAppointmentEntitiesOnDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
