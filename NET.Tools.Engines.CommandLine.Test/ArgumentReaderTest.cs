using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.Tools;
using NET.Tools.Engines.CommandLine;

namespace NET.Tools.Engines.CommandLine.Test
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für ArgumentReaderTest
    /// </summary>
    [TestClass]
    public class ArgumentReaderTest
    {
        private static ArgumentReader argReader = null;

        public ArgumentReaderTest()
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
            argReader = new ArgumentReader(false, SwitchArgument.CreateHelpArgument(SwitchCharacter.Slash), "My Error Text", 
                "Using: program.exe <filename> [/D] [/F=3]", "Example", "BlaBla", 
                new PureArgument<String>("MyPureArgument", false, false, "Filename", "Pure Argument: %message%"), 
                new SwitchArgument(SwitchCharacter.Slash, "D", "Switch D", "Switch D: %message%"),
                new SwitchedContentArgument<Int32>("SwitchedArgument", SwitchCharacter.Slash, "F", SeparatorCharacter.Equal, true, true, "Switched Content F", "Switched Content F: %message%"));
        }

        [TestMethod]
        public void ArgumentTestAllContent()
        {
            bool result = argReader.EvaluateArguments("C:\test.txt", "/D", "/F=3");
            Assert.IsTrue(result, "Error: " + argReader.GetLastError());

            Assert.IsTrue(argReader.ArgumentList[0].IsSet, "Pure argument not set!");
            Assert.AreEqual<String>(
                "C:\test.txt",
                (argReader.ArgumentList[0] as PureArgument<String>).ValueList[0].ToString(),
                "Content of pure argument wrong!");

            Assert.IsTrue(argReader.ArgumentList[1].IsSet, "Switch D not set!");

            Assert.IsTrue(argReader.ArgumentList[2].IsSet, "Switched Content F not set!");
            Assert.AreEqual<Int32>(
                3,
                (argReader.ArgumentList[2] as SwitchedContentArgument<Int32>).ValueList[0],
                "Content of switched content argument wrong!");
        }

        [TestMethod]
        public void ArgumentTestAll()
        {
            bool result = argReader.EvaluateArguments("C:\test.txt", "/D", "/F=3");
            Assert.IsTrue(result, "Error: " + argReader.GetLastError());
        }

        [TestMethod]
        public void ArgumentTestOneContent()
        {
            bool result = argReader.EvaluateArguments("C:\test.txt");
            Assert.IsTrue(result, "Error: " + argReader.GetLastError());

            Assert.IsTrue(argReader.ArgumentList[0].IsSet, "Pure argument not set!");
            Assert.AreEqual<String>(
                "C:\test.txt",
                (argReader.ArgumentList[0] as PureArgument<String>).ValueList[0].ToString(),
                "Content of pure argument wrong!");

            Assert.IsFalse(argReader.ArgumentList[1].IsSet, "Switch D is set?!");

            Assert.IsFalse(argReader.ArgumentList[2].IsSet, "Switched Content F is set?!");
        }

        [TestMethod]
        public void ArgumentTestOne()
        {
            bool result = argReader.EvaluateArguments("C:\test.txt");
            Assert.IsTrue(result, "Error: " + argReader.GetLastError()); 
        }

        [TestMethod]
        public void ArgumentTestMoreContent()
        {
            bool result = argReader.EvaluateArguments("C:\test.txt", "/D", "/F=3", "/F=5");
            Assert.IsTrue(result, "Error: " + argReader.GetLastError());

            Assert.IsTrue(argReader.ArgumentList[0].IsSet, "Pure argument not set!");
            Assert.AreEqual<String>(
                "C:\test.txt",
                (argReader.ArgumentList[0] as PureArgument<String>).ValueList[0].ToString(),
                "Content of pure argument wrong!");

            Assert.IsTrue(argReader.ArgumentList[1].IsSet, "Switch D not set!");

            Assert.IsTrue(argReader.ArgumentList[2].IsSet, "Switched Content F not set!");
            Assert.AreEqual<Int32>(
                3,
                (argReader.ArgumentList[2] as SwitchedContentArgument<Int32>).ValueList[0],
                "Content of switched content argument (0) wrong!");
            Assert.AreEqual<Int32>(
                5,
                (argReader.ArgumentList[2] as SwitchedContentArgument<Int32>).ValueList[1],
                "Content of switched content argument (1) wrong!");
        }

        [TestMethod]
        public void ArgumentTestMore()
        {
            bool result = argReader.EvaluateArguments("C:\test.txt", "/D", "/F=3", "/F=5");
            Assert.IsTrue(result, "Error: " + argReader.GetLastError());
        }

        [TestMethod]
        public void ArgumentTestUnknownArgumentNotAllowed()
        {
            bool result = argReader.EvaluateArguments("C:\test.txt", "-G", "/D", "/F=5");
            Assert.IsFalse(result, "No error!");
        }

        [TestMethod]
        public void ArgumentTestUnknownArgumentAllowed()
        {
            argReader.AllowUnknownArgs = true;
            bool result = argReader.EvaluateArguments("C:\test.txt", "-G", "/D", "/F=5");
            argReader.AllowUnknownArgs = false;
            Assert.IsTrue(result, "There is an error!");
        }

        [TestMethod]
        public void ArgumentTestNoRequiedArgument()
        {
            bool result = argReader.EvaluateArguments("/D", "/F=3");
            Assert.IsFalse(result, "No error!");
        }

        [TestMethod]
        public void ArgumentTestNoMultiArgument()
        {
            bool result = argReader.EvaluateArguments("C:\test.txt", "/D", "/D", "/F=5");
            Assert.IsFalse(result, "No error!");
        }
    }
}
