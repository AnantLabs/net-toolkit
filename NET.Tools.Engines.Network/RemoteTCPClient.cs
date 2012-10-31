using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Net;
using System.Collections;

namespace NET.Tools.Engines.Network
{
    /// <summary>
    /// Represent a class to create a tcp/ip remote client
    /// </summary>
    /// <typeparam name="T">The service type</typeparam>
    /// <example>
    /// This example shows you to create a tcp/ip remote client:
    /// <code>
    /// using (RemoteTCPClient{IRemoteService} client =
    ///                new RemoteTCPClient{IRemoteService}(new IPAddress(new byte[] { 127, 0, 0, 1 }), 50315, "TestRemoting"))
    ///            {
    ///                client.Connect();
    ///
    ///                Assert.IsTrue(client.ServiceObject.Add(1.2d, 3.5d) == (1.2d + 3.5d), "Wrong add!");
    ///                Assert.IsTrue(client.ServiceObject.Sub(1.2d, 3.5d) == (1.2d - 3.5d), "Wrong add!");
    ///                Assert.IsTrue(client.ServiceObject.Div(1.2d, 3.5d) == (1.2d / 3.5d), "Wrong add!");
    ///                Assert.IsTrue(client.ServiceObject.Mul(1.2d, 3.5d) == (1.2d * 3.5d), "Wrong add!");
    ///
    ///                client.Disconnect();
    ///            }
    /// </code>
    /// IRemoteService:
    /// <code>
    /// public interface IRemoteService
    /// {
    ///    double Add(double a, double b);
    ///    double Mul(double a, double b);
    ///    double Div(double a, double b);
    ///    double Sub(double a, double b);
    /// }
    /// </code>
    /// </example>
    public sealed class RemoteTCPClient<T> : RemoteClient<T>
    {
        public RemoteTCPClient(IPAddress ip, ushort port, string serviceName)
            : base(ip, port, serviceName)
        {
        }

        protected override IChannel CreateChannel()
        {
            IDictionary prop = new Hashtable();
            prop["name"] = "";
            prop["port"] = 0;

            SoapClientFormatterSinkProvider clientProvider = new SoapClientFormatterSinkProvider();
            SoapServerFormatterSinkProvider serverProvider = new SoapServerFormatterSinkProvider();
            serverProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

            return new TcpChannel(prop, clientProvider, serverProvider);
        }

        protected override string ChannelProtocolName
        {
            get
            {
                return "tcp";
            }
        }
    }
}
