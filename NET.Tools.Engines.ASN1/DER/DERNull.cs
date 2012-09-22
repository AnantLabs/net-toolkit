using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.ASN1
{
    /// <summary>
    /// Represent a DERNull
    /// </summary>
    public sealed class DERNull : ASN1Null
    {
        public static DERNull FromByteArray(byte[] buffer)
        {
            if (buffer.Length < 2)
                throw ASN1DecodingException.GenerateDefaultException(typeof(DERNull));

            if (buffer[0] != ASN1Null.ASN1_NULL_TAG)
                throw ASN1DecodingException.GenerateDefaultException(typeof(DERNull));

            if (buffer[1] != 0x00)
                throw ASN1DecodingException.GenerateDefaultException(typeof(DERNull));

            return new DERNull();
        }

        public DERNull()
        {            
        }

        protected override byte[] toASN1()
        {
            return new byte[] { ASN1Null.ASN1_NULL_TAG, 0x00 };
        }
    }
}
