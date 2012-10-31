using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Organizer
{
    /// <summary>
    /// Represent an interface for all date appointments on a fixed datetime
    /// </summary>
    public interface IDateAppointment : IAppointment
    {
        /// <summary>
        /// Date of appointment
        /// </summary>
        DateTime Date { get; set; }
    }
}
