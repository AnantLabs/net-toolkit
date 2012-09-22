using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.Tools.Test
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für ArrayExtensionsTest
    /// </summary>
    [TestClass]
    public class ArrayExtensionsTest
    {
        public ArrayExtensionsTest()
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
        public void TestSubArray()
        {
            byte[] array = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            byte[] sub1 = array.SubArray(2, 5);
            byte[] sub2 = array.SubArray(5);

            Assert.AreEqual(5, sub1.Length);
            Assert.IsTrue(new byte[] { 2, 3, 4, 5, 6 }.EqualsTo(sub1));

            Assert.AreEqual(5, sub2.Length);
            Assert.IsTrue(new byte[] { 5, 6, 7, 8, 9 }.EqualsTo(sub2));
        }

        [TestMethod]
        public void TestPadding1()
        {
            byte[] array = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            byte[] result = array.PadLeft<byte>(10, 11);

            Console.WriteLine(result.ToString());

            Assert.AreEqual(20, result.Length);
            Assert.IsTrue(new byte[] { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }.EqualsTo(result));
        }

        [TestMethod]
        public void TestPadding2()
        {
            byte[] array = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            byte[] result = array.PadRight<byte>(10, 11);

            Console.WriteLine(result.ToString());

            Assert.AreEqual(20, result.Length);
            Assert.IsTrue(new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 }.EqualsTo(result));
        }

        [TestMethod]
        public void TestPadding3()
        {
            byte[] array = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            byte[] result = array.Pad<byte>(5, 10, 11);

            Console.WriteLine(result.ToString());

            Assert.AreEqual(20, result.Length);
            Assert.IsTrue(new byte[] { 0, 1, 2, 3, 4, 5, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 6, 7, 8, 9 }.EqualsTo(result));
        }
    }
}
