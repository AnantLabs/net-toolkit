using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Organizer
{
    /// <summary>
    /// Interface for all repeater
    /// </summary>
    public interface IRepeater
    {
        /// <summary>
        /// Repeat value
        /// </summary>
        uint Value { get; set; }
        /// <summary>
        /// Gets the next repeating started by the given date
        /// </summary>
        /// <param name="date">Date of start</param>
        /// <param name="repeatCount">Count of repeating</param>
        /// <returns>The next repeating</returns>
        NextRepeating GetNextRepeating(DateTime date, uint repeatCount);
    }

    public class NextRepeating
    {
        /// <summary>
        /// Length since the start date
        /// </summary>
        public TimeSpan Length { get; private set; }
        /// <summary>
        /// Destination date (next appointment)
        /// </summary>
        public DateTime DestinationDate { get { return SourceDate + Length; } }
        /// <summary>
        /// Source date (first appointment)
        /// </summary>
        public DateTime SourceDate { get; private set; }

        public NextRepeating(DateTime sourceDate, TimeSpan length)
        {
            Length = length;
            SourceDate = sourceDate;
        }
    }
}
