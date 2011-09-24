using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    public class ExceptionEventArgs : EventArgs
    {
        public Exception ThrownException { get; private set; }
        public String AdditionalMessage { get; private set; }

        public ExceptionEventArgs(String addMsg, Exception e)
        {
            AdditionalMessage = addMsg;
            ThrownException = e;
        }

        public ExceptionEventArgs(Exception e)
            : this("", e)
        {
        }
    }

    public delegate void ExceptionEventHandler(object sender, ExceptionEventArgs arg);
}
