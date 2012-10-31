using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.Tools.Test
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für RectTest
    /// </summary>
    [TestClass]
    public class RectTest
    {
        private static System.Drawing.Rectangle dr1, dr2, dr3, dr4, dr5, drect;
        private static System.Drawing.RectangleF fr1, fr2, fr3, fr4, fr5, frect;
        private static System.Windows.Rect wr1, wr2, wr3, wr4, wr5, wrect;

        public RectTest()
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

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            drect = new System.Drawing.Rectangle(5, 5, 5, 5);
            dr1 = new System.Drawing.Rectangle(6, 6, 1, 1); //In
            dr2 = new System.Drawing.Rectangle(3, 3, 5, 5); //Overlap TopLeft
            dr3 = new System.Drawing.Rectangle(0, 0, 15, 15); //Over
            dr4 = new System.Drawing.Rectangle(0, 0, 1, 1); //Out
            dr5 = new System.Drawing.Rectangle(8, 8, 5, 5); //Overlap RightBottom

            frect = new System.Drawing.RectangleF(5, 5, 5, 5);
            fr1 = new System.Drawing.RectangleF(6, 6, 1, 1); //In
            fr2 = new System.Drawing.RectangleF(3, 3, 5, 5); //Overlap TopLeft
            fr3 = new System.Drawing.RectangleF(0, 0, 15, 15); //Over
            fr4 = new System.Drawing.RectangleF(0, 0, 1, 1); //Out
            fr5 = new System.Drawing.RectangleF(8, 8, 5, 5); //Overlap RightBottom

            wrect = new System.Windows.Rect(5, 5, 5, 5);
            wr1 = new System.Windows.Rect(6, 6, 1, 1); //In
            wr2 = new System.Windows.Rect(3, 3, 5, 5); //Overlap TopLeft
            wr3 = new System.Windows.Rect(0, 0, 15, 15); //Over
            wr4 = new System.Windows.Rect(0, 0, 1, 1); //Out
            wr5 = new System.Windows.Rect(8, 8, 5, 5); //Overlap RightBottom
        }

        [TestMethod]
        public void TestDrawingRectangleInRectangle()
        {
            Assert.IsTrue(drect.IsRectInRect(dr1), "Rect not in rect");
            Assert.IsTrue(drect.IsRectInRect(dr2), "Rect not in rect");
            Assert.IsTrue(drect.IsRectInRect(dr3), "Rect not in rect");
            Assert.IsFalse(drect.IsRectInRect(dr4), "Rect in rect");
            Assert.IsTrue(drect.IsRectInRect(dr5), "Rect not in rect");

            Assert.IsTrue(drect.IsRectInRect(dr1, dr2, dr3, dr5), "Rect not in rect");
            Assert.IsFalse(drect.IsRectInRect(dr1, dr2, dr3, dr4, dr5), "Rect in rect");
        }

        [TestMethod]
        public void TestDrawingRectangleFInRectangle()
        {
            Assert.IsTrue(frect.IsRectInRect(fr1), "Rect not in rect");
            Assert.IsTrue(frect.IsRectInRect(fr2), "Rect not in rect");
            Assert.IsTrue(frect.IsRectInRect(fr3), "Rect not in rect");
            Assert.IsFalse(frect.IsRectInRect(fr4), "Rect in rect");
            Assert.IsTrue(frect.IsRectInRect(fr5), "Rect not in rect");

            Assert.IsTrue(frect.IsRectInRect(fr1, fr2, fr3, fr5), "Rect not in rect");
            Assert.IsFalse(frect.IsRectInRect(fr1, fr2, fr3, fr4, fr5), "Rect in rect");
        }

        [TestMethod]
        public void TestWPFRectangleInRectangle()
        {
            Assert.IsTrue(wrect.IsRectInRect(wr1), "Rect not in rect");
            Assert.IsTrue(wrect.IsRectInRect(wr2), "Rect not in rect");
            Assert.IsTrue(wrect.IsRectInRect(wr3), "Rect not in rect");
            Assert.IsFalse(wrect.IsRectInRect(wr4), "Rect in rect");
            Assert.IsTrue(wrect.IsRectInRect(wr5), "Rect not in rect");

            Assert.IsTrue(wrect.IsRectInRect(wr1, wr2, wr3, wr5), "Rect not in rect");
            Assert.IsFalse(wrect.IsRectInRect(wr1, wr2, wr3, wr4, wr5), "Rect in rect");
        }
    }
}
