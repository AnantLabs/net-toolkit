using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Organizer
{
    /// <summary>
    /// Represent an orenizer tool object
    /// </summary>
    public class Organizer
    {
        /// <summary>
        /// Active date of orenizer
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// List of all appointments
        /// </summary>
        public IList<IAppointment> AppointmentList { get; private set; }

        public Organizer(DateTime date)
        {
            AppointmentList = new List<IAppointment>();
            Date = date;
        }

        /// <summary>
        /// Creates the oranizer with the active date
        /// </summary>
        public Organizer()
            : this(DateTime.Now)
        {
        }

        public IList<AppointmentEntity> GetAppointmentsAt(DateTime date)
        {
            List<AppointmentEntity> res = new List<AppointmentEntity>();

            foreach (IAppointment app in AppointmentList)
            {
                IList<AppointmentEntity> list = app.CreateAppointmentEntitiesOnDate(date);
                if (list != null)
                    res.AddRange(app.CreateAppointmentEntitiesOnDate(date));
            }

            return res;
        }

        public IList<AppointmentEntity> GetAppointmentsAt()
        {
            return GetAppointmentsAt(Date);
        }
    }
}
