using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.CodeBuilder
{
    /// <summary>
    /// Represent the type of this object
    /// </summary>
    public enum ClassModifier
    {
        /// <summary>
        /// Class is sealed
        /// </summary>
        Sealed,
        /// <summary>
        /// Class is abstract
        /// </summary>
        Abstract,
        /// <summary>
        /// Class is static
        /// </summary>
        Static,
        /// <summary>
        /// Class has no modifier
        /// </summary>
        None
    }

    /// <summary>
    /// Represent the interface for a typical class
    /// </summary>
    public interface IClass : IObjectDefinition, IStringBuilder
    {
        /// <summary>
        /// Gets or sets the class modifier
        /// </summary>
        ClassModifier ClassModifier { get; set; }
        /// <summary>
        /// Gets or sets the extension type. Must be a full string includes the namespace and the type name.
        /// </summary>
        String ExtensionType { get; set; }
        /// <summary>
        /// Gets the list of all implementated types. Must be a full string includes the namespace and the type name.
        /// </summary>
        IList<String> ImplementationTypeList { get; }
    }
}
