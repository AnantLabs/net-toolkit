using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.ASN1
{
    [global::System.Serializable]
    public class ASN1DecodingException : ASN1Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public ASN1DecodingException() { }
        public ASN1DecodingException(string message) : base(message) { }
        public ASN1DecodingException(string message, Exception inner) : base(message, inner) { }
        protected ASN1DecodingException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

        public static ASN1DecodingException GenerateDefaultException(Type type)
        {
            return new ASN1DecodingException("Unable to decode byte buffer to " + type.Name + "!");
        }
    }
}
