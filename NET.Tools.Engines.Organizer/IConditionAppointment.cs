using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Organizer
{
    /// <summary>
    /// Represent an interface for all condition appointments
    /// </summary>
    public interface IConditionAppointment : IAppointment
    {
        /// <summary>
        /// The condition of this appointment
        /// </summary>
        ICondition Condition { get; set; }
        /// <summary>
        /// Only the time of the appointment
        /// </summary>
        TimeSpan Time { get; set; }
    }
}
