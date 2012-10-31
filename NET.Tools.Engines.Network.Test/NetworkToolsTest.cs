using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Remoting;
using System.Net;
using System.IO;

namespace NET.Tools.Engines.Network.Test
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für NetworkToolsTest
    /// </summary>
    [TestClass]
    public class NetworkToolsTest
    {
        public NetworkToolsTest()
        {
            //
            // TODO: Konstruktorlogik hier hinzufügen
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Ruft den Textkontext mit Informationen über
        ///den aktuellen Testlauf sowie Funktionalität für diesen auf oder legt diese fest.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Zusätzliche Testattribute
        //
        // Sie können beim Schreiben der Tests folgende zusätzliche Attribute verwenden:
        //
        // Verwenden Sie ClassInitialize, um vor Ausführung des ersten Tests in der Klasse Code auszuführen.
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Verwenden Sie ClassCleanup, um nach Ausführung aller Tests in einer Klasse Code auszuführen.
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Mit TestInitialize können Sie vor jedem einzelnen Test Code ausführen. 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestRemoting()
        {
            using (RemoteTCPService<RemoteService> service =
                   new RemoteTCPService<RemoteService>(50315, "TestRemoting", WellKnownObjectMode.Singleton))
            {
                service.Connect();

                using (RemoteTCPClient<IRemoteService> client =
                    new RemoteTCPClient<IRemoteService>(new IPAddress(new byte[] { 127, 0, 0, 1 }), 50315, "TestRemoting"))
                {
                    client.Connect();

                    Assert.IsTrue(client.ServiceObject.Add(1.2d, 3.5d) == (1.2d + 3.5d), "Wrong add!");
                    Assert.IsTrue(client.ServiceObject.Sub(1.2d, 3.5d) == (1.2d - 3.5d), "Wrong add!");
                    Assert.IsTrue(client.ServiceObject.Div(1.2d, 3.5d) == (1.2d / 3.5d), "Wrong add!");
                    Assert.IsTrue(client.ServiceObject.Mul(1.2d, 3.5d) == (1.2d * 3.5d), "Wrong add!");

                    client.Disconnect();
                }

                service.Disconnect();
            }
        }

        [TestMethod]
        public void TestUpdater()
        {
            using (UpdateService<TestUpdateServer> service = 
                new UpdateService<TestUpdateServer>(51315, "Updater"))
            {
                service.Connect();

                using (UpdateClient<IUpdateServer> client =
                    new UpdateClient<IUpdateServer>(new IPAddress(new byte[] { 127, 0, 0, 1 }), 51315, "Updater"))
                {
                    client.Connect();

                    Assert.IsTrue(client.ServiceObject.CheckForUpdate(new Version(1, 0)), "Version check failed!");
                    Assert.IsFalse(client.ServiceObject.CheckForUpdate(new Version(2, 0)), "Version check not failed!");
                    Assert.IsFalse(client.ServiceObject.CheckForUpdate(new Version(3, 0)), "Version check not failed!");

                    using (IFileLoader loader = new StreamFileLoader(new MemoryStream()))
                    {
                        client.ServiceObject.DownloadUpdate(loader);
                    }

                    client.Disconnect();
                }

                service.Disconnect();
            }
        }
    }
}
