using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using NET.Tools;

namespace NET.Tools.Test
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für StreamExtensionsTest
    /// </summary>
    [TestClass]
    public class StreamExtensionsTest
    {
        public StreamExtensionsTest()
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
        public void TestStreamString()
        {
            String obj = "Hallo Welt!";

            using (MemoryStream ms = new MemoryStream())
            {
                ms.WriteString(obj);
                ms.Seek(0, SeekOrigin.Begin);
                String res = ms.ReadString();

                Assert.IsTrue(obj.Equals(res), "Streaming failed!");
            }
        }

        [TestMethod]
        public void TestStreamint()
        {
            int obj = 100;

            using (MemoryStream ms = new MemoryStream())
            {
                ms.WriteInteger(obj);
                ms.Seek(0, SeekOrigin.Begin);
                int res = ms.ReadInteger();

                Assert.IsTrue(obj.Equals(res), "Streaming failed!");
            }
        }

        [TestMethod]
        public void TestStreamshort()
        {
            short obj = 100;

            using (MemoryStream ms = new MemoryStream())
            {
                ms.WriteShort(obj);
                ms.Seek(0, SeekOrigin.Begin);
                short res = ms.ReadShort();

                Assert.IsTrue(obj.Equals(res), "Streaming failed!");
            }
        }

        [TestMethod]
        public void TestStreamlong()
        {
            long obj = 100;

            using (MemoryStream ms = new MemoryStream())
            {
                ms.WriteLong(obj);
                ms.Seek(0, SeekOrigin.Begin);
                long res = ms.ReadLong();

                Assert.IsTrue(obj.Equals(res), "Streaming failed!");
            }
        }

        [TestMethod]
        public void TestStreamfloat()
        {
            float obj = 100;

            using (MemoryStream ms = new MemoryStream())
            {
                ms.WriteFloat(obj);
                ms.Seek(0, SeekOrigin.Begin);
                float res = ms.ReadFloat();

                Assert.IsTrue(obj.Equals(res), "Streaming failed!");
            }
        }

        [TestMethod]
        public void TestStreamdouble()
        {
            double obj = 100;

            using (MemoryStream ms = new MemoryStream())
            {
                ms.WriteDouble(obj);
                ms.Seek(0, SeekOrigin.Begin);
                double res = ms.ReadDouble();

                Assert.IsTrue(obj.Equals(res), "Streaming failed!");
            }
        }

        [TestMethod]
        public void TestStreamchar()
        {
            char obj = ' ';

            using (MemoryStream ms = new MemoryStream())
            {
                ms.WriteChar(obj);
                ms.Seek(0, SeekOrigin.Begin);
                char res = ms.ReadChar();

                Assert.IsTrue(obj.Equals(res), "Streaming failed!");
            }
        }

        [TestMethod]
        public void TestStreambool()
        {
            bool obj = true;

            using (MemoryStream ms = new MemoryStream())
            {
                ms.WriteBoolean(obj);
                ms.Seek(0, SeekOrigin.Begin);
                bool res = ms.ReadBoolean();

                Assert.IsTrue(obj.Equals(res), "Streaming failed!");
            }
        }
    }
}
