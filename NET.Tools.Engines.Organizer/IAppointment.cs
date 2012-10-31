using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Organizer
{
    /// <summary>
    /// Interface for all appointments objects
    /// </summary>
    public interface IAppointment
    {
        /// <summary>
        /// Length of the appointment
        /// </summary>
        TimeSpan Length { get; set; }
        /// <summary>
        /// TRUE if the appointment is on this date
        /// </summary>
        /// <param name="date">The date to check</param>
        /// <returns></returns>
        bool IsOnDate(DateTime date);
        /// <summary>
        /// Creates all appointment entities of himself on this date
        /// </summary>
        /// <param name="date">Date to check</param>
        /// <returns>The appointment entities or null if no this appointment on this date</returns>
        IList<AppointmentEntity> CreateAppointmentEntitiesOnDate(DateTime date);
    }
}
