using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.Tools;

namespace NET.Tools.Test
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für BytesTest
    /// </summary>
    [TestClass]
    public class BytesTest
    {
        public BytesTest()
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
        public void TestIntBytes()
        {
            int i = 100;
            byte[] bytes = i.ToBytes();
            int j = i.FromBytes(bytes);

            Assert.IsTrue(bytes.Length == sizeof(int), "False buffer length!");
            Assert.IsTrue(i == j, "False number before and after!");
        }

        [TestMethod]
        public void TestLongBytes()
        {
            long i = 100;
            byte[] bytes = i.ToBytes();
            long j = i.FromBytes(bytes);

            Assert.IsTrue(bytes.Length == sizeof(long), "False buffer length!");
            Assert.IsTrue(i == j, "False number before and after!");
        }

        [TestMethod]
        public void TestShortBytes()
        {
            short i = 100;
            byte[] bytes = i.ToBytes();
            short j = i.FromBytes(bytes);

            Assert.IsTrue(bytes.Length == sizeof(short), "False buffer length!");
            Assert.IsTrue(i == j, "False number before and after!");
        }

        [TestMethod]
        public void TestDoubleBytes()
        {
            double i = 100.12345d;
            byte[] bytes = i.ToBytes();
            double j = i.FromBytes(bytes);

            Assert.IsTrue(bytes.Length == sizeof(double), "False buffer length!");
            Assert.IsTrue(i == j, "False number before and after!");
        }

        [TestMethod]
        public void TestFloatBytes()
        {
            float i = 100.123f;
            byte[] bytes = i.ToBytes();
            float j = i.FromBytes(bytes);

            Assert.IsTrue(bytes.Length == sizeof(float), "False buffer length!");
            Assert.IsTrue(i == j, "False number before and after!");
        }

        [TestMethod]
        public void TestCharBytes()
        {
            char i = 'c';
            byte[] bytes = i.ToBytes();
            char j = i.FromBytes(bytes);

            Assert.IsTrue(bytes.Length == sizeof(char), "False buffer length!");
            Assert.IsTrue(i == j, "False number before and after!");
        }

        [TestMethod]
        public void TestUIntBytes()
        {
            uint i = 100;
            byte[] bytes = i.ToBytes();
            uint j = i.FromBytes(bytes);

            Assert.IsTrue(bytes.Length == sizeof(uint), "False buffer length!");
            Assert.IsTrue(i == j, "False number before and after!");
        }

        [TestMethod]
        public void TestUShortBytes()
        {
            ushort i = 100;
            byte[] bytes = i.ToBytes();
            ushort j = i.FromBytes(bytes);

            Assert.IsTrue(bytes.Length == sizeof(ushort), "False buffer length!");
            Assert.IsTrue(i == j, "False number before and after!");
        }

        [TestMethod]
        public void TestULongBytes()
        {
            ulong i = 100;
            byte[] bytes = i.ToBytes();
            ulong j = i.FromBytes(bytes);

            Assert.IsTrue(bytes.Length == sizeof(ulong), "False buffer length!");
            Assert.IsTrue(i == j, "False number before and after!");
        }

        [TestMethod]
        public void TestCharacterArrayBytes()
        {
            String str = "abcde";
            byte[] buffer = str.ToCharArray().ToByteArray();
            String res = new String(buffer.ToCharacterArray());

            Assert.IsTrue(buffer.Length == sizeof(char) * str.Length, "Invalid buffer length!");
            Assert.IsTrue(str.Equals(res), "Different strings between before and after!");
        }

        //[TestMethod]
        //public void TestToBytes()
        //{
        //    byte[] buf = null;

        //    buf = ((long)419).ToBytes();
        //}
    }
}
