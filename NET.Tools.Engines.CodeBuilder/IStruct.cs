using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.CodeBuilder
{
    /// <summary>
    /// Represent the interface for a typical struct
    /// </summary>
    public interface IStruct : IObjectDefinition, IStringBuilder
    {
        /// <summary>
        /// Gets the list of all implementated types. Must be a full string includes the namespace and the type name.
        /// </summary>
        IList<String> ImplementationTypeList { get; }
    }
}
