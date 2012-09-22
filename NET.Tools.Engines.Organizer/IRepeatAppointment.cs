using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Organizer
{
    /// <summary>
    /// For all repeatable appointments
    /// </summary>
    public interface IRepeatAppointment
    {
        /// <summary>
        /// Start of repeating
        /// </summary>
        DateTime StartDate { get; set; }
        /// <summary>
        /// End of repeating
        /// </summary>
        DateTime EndDate { get; set; }
        /// <summary>
        /// The repeater for the repeated appointment
        /// </summary>
        IRepeater Repeater { get; set; }
    }
}
