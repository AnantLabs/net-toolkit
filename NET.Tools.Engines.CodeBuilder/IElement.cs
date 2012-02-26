using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.CodeBuilder
{
    /// <summary>
    /// Represent the acess types
    /// </summary>
    public enum AccessType
    {
        /// <summary>
        /// Private access
        /// </summary>
        Private,
        /// <summary>
        /// Protected access
        /// </summary>
        Protected,
        /// <summary>
        /// Default access
        /// </summary>
        Default,
        /// <summary>
        /// Internal access (can result the same like Default)
        /// </summary>
        Internal,
        /// <summary>
        /// Public access
        /// </summary>
        Public
    }

    /// <summary>
    /// Represent a typical element
    /// </summary>
    public interface IElement : IStringBuilder
    {
        /// <summary>
        /// Gets or sets the name of this attribute
        /// </summary>
        String Name { get; set; }
        /// <summary>
        /// Gets or sets the access type
        /// </summary>
        AccessType AccessType { get; set; }
    }
}
