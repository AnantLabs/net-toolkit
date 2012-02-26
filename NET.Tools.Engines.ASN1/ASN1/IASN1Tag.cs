using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.ASN1.ASN1
{
    /// <summary>
    /// Interface for ASN1 Tags
    /// </summary>
    public interface IASN1Tag
    {
        /// <summary>
        /// Gets the value that the object is constructed or not
        /// </summary>
        bool IsConstructed { get; }
    }
}
