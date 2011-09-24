using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NET.Tools.Engines.CommandLine
{
    /// <summary>
    /// Interface for all text arguments
    /// </summary>
    public interface ITextArgument
    {
        /// <summary>
        /// The regular expression for this text input
        /// </summary>
        Regex RegularExpression { get; }
        /// <summary>
        /// Name of text parameter
        /// </summary>
        String Name { get; }
    }
}
