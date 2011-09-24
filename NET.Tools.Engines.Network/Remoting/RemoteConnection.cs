using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;

namespace NET.Tools.Engines.Network
{
    /// <summary>
    /// Abtract class for all remote connections (client and service)
    /// </summary>
    /// <typeparam name="T">The remoting object type</typeparam>
    public abstract class RemoteConnection<T> : IRemoteConnection<T>
    {
        public Type ServiceType { get; private set; }
        public T ServiceObject { get; protected set; }
        public String ServiceName { get; set; }

        private IChannel channel;

        public RemoteConnection(IPAddress ip, ushort port, string serviceName)
        {
            IP = ip;
            Port = port;
            ServiceType = typeof(T);
            ServiceName = serviceName;
            ServiceObject = default(T);
            IsConnected = false;

        }

        #region IConnection Member

        public virtual void Connect()
        {
            if (IsConnected)
                throw new InvalidOperationException("Client is already connected!");

            channel = CreateChannel();
            ChannelServices.RegisterChannel(channel, false);
            if (!ConnectInternal())
            {
                ChannelServices.UnregisterChannel(channel);
                return;
            }

            IsConnected = true;
        }

        public virtual void Disconnect()
        {
            if (!IsConnected)
                throw new InvalidOperationException("Client is not connected!");

            ServiceObject = default(T);
            ChannelServices.UnregisterChannel(channel);
            channel = null;
            IsConnected = false;
        }

        public virtual IPAddress IP
        {
            get;
            set;
        }

        public virtual ushort Port
        {
            get;
            set;
        }

        public virtual bool IsConnected
        {
            get;
            private set;
        }

        #endregion

        /// <summary>
        /// Connect to the service or start of service
        /// </summary>
        /// <returns></returns>
        protected abstract bool ConnectInternal();
        protected abstract IChannel CreateChannel();
        protected abstract String ChannelProtocolName { get; }

        public virtual void Dispose()
        {
            if (IsConnected)
                Disconnect();
        }

        public override string ToString()
        {
            return ChannelProtocolName + "://" + IP.ToString() + ":" + Port + "/" + ServiceName;
        }
    }
}
