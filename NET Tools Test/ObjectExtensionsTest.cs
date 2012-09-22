using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.Tools;

namespace NET.Tools.Test
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für ObjectExtensionsTest
    /// </summary>
    [TestClass]
    public class ObjectExtensionsTest
    {
        public ObjectExtensionsTest()
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
        public void TestPutIntoInBounds()
        {
            int i = 100;
            i = i.PutInto(50, 150);

            Assert.AreEqual<int>(100, i, "The values are not eqauls!");
        }

        [TestMethod]
        public void TestPutIntoOutBoundsMin()
        {
            int i = 15;
            i = i.PutInto(50, 150);

            Assert.AreNotEqual<int>(15, i, "The values are eqauls!");
            Assert.AreEqual<int>(50, i, "The values are not equals!");
        }

        [TestMethod]
        public void TestPutIntoOutBoundsMax()
        {
            int i = 233;
            i = i.PutInto(50, 150);

            Assert.AreNotEqual<int>(233, i, "The values are eqauls!");
            Assert.AreEqual<int>(150, i, "The values are not equals!");
        }

        [TestMethod]
        public void TestIsBetweenInBounds()
        {
            int i = 50;
            Assert.IsTrue(i.IsBetween(25, 75), "Not true!");
        }

        [TestMethod]
        public void TestIsBetweenNotInBoundsMin()
        {
            int i = 50;
            Assert.IsFalse(i.IsBetween(75, 100), "Not false!");
        }

        [TestMethod]
        public void TestIsBetweenNotInBoundsMax()
        {
            int i = 50;
            Assert.IsFalse(i.IsBetween(10, 25), "Not false!");
        }

        [TestMethod]
        public void TestIsIn()
        {
            int i = 25;

            Assert.IsTrue(i.IsIn(10, 20, 25, 5, 7));
            Assert.IsFalse(i.IsIn(20, 5, 2, 3, 10));
        }

        [TestMethod]
        public void TestIsNotIn()
        {
            int i = 25;

            Assert.IsFalse(i.IsNotIn(10, 20, 25, 5, 7));
            Assert.IsTrue(i.IsNotIn(20, 5, 2, 3, 10));
        }
    }
}
