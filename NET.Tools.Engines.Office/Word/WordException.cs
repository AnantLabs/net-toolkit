using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NET.Tools.Engines.Office.Word
{
    /// \addtogroup office_word
    /// @{
    
    [Serializable]
    public class WordException : OfficeException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public WordException()
        {
        }

        public WordException(string message) : base(message)
        {
        }

        public WordException(string message, Exception inner) : base(message, inner)
        {
        }

        protected WordException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }

    /// @}
}
