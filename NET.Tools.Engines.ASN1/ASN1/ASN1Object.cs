using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.ASN1
{
    public abstract class ASN1Object : IASN1Object
    {
        public const int ASN1_TAG_BIT = 0x80;
        public const int ASN1_APPLICATION_BIT = 0x40;
        public const int ASN1_CONSTRUCT_BIT = 0x20;

        /// <summary>
        /// Generate the encoded byte array 
        /// </summary>
        /// <returns></returns>
        protected abstract byte[] toASN1();

        #region IASN1Object Member

        public byte[] Encoded
        {
            get { return toASN1(); }
        }

        #endregion
    }
}
