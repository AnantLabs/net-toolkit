using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;

namespace NET.Tools.Engines.Network
{
    /// <summary>
    /// Represent a class for a service for updating processes via internet
    /// 
    /// <example>
    /// This code example shows you to create a update service:
    /// <code>
    /// using (UpdateService{TestUpdateServer} service = 
    ///            new UpdateService{TestUpdateServer}(50315, "Updater"))
    ///        {
    ///            service.Connect();            
    ///            while(true)
    ///            {
    ///            }            
    ///            service.Disconnect();
    ///        }
    /// </code>
    /// </example>
    /// </summary>
    /// <seealso cref="UpdateServer"/>
    /// <seealso cref="DefaultUpdateServer"/>
    /// <typeparam name="T">The type of the service object. Must be a class inherited from the UpdateServer class</typeparam>
    public sealed class UpdateService<T> : IConnection where T : UpdateServer
    {
        private RemoteTCPService<T> service;

        public UpdateService(ushort port, string serviceName)
        {
            service = new RemoteTCPService<T>(port, serviceName, WellKnownObjectMode.Singleton);
        }

        #region IConnection Member

        public void Connect()
        {
            service.Connect();
        }

        public void Disconnect()
        {
            service.Disconnect();
        }

        public System.Net.IPAddress IP
        {
            get
            {
                return service.IP;
            }
            set
            {
                service.IP = value;
            }
        }

        public ushort Port
        {
            get
            {
                return service.Port;
            }
            set
            {
                service.Port = value;
            }
        }

        public bool IsConnected
        {
            get { return service.IsConnected; }
        }

        #endregion

        #region IDisposable Member

        public void Dispose()
        {
            service.Dispose();
        }

        #endregion
    }
}
