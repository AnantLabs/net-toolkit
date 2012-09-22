using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting;
using System.Collections;

namespace NET.Tools.Engines.Network
{
    /// <summary>
    /// Represent a tcp/ip remote service
    /// </summary>
    /// <typeparam name="T">Type of the service object. Must be inherited from the class MarshalByRefObject</typeparam>
    /// <example>
    /// This example shows you to create a tcp/ip remote service:
    /// <code>
    /// using (RemoteTCPService{RemoteService} service =
    ///               new RemoteTCPService{RemoteService}(50315, "TestRemoting", WellKnownObjectMode.Singleton))
    ///        {
    ///            service.Connect();
    ///            while(true)
    ///            {
    ///            }
    ///            service.Disconnect();
    ///        }
    /// </code>
    /// Remote Service:
    /// <code>
    /// public class RemoteService : MarshalByRefObject, IRemoteService
    /// {
    ///    #region IRemoteService Member
    ///
    ///    public double Add(double a, double b)
    ///    {
    ///        return a + b;
    ///    }
    ///
    ///    public double Mul(double a, double b)
    ///    {
    ///        return a * b;
    ///    }
    ///
    ///    public double Div(double a, double b)
    ///    {
    ///        return a / b;
    ///    }
    ///
    ///    public double Sub(double a, double b)
    ///    {
    ///        return a - b;
    ///    }
    ///
    ///    #endregion
    /// }
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
    public sealed class RemoteTCPService<T> : RemoteService<T> where T : MarshalByRefObject
    {
        public RemoteTCPService(ushort port, string serviceName, WellKnownObjectMode mode)
            : base(port, serviceName, mode)
        {
        }

        protected override IChannel CreateChannel()
        {
            IDictionary prop = new Hashtable();
            prop["name"] = ServiceName;
            prop["port"] = Port;

            SoapClientFormatterSinkProvider clientProvider = new SoapClientFormatterSinkProvider();
            SoapServerFormatterSinkProvider serverProvider = new SoapServerFormatterSinkProvider();
            serverProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

            return new TcpChannel(prop, clientProvider, serverProvider);
        }

        protected override string ChannelProtocolName
        {
            get { return "tcp"; }
        }
    }
}
