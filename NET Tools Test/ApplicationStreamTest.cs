using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Reflection;

namespace NET.Tools.Test
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für ApplicationStreamTest
    /// </summary>
    [TestClass]
    public class ApplicationStreamTest
    {
        public static String TestString {get{ return "Hello World!"; } }
        public static int TestInt { get { return 12; } }
        public static double TestDouble { get { return 1.234; } }

        public ApplicationStreamTest()
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

        // Cannot run while assembly is opened
        //[TestMethod]
        //public void TestAppStream()
        //{
        //    using (ApplicationStream stream = new ApplicationStream(Assembly.GetExecutingAssembly()))
        //    {
        //        Assert.IsTrue(stream.Length == 0L, "Stream is too long! (" + stream.Length + ")");
        //        stream.WriteString(TestString);
        //        stream.WriteInteger(TestInt);
        //        stream.WriteDouble(TestDouble);
        //    }

        //    using (ApplicationStream stream = new ApplicationStream(Assembly.GetExecutingAssembly()))
        //    {
        //        Assert.IsTrue(stream.Length != 0L, "Stream is 0!");
        //        String str = stream.ReadString();
        //        int i = stream.ReadInteger();
        //        double d = stream.ReadDouble();
        //        Assert.IsTrue(str.Equals(TestString), "False String!");
        //        Assert.IsTrue(i == TestInt, "False Integer!");
        //        Assert.IsTrue(d == TestDouble, "False Double!");
        //    }
        //}
    }
}
