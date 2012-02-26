using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.ASN1
{
    public abstract class ASN1Null : ASN1Object
    {
        public const byte ASN1_NULL_TAG = 0x05;
    }
}
