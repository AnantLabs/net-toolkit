using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.ASN1
{
    [global::System.Serializable]
    public class ASN1LengthException : ASN1Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public ASN1LengthException() { }
        public ASN1LengthException(string message) : base(message) { }
        public ASN1LengthException(string message, Exception inner) : base(message, inner) { }
        protected ASN1LengthException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

        public static ASN1LengthException GenerateShortLengthException()
        {
            return new ASN1LengthException("There is a wrong length format: " + 
                "It is given a buffer with only one byte but found was a long length format (greater 0x80)!");
        }

        public static ASN1LengthException GenerateLongLengthException()
        {
            return new ASN1LengthException("There is a wrong length format: " +
                "It is given a buffer with more than one byte but found was a short length format (smaller 0x80)!");
        }
    }
}
