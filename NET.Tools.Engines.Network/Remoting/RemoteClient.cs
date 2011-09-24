using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Net;

namespace NET.Tools.Engines.Network
{
    public abstract class RemoteClient<T> : RemoteConnection<T>
    {
        public RemoteClient(IPAddress ip, ushort port, string serviceName)
            : base(ip, port, serviceName)
        {
        }

        protected override bool ConnectInternal()
        {
            ServiceObject = (T)Activator.GetObject(ServiceType,
                ChannelProtocolName + "://" + IP.ToString() + ":" + Port + "/" + ServiceName);

            if (ServiceObject == null)
                throw new Exception("Cannot connect to service!");

            return true;
        }
    }
}
