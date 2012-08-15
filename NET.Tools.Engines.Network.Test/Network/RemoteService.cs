using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Network.Test
{
    public class RemoteService : MarshalByRefObject, IRemoteService
    {
        #region IRemoteService Member

        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Mul(double a, double b)
        {
            return a * b;
        }

        public double Div(double a, double b)
        {
            return a / b;
        }

        public double Sub(double a, double b)
        {
            return a - b;
        }

        #endregion
    }
}
