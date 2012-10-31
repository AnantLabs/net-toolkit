using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.CommandLine
{
    /// <summary>
    /// Interface for switch arguments
    /// </summary>
    public interface ISwitchArgument
    {
        /// <summary>
        /// Represent the switch
        /// </summary>
        String Switch { get;}
        /// <summary>
        /// Represent the switch character
        /// </summary>
        SwitchCharacter SwitchCharacter { get; }
    }
}
