using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.Tools.Test
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für PointTest
    /// </summary>
    [TestClass]
    public class PointTest
    {
        private static System.Drawing.Point dp1, dp2;
        private static System.Windows.Point wp1, wp2;
        private static System.Drawing.PointF fp1, fp2;
        private static System.Drawing.Rectangle drect;
        private static System.Windows.Rect wrect;
        private static System.Drawing.RectangleF frect;

        public PointTest()
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
            dp1 = new System.Drawing.Point(10, 10);
            dp2 = new System.Drawing.Point(100, 100);
            drect = new System.Drawing.Rectangle(5, 5, 15, 15);

            wp1 = new System.Windows.Point(10, 10);
            wp2 = new System.Windows.Point(100, 100);
            wrect = new System.Windows.Rect(5, 5, 15, 15);

            fp1 = new System.Drawing.PointF(10, 10);
            fp2 = new System.Drawing.PointF(100, 100);
            frect = new System.Drawing.RectangleF(5, 5, 15, 15);
        }

        [TestMethod]
        public void TestDrawingPointInRect()
        {
            Assert.IsTrue(drect.IsPointInRect(dp1), "Point not in rect!");
            Assert.IsFalse(drect.IsPointInRect(dp2), "Point in rect!");
            Assert.IsFalse(drect.IsPointInRect(dp1, dp2), "Point in rect!");
            Assert.IsFalse(drect.IsPointInRect(dp2, dp1), "Point in rect!");

            Assert.IsTrue(dp1.IsPointInRect(drect), "Point not in rect!");
            Assert.IsFalse(dp2.IsPointInRect(drect), "Point in rect!");
        }

        [TestMethod]
        public void TestWPFPointInRect()
        {
            Assert.IsTrue(wrect.IsPointInRect(wp1), "Point not in rect!");
            Assert.IsFalse(wrect.IsPointInRect(wp2), "Point in rect!");
            Assert.IsFalse(wrect.IsPointInRect(wp1, wp2), "Point in rect!");
            Assert.IsFalse(wrect.IsPointInRect(wp2, wp1), "Point in rect!");

            Assert.IsTrue(wp1.IsPointInRect(wrect), "Point not in rect!");
            Assert.IsFalse(wp2.IsPointInRect(wrect), "Point in rect!");
        }

        [TestMethod]
        public void TestDrawingPointFInRect()
        {
            Assert.IsTrue(frect.IsPointInRect(fp1), "Point not in rect!");
            Assert.IsFalse(frect.IsPointInRect(fp2), "Point in rect!");
            Assert.IsFalse(frect.IsPointInRect(fp1, fp2), "Point in rect!");
            Assert.IsFalse(frect.IsPointInRect(fp2, fp1), "Point in rect!");

            Assert.IsTrue(fp1.IsPointInRect(frect), "Point not in rect!");
            Assert.IsFalse(fp2.IsPointInRect(frect), "Point in rect!");
        }

        [TestMethod]
        public void TestSpecialInRect()
        {
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(14, 5, 50, 10);
            System.Drawing.Point point = new System.Drawing.Point(30, 17);

            Assert.IsFalse(rect.IsPointInRect(point));
        }
    }
}
