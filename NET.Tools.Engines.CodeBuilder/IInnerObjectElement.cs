using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.CodeBuilder
{
    /// <summary>
    /// Represent a typical inner object element like attribute, property or method
    /// </summary>
    public interface IInnerObjectElement : IElement, IStringBuilder
    {
        /// <summary>
        /// Gets or sets the static state
        /// </summary>
        bool IsStatic { get; set; }
        /// <summary>
        /// Gets or sets the type of this inner object element. In case of a method definition it represent the result value or NULL if it is a void method.
        /// </summary>
        Type Type { get; set; }
    }
}
