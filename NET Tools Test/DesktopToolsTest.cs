using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.Tools;
using NET.Tools.OS;

namespace NET.Tools.Test
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für DesktopToolsTest
    /// </summary>
    [TestClass]
    public class DesktopToolsTest
    {
        public DesktopToolsTest()
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
        public void TestResolutionChange()
        {
            DisplayScreen screen = new DisplayScreen();
            if (screen.ScreenWidth == 800)
            {
                screen.ScreenWidth = 1024;
                screen.ScreenHeight = 768;
                screen.UpdateSettingsToFullscreen();

                DisplayScreen tmp = new DisplayScreen();
                Assert.IsTrue((tmp.ScreenWidth == screen.ScreenWidth) &&
                              (tmp.ScreenHeight == screen.ScreenHeight));

                DisplayScreen.ResetSettings();
            }
            else
            {
                screen.ScreenWidth = 800;
                screen.ScreenHeight = 600;
                screen.UpdateSettingsToFullscreen();

                DisplayScreen tmp = new DisplayScreen();
                Assert.IsTrue((tmp.ScreenWidth == screen.ScreenWidth) &&
                              (tmp.ScreenHeight == screen.ScreenHeight));

                DisplayScreen.ResetSettings();
            }
        }
    }
}
