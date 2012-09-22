using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    [Serializable]
    public class Graphics3DSystemNotFoundException : Graphics3DException
    {
        public Graphics3DSystemNotFoundException() { }
        public Graphics3DSystemNotFoundException(string message) : base(message) { }
        public Graphics3DSystemNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected Graphics3DSystemNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
