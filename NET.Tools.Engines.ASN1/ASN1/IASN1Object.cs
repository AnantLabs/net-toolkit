using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.ASN1
{
    /// <summary>
    /// Represent the basic interface for all ASN1 Objects
    /// </summary>
    public interface IASN1Object
    {
        /// <summary>
        /// Gets the encoded byte array
        /// </summary>
        byte[] Encoded { get; }
    }
}
