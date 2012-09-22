using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace NET.Tools.Engines.Network
{
    /// <summary>
    /// Represent a class for a client for updating processes via internet
    /// 
    /// <example>
    /// This code shows you to create an update client:
    /// <code>
    /// using (UpdateClient{IUpdateServer} client =
    ///                new UpdateClient{IUpdateServer}(new IPAddress(new byte[] { 127, 0, 0, 1 }), 50315, "Updater"))
    ///            {
    ///                client.Connect();                
    ///                if (client.ServiceObject.CheckForUpdate(CurrentVersion))
    ///                {
    ///                     using(IFileLoader fileLoader = new StreamFileLoader("C:\Temp\Seup.exe"))
    ///                     {
    ///                         client.ServiceObject.DownloadUpdate(fileLoader);
    ///                     }
    ///                }                
    ///                client.Disconnect();
    ///            }
    /// </code>
    /// </example>
    /// </summary>
    /// <seealso cref="UpdateServer"/>
    /// <seealso cref="DefaultUpdateServer"/>
    /// <seealso cref="IFileLoader"/>
    /// <seealso cref="StreamFileLoader"/>
    /// <typeparam name="T">Type of the service object. Must be a class from the interface IUpdateServer</typeparam>
    public sealed class UpdateClient<T> : IConnection where T : IUpdateServer
    {
        private RemoteTCPClient<T> client;

        public UpdateClient(IPAddress ip, ushort port, string serviceName)
        {
            client = new RemoteTCPClient<T>(ip, port, serviceName);
        }

        #region IConnection Member

        public void Connect()
        {
            client.Connect();
        }

        public void Disconnect()
        {
            client.Disconnect();
        }

        public IPAddress IP
        {
            get
            {
                return client.IP;
            }
            set
            {
                client.IP = value;
            }
        }

        public ushort Port
        {
            get
            {
                return client.Port;
            }
            set
            {
                client.Port = value;
            }
        }

        public bool IsConnected
        {
            get { return client.IsConnected; }
        }

        #endregion

        #region IDisposable Member

        public void Dispose()
        {
            client.Dispose();
        }

        #endregion

        /// <summary>
        /// The updater service object
        /// </summary>
        public T ServiceObject
        {
            get { return client.ServiceObject; }
        }
    }
}
