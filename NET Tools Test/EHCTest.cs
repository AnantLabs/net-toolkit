using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.Tools;

namespace NET.Tools.Test
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für EHCTest
    /// </summary>
    [TestClass]
    public class EHCTest
    {
        #region Inner Classes

        private class TestClass
        {
            public int Number { get; private set; }
            public String String { get; private set; }

            public TestClass(int num, String str)
            {
                Number = num;
                String = str;
            }

            public override bool Equals(object obj)
            {
                return EHCBuilder.Equals(this, obj);
            }

            public override int GetHashCode()
            {
                return EHCBuilder.GetHashCode(this);
            }
        }

        #endregion

        private static TestClass c1, c2, c3, c4, c5;

        public EHCTest()
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

        [ClassInitialize()]
        public static void Init(TestContext testContext)
        {
            c1 = new TestClass(10, "Hello");
            c2 = new TestClass(12, "World");
            c3 = c1;
            c4 = new TestClass(10, "Hello");
            c5 = new TestClass(0, null);
        }

        [TestMethod]
        public void EHCTestReferenceEquals()
        {
            Assert.IsTrue(c1.Equals(c3), "Is not equal!");
            Assert.IsTrue(c3.Equals(c1), "Is not equal!");
            Assert.IsTrue(c1.GetHashCode() == c3.GetHashCode(), "Is not the same hashcode!");
        }

        [TestMethod]
        public void EHCTestNullReference()
        {
            Assert.IsFalse(c1.Equals(null), "Is not false!");
            Assert.IsFalse(c2.Equals(null), "Is not false!");
            Assert.IsFalse(c3.Equals(null), "Is not false!");
            Assert.IsFalse(c4.Equals(null), "Is not false!");
            Assert.IsFalse(c5.Equals(null), "Is not false!");
        }

        [TestMethod]
        public void EHCTestFalseType()
        {
            Assert.IsFalse(c1.Equals("String"), "Is not false!");
            Assert.IsFalse(c2.Equals("String"), "Is not false!");
            Assert.IsFalse(c3.Equals("String"), "Is not false!");
            Assert.IsFalse(c4.Equals("String"), "Is not false!");
            Assert.IsFalse(c5.Equals("String"), "Is not false!");
        }

        [TestMethod]
        public void EHCTestNotEquals()
        {
            Assert.IsFalse(c1.Equals(c2), "Is not false!");
            Assert.IsFalse(c2.Equals(c1), "Is not false!");

            Assert.IsFalse(c1.GetHashCode() == c2.GetHashCode(), "Hashcodes are equals!");
        }

        [TestMethod]
        public void EHCTestIsEquals()
        {
            Assert.IsTrue(c1.Equals(c4), "Is not equals!");
            Assert.IsTrue(c4.Equals(c1), "Is not equals!");

            Assert.IsTrue(c1.GetHashCode() == c4.GetHashCode(), "HashCode not equals!");
        }

        [TestMethod]
        public void EHCNullContent()
        {
            Assert.IsFalse(c1.Equals(c5), "Is equals!");
            Assert.IsFalse(c5.Equals(c1), "Is equals!");

            Assert.IsTrue(c5.Equals(new TestClass(0, null)), "Is not equals!");

            Assert.IsTrue(c5.GetHashCode() == c5.GetHashCode(), "Is not equals!");
            Assert.IsTrue(c5.GetHashCode() == new TestClass(0, null).GetHashCode(), 
                "Is not equals!");
        }
    }
}
