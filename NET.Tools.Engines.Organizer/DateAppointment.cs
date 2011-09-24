using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Organizer
{
    /// <summary>
    /// A default appointment object
    /// </summary>
    public class DateAppointment : IDateAppointment
    {
        public DateAppointment(DateTime date, TimeSpan length)
        {
            Date = date;
            Length = length;
        }

        #region IDateAppointment Member

        public DateTime Date
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

        public DateTime End
        {
            get { return Date + Length; }
        }

        public bool IsOnDate(DateTime date)
        {
            return CreateAppointmentEntitiesOnDate(date) != null;
        }

        public virtual IList<AppointmentEntity> CreateAppointmentEntitiesOnDate(DateTime date)
        {
            if ((date >= Date) && (date <= End))
            {
                List<AppointmentEntity> res = new List<AppointmentEntity>();
                res.Add(new AppointmentEntity(this, Date, Length));
                return res;
            }

            return null;
        }

        #endregion
    }
}
