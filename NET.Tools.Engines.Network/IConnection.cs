using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace NET.Tools.Engines.Network
{
    /// <summary>
    /// Interface for all connections
    /// </summary>
    public interface IConnection : IDisposable
    {
        void Connect();
        void Disconnect();

        IPAddress IP { get; set; }
        ushort Port { get; set; }

        bool IsConnected { get; }
    }
}
