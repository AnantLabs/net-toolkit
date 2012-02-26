using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.ASN1.ASN1
{
    /// <summary>
    /// Represent the abstract base for all ASN1 tags
    /// </summary>
    public abstract class ASN1Tag : ASN1Object, IASN1Tag
    {
        protected ASN1Tag(bool constructed)
        {
            IsConstructed = constructed;
        }

        #region IASN1Tag Member

        public bool IsConstructed
        {
            get;
            private set;
        }

        #endregion
    }
}
