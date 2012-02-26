using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.CodeBuilder
{
    /// <summary>
    /// Represent the initialization type
    /// </summary>
    public enum InitializeType
    {
        /// <summary>
        /// Direct initialization:
        /// <code>
        /// private int i = 1;
        /// </code>
        /// </summary>
        Direct,
        /// <summary>
        /// Constructor initialization:
        /// <code>
        /// public MyClass()
        /// {
        ///     i = 1;
        /// }
        /// </code>
        /// </summary>
        Constructor
    }

    /// <summary>
    /// Represent an interface for a typical attribute
    /// </summary>
    public interface IAttribute : IInnerObjectElement, IStringBuilder
    {        
        /// <summary>
        /// Gets or sets thge initial value
        /// </summary>
        Object InitialValue { get; set; }
        /// <summary>
        /// Gets or sets the type of initialization 
        /// </summary>
        InitializeType InitializeType { get; set; }
    }
}
