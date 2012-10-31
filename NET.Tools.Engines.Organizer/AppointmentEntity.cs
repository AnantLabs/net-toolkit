using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Organizer
{
    /// <summary>
    /// Represent a indivudual appointment independency of this parent object
    /// </summary>
    public sealed class AppointmentEntity : DateAppointment
    {
        internal AppointmentEntity(IAppointment source, DateTime date, TimeSpan length, 
            uint repeating, bool isRepeated)
            : base(date, length)
        {
            Repeating = repeating;
            IsRepeated = isRepeated;
            Source = source;
        }

        internal AppointmentEntity(IAppointment source, DateTime date, TimeSpan length)
            : this(source, date, length, 0, false)
        {
        }

        /// <summary>
        /// The repeating number of this appointment
        /// </summary>
        public uint Repeating
        {
            get;
            private set;
        }

        /// <summary>
        /// Information about the repeat state
        /// </summary>
        public bool IsRepeated
        {
            get;
            private set;
        }

        public IAppointment Source
        {
            get;
            private set;
        }
    }
}
