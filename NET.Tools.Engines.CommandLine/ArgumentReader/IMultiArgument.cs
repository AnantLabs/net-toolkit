using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace NET.Tools.Engines.CommandLine
{
    /// <summary>
    /// Interface for all arguments they can be more than one times 
    /// </summary>
    public interface IMultiArgument<T>
    {
        /// <summary>
        /// List of values (or only one item if IsSeveralTimes is false)
        /// <remarks>
        /// Object can be only:
        /// - String
        /// - Int32
        /// - Double
        /// </remarks>
        /// </summary>
        ReadOnlyCollection<T> ValueList { get; }
        /// <summary>
        /// Gets the first value of the value list
        /// </summary>
        T Value { get; }
    }
}
