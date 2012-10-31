using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Network
{
    /// <summary>
    /// Interface for all remoting connections
    /// </summary>
    public interface IRemoteConnection<T> : IConnection
    {
        /// <summary>
        /// Type of service object
        /// </summary>
        Type ServiceType { get; }
        /// <summary>
        /// Service object
        /// </summary>
        T ServiceObject { get; }
        /// <summary>
        /// Service name
        /// </summary>
        String ServiceName { get; set; }
    }
}
