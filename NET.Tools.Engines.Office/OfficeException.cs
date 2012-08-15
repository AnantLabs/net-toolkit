using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NET.Tools.Engines.Office
{
    /// \addtogroup office
    /// @{

    [Serializable]
    public class OfficeException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public OfficeException()
        {
        }

        public OfficeException(string message) : base(message)
        {
        }

        public OfficeException(string message, Exception inner) : base(message, inner)
        {
        }

        protected OfficeException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }

    /// @}
}
