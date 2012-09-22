using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Net;

namespace NET.Tools.Engines.Network
{
    public abstract class RemoteService<T> : RemoteConnection<T> where T : MarshalByRefObject
    {
        public WellKnownObjectMode ObjectMode { get; set; }

        public RemoteService(ushort port, string serviceName, WellKnownObjectMode mode)
            : base(Dns.GetHostAddresses(Dns.GetHostName())[0], port, serviceName)
        {
            ObjectMode = mode;
        }

        protected override bool ConnectInternal()
        {
            RemotingConfiguration.RegisterWellKnownServiceType(
                ServiceType, ServiceName, ObjectMode);

            return true;
        }
    }
}
