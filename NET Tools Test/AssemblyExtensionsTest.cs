using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.Tools;

namespace NET.Tools.Test
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für AssemblyExtension
    /// </summary>
    [TestClass]
    public class AssemblyExtensionsTest
    {
        public AssemblyExtensionsTest()
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
        public void TestAssemblyNameDLL()
        {
            Assert.AreEqual<String>(
                "NET.Tools.dll",
                typeof(AssemblyExtensions).Assembly.GetFileName().Name,
                "The assembly names are different!");
        }

        [TestMethod]
        public void TestAssemblyNameEXE()
        {
            Assert.AreEqual<String>(
                "NET.Tools.Demo.exe",
                typeof(NET.Tools.Demo.App).Assembly.GetFileName().Name,
                "The assembly names are different!");
        }
    }
}
