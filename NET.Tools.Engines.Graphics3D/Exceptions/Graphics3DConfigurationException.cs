﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D.Exceptions
{
    [global::System.Serializable]
    public class Graphics3DConfigurationException : Graphics3DException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public Graphics3DConfigurationException() { }
        public Graphics3DConfigurationException(string message) : base(message) { }
        public Graphics3DConfigurationException(string message, Exception inner) : base(message, inner) { }
        protected Graphics3DConfigurationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
