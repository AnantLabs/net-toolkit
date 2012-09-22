using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Organizer
{
    /// <summary>
    /// A repeat appointment object for a fixed date
    /// </summary>
    public class RepeatDateAppointment : DateAppointment, IRepeatAppointment
    {
        public RepeatDateAppointment(DateTime startDate, TimeSpan length, DateTime endDate,
            IRepeater repeater)
            : base(startDate, length)
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
            if ((date < StartDate) || (date > EndDate))
                return null;

            List<AppointmentEntity> res = new List<AppointmentEntity>();

            uint counter = 0;
            while (true)
            {
                //Count the repeating
                counter++;
                //Compute the next repeating appointment date
                NextRepeating repeating = Repeater.GetNextRepeating(StartDate, counter);
                //Check the appointment with the date and add itr to list
                if ((repeating.DestinationDate >= date) &&
                    (repeating.DestinationDate + Length <= date))
                    res.Add(new AppointmentEntity(this, repeating.DestinationDate, 
                        Length, counter, true));
                //Check the end of the action if the repeater date is greader than 
                //the checked date
                if (repeating.DestinationDate + Length > date)
                    break;
            }

            return res;
        }
    }
}
