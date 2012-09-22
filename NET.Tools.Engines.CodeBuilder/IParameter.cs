using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.CodeBuilder
{
    /// <summary>
    /// Represent a typical parameter
    /// </summary>
    public interface IParameter : IStringBuilder
    {
        /// <summary>
        /// Gets or sets the type of this parameter
        /// </summary>
        Type ParameterType { get; set; }
    }
}
