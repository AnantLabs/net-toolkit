using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.CommandLine
{
    /// <summary>
    /// Interface for a defualt argument
    /// </summary>
    /// <see cref="PureArgument{T}"/>
    /// <see cref="SwitchArgument"/>
    /// <see cref="SwitchedContentArgument{T}"/>
    public interface IArgument
    {
        /// <summary>
        /// TRUE, if the argument is set
        /// </summary>
        bool IsSet { get; }
        /// <summary>
        /// TRUE, if the argument is optional
        /// </summary>
        bool IsOptional {get;}
        /// <summary>
        /// TRUE, if the argument can set more than one times 
        /// </summary>
        bool IsSeveralTimes { get; }
        /// <summary>
        /// Represent the helptext if the help page is shown
        /// </summary>
        String HelpText { get; }
        /// <summary>
        /// Represent an errortext if the argument check has failed
        /// <remarks>
        /// Use %message% to put in the real error message (<b>only in english</b>)
        /// </remarks>
        /// </summary>
        String ErrorText { get; }
        /// <summary>
        /// Get the level of this argument (for the order)
        /// </summary>
        int Level { get; }

        /// <summary>
        /// Check the given argument
        /// </summary>
        /// <param name="arg">Argument</param>
        /// <returns>The result of this method</returns>
        /// <see cref="ArgumentCheckResult"/>
        ArgumentCheckResult Check(String arg);
        /// <summary>
        /// Reset the active argument
        /// </summary>
        void Reset();
    }
}
