using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.CodeBuilder
{
    /// <summary>
    /// Represent the interface for a typical namespace
    /// </summary>
    public interface INameSpace : IStringBuilder
    {
        /// <summary>
        /// Gets or sets the full quality name of the namespace
        /// </summary>
        String Name { get; set; }

        /// <summary>
        /// Gets the list of all in this namespace defined basic elements
        /// </summary>
        IList<IObjectDefinition> BasicElementList { get; }
    }
}
