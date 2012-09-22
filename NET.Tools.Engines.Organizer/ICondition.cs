using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Organizer
{
    /// <summary>
    /// Represent an interface for all condition objects
    /// </summary>
    public interface ICondition
    {
        /// <summary>
        /// Type of counter
        /// </summary>
        CounterType CounterType { get; set; }
        /// <summary>
        /// Compute all dates for this condition
        /// </summary>
        /// <param name="start">Start date of searching</param>
        /// <param name="end">End date of searching</param>
        IList<DateTime> GetDates(DateTime start, DateTime end);
    }

    /// \addtogroup enums
    /// @{

    public enum CounterType
    {
        /// <summary>
        /// Count from front
        /// </summary>
        Front,
        /// <summary>
        /// Count from back
        /// </summary>
        Back
    }
    /// @}
}
