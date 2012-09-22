using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.ASN1
{
    public sealed class DERInteger : ASN1Integer
    {
        private long value;

        protected override byte[] toASN1()
        {
            List<byte> lst = new List<byte>();

            //Tag
            lst.Add(ASN1Integer.ASN1_INTEGER_TAG);
            //Length
            lst.AddRange(DERUtility.EncodeLength((value / 256) + 1));

            return null;//TODO
        }
    }
}
