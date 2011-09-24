using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.Tools.Engines.Mathematica;

namespace NET.Tools.Test
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für MathematicaTest
    /// </summary>
    [TestClass]
    public class MathematicaTest
    {
        public MathematicaTest()
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
        public void TestMillimeter()
        {
            MillimeterUnit val1 = 100d;
            MillimeterUnit val2 = 10d;

            Assert.AreEqual(110d, (val1 + val2).Value);
            Assert.AreEqual(90d, (val1 - val2).Value);
            Assert.AreEqual(1000d, (val1 * val2).Value);
            Assert.AreEqual(10d, (val1 / val2).Value);
        }

        [TestMethod]
        public void TestMeter()
        {
            MeterUnit val1 = 100d;
            MeterUnit val2 = 10d;

            Assert.AreEqual(110d, (val1 + val2).Value);
            Assert.AreEqual(90d, (val1 - val2).Value);
            Assert.AreEqual(1000d, (val1 * val2).Value);
            Assert.AreEqual(10d, (val1 / val2).Value);
        }

        [TestMethod]
        public void TestMile()
        {
            MileUnit val1 = 100d;
            MileUnit val2 = 10d;

            Assert.AreEqual(110d, (val1 + val2).Value);
            Assert.AreEqual(90d, (val1 - val2).Value);
            Assert.AreEqual(1000d, (val1 * val2).Value);
            Assert.AreEqual(10d, (val1 / val2).Value);
        }

        [TestMethod]
        public void TestKilometer()
        {
            KilometerUnit val1 = 100d;
            KilometerUnit val2 = 10d;

            Assert.AreEqual(110d, (val1 + val2).Value);
            Assert.AreEqual(90d, (val1 - val2).Value);
            Assert.AreEqual(1000d, (val1 * val2).Value);
            Assert.AreEqual(10d, (val1 / val2).Value);
        }

        [TestMethod]
        public void TestInch()
        {
            InchUnit val1 = 100d;
            InchUnit val2 = 10d;

            Assert.AreEqual(110d, (val1 + val2).Value);
            Assert.AreEqual(90d, (val1 - val2).Value);
            Assert.AreEqual(1000d, (val1 * val2).Value);
            Assert.AreEqual(10d, (val1 / val2).Value);
        }

        [TestMethod]
        public void TestMillimeterAddOn()
        {
            MillimeterUnit mil = 100d;
            MeterUnit met = 10d;
            KilometerUnit kmet = 1d;
            MileUnit mile = 0.5d;
            InchUnit inch = 25d;

            Assert.AreEqual(100d + (10d * 1000d), (mil + met).Value);
            Assert.AreEqual(100d - (10d * 1000d), (mil - met).Value);
            Assert.AreEqual(100d * (10d * 1000d), (mil * met).Value);
            Assert.AreEqual(100d / (10d * 1000d), (mil / met).Value);

            Assert.AreEqual(100d + (1d * 1000d * 1000d), (mil + kmet).Value);
            Assert.AreEqual(100d - (1d * 1000d * 1000d), (mil - kmet).Value);
            Assert.AreEqual(100d * (1d * 1000d * 1000d), (mil * kmet).Value);
            Assert.AreEqual(100d / (1d * 1000d * 1000d), (mil / kmet).Value);

            Assert.AreEqual(100d + (0.5d * MileUnit.MileToKilometers * 1000d * 1000d), (mil + mile).Value);
            Assert.AreEqual(100d - (0.5d * MileUnit.MileToKilometers * 1000d * 1000d), (mil - mile).Value);
            Assert.AreEqual(100d * (0.5d * MileUnit.MileToKilometers * 1000d * 1000d), (mil * mile).Value);
            Assert.AreEqual(100d / (0.5d * MileUnit.MileToKilometers * 1000d * 1000d), (mil / mile).Value);

            Assert.AreEqual(100d + (25d * InchUnit.InchToMilimeters), (mil + inch).Value);
            Assert.AreEqual(100d - (25d * InchUnit.InchToMilimeters), (mil - inch).Value);
            Assert.AreEqual(100d * (25d * InchUnit.InchToMilimeters), (mil * inch).Value);
            Assert.AreEqual(100d / (25d * InchUnit.InchToMilimeters), (mil / inch).Value);
        }

        [TestMethod]
        public void TestMeterAddOn()
        {
            MillimeterUnit mil = 100d;
            MeterUnit met = 10d;
            KilometerUnit kmet = 1d;
            MileUnit mile = 0.5d;
            InchUnit inch = 25d;

            Assert.AreEqual(10d + (100d / 1000d), (met + mil).Value);
            Assert.AreEqual(10d - (100d / 1000d), (met - mil).Value);
            Assert.AreEqual(10d * (100d / 1000d), (met * mil).Value);
            Assert.AreEqual(10d / (100d / 1000d), (met / mil).Value);

            Assert.AreEqual(10d + (1d * 1000d), (met + kmet).Value);
            Assert.AreEqual(10d - (1d * 1000d), (met - kmet).Value);
            Assert.AreEqual(10d * (1d * 1000d), (met * kmet).Value);
            Assert.AreEqual(10d / (1d * 1000d), (met / kmet).Value);

            Assert.AreEqual(10d + (0.5d * MileUnit.MileToKilometers * 1000d), (met + mile).Value);
            Assert.AreEqual(10d - (0.5d * MileUnit.MileToKilometers * 1000d), (met - mile).Value);
            Assert.AreEqual(10d * (0.5d * MileUnit.MileToKilometers * 1000d), (met * mile).Value);
            Assert.AreEqual(10d / (0.5d * MileUnit.MileToKilometers * 1000d), (met / mile).Value);

            Assert.AreEqual(10d + (25d * InchUnit.InchToMilimeters / 1000), (met + inch).Value);
            Assert.AreEqual(10d - (25d * InchUnit.InchToMilimeters / 1000), (met - inch).Value);
            Assert.AreEqual(10d * (25d * InchUnit.InchToMilimeters / 1000), (met * inch).Value);
            Assert.AreEqual(10d / (25d * InchUnit.InchToMilimeters / 1000), (met / inch).Value);
        }

        [TestMethod]
        public void TestKilometerAddOn()
        {
            MillimeterUnit mil = 100d;
            MeterUnit met = 10d;
            KilometerUnit kmet = 1d;
            MileUnit mile = 0.5d;
            InchUnit inch = 25d;

            Assert.AreEqual(1d + (100d / 1000d / 1000d), (kmet + mil).Value);
            Assert.AreEqual(1d - (100d / 1000d / 1000d), (kmet - mil).Value);
            Assert.AreEqual(1d * (100d / 1000d / 1000d), (kmet * mil).Value);
            Assert.AreEqual(1d / (100d / 1000d / 1000d), (kmet / mil).Value);

            Assert.AreEqual(1d + (10d / 1000d), (kmet + met).Value);
            Assert.AreEqual(1d - (10d / 1000d), (kmet - met).Value);
            Assert.AreEqual(1d * (10d / 1000d), (kmet * met).Value);
            Assert.AreEqual(1d / (10d / 1000d), (kmet / met).Value);

            Assert.AreEqual(1d + (0.5d * MileUnit.MileToKilometers), (kmet + mile).Value);
            Assert.AreEqual(1d - (0.5d * MileUnit.MileToKilometers), (kmet - mile).Value);
            Assert.AreEqual(1d * (0.5d * MileUnit.MileToKilometers), (kmet * mile).Value);
            Assert.AreEqual(1d / (0.5d * MileUnit.MileToKilometers), (kmet / mile).Value);

            Assert.AreEqual(1d + (25d * InchUnit.InchToMilimeters / 1000 / 1000), (kmet + inch).Value);
            Assert.AreEqual(1d - (25d * InchUnit.InchToMilimeters / 1000 / 1000), (kmet - inch).Value);
            Assert.AreEqual(1d * (25d * InchUnit.InchToMilimeters / 1000 / 1000), (kmet * inch).Value);
            Assert.AreEqual(1d / (25d * InchUnit.InchToMilimeters / 1000 / 1000), (kmet / inch).Value);
        }

        [TestMethod]
        public void TestMileAddOn()
        {
            MillimeterUnit mil = 100d;
            MeterUnit met = 10d;
            KilometerUnit kmet = 1d;
            MileUnit mile = 0.5d;
            InchUnit inch = 25d;

            Assert.AreEqual(0.5d + (100d / 1000d / 1000d / MileUnit.MileToKilometers), (mile + mil).Value);
            Assert.AreEqual(0.5d - (100d / 1000d / 1000d / MileUnit.MileToKilometers), (mile - mil).Value);
            Assert.AreEqual(0.5d * (100d / 1000d / 1000d / MileUnit.MileToKilometers), (mile * mil).Value);
            Assert.AreEqual(0.5d / (100d / 1000d / 1000d / MileUnit.MileToKilometers), (mile / mil).Value);

            Assert.AreEqual(0.5d + (10d / 1000d / MileUnit.MileToKilometers), (mile + met).Value);
            Assert.AreEqual(0.5d - (10d / 1000d / MileUnit.MileToKilometers), (mile - met).Value);
            Assert.AreEqual(0.5d * (10d / 1000d / MileUnit.MileToKilometers), (mile * met).Value);
            Assert.AreEqual(0.5d / (10d / 1000d / MileUnit.MileToKilometers), (mile / met).Value);

            Assert.AreEqual(0.5d + (1d / MileUnit.MileToKilometers), (mile + kmet).Value);
            Assert.AreEqual(0.5d - (1d / MileUnit.MileToKilometers), (mile - kmet).Value);
            Assert.AreEqual(0.5d * (1d / MileUnit.MileToKilometers), (mile * kmet).Value);
            Assert.AreEqual(0.5d / (1d / MileUnit.MileToKilometers), (mile / kmet).Value);

            Assert.AreEqual(0.5d + (25d * InchUnit.InchToMilimeters / 1000 / 1000 / MileUnit.MileToKilometers), (mile + inch).Value);
            Assert.AreEqual(0.5d - (25d * InchUnit.InchToMilimeters / 1000 / 1000 / MileUnit.MileToKilometers), (mile - inch).Value);
            Assert.AreEqual(0.5d * (25d * InchUnit.InchToMilimeters / 1000 / 1000 / MileUnit.MileToKilometers), (mile * inch).Value);
            Assert.AreEqual(0.5d / (25d * InchUnit.InchToMilimeters / 1000 / 1000 / MileUnit.MileToKilometers), (mile / inch).Value);
        }

        [TestMethod]
        public void TestInchAddOn()
        {
            MillimeterUnit mil = 100d;
            MeterUnit met = 10d;
            KilometerUnit kmet = 1d;
            MileUnit mile = 0.5d;
            InchUnit inch = 25d;

            Assert.AreEqual(25d + (100d / InchUnit.InchToMilimeters), (inch + mil).Value);
            Assert.AreEqual(25d - (100d / InchUnit.InchToMilimeters), (inch - mil).Value);
            Assert.AreEqual(25d * (100d / InchUnit.InchToMilimeters), (inch * mil).Value);
            Assert.AreEqual(25d / (100d / InchUnit.InchToMilimeters), (inch / mil).Value);

            Assert.AreEqual(25d + (10d * 1000d / InchUnit.InchToMilimeters), (inch + met).Value);
            Assert.AreEqual(25d - (10d * 1000d / InchUnit.InchToMilimeters), (inch - met).Value);
            Assert.AreEqual(25d * (10d * 1000d / InchUnit.InchToMilimeters), (inch * met).Value);
            Assert.AreEqual(25d / (10d * 1000d / InchUnit.InchToMilimeters), (inch / met).Value);

            Assert.AreEqual(25d + (1d * 1000 * 1000 / InchUnit.InchToMilimeters), (inch + kmet).Value);
            Assert.AreEqual(25d - (1d * 1000 * 1000 / InchUnit.InchToMilimeters), (inch - kmet).Value);
            Assert.AreEqual(25d * (1d * 1000 * 1000 / InchUnit.InchToMilimeters), (inch * kmet).Value);
            Assert.AreEqual(25d / (1d * 1000 * 1000 / InchUnit.InchToMilimeters), (inch / kmet).Value);

            Assert.AreEqual(25d + (0.5d * MileUnit.MileToKilometers * 1000 * 1000 / InchUnit.InchToMilimeters), (inch + mile).Value);
            Assert.AreEqual(25d - (0.5d * MileUnit.MileToKilometers * 1000 * 1000 / InchUnit.InchToMilimeters), (inch - mile).Value);
            Assert.AreEqual(25d * (0.5d * MileUnit.MileToKilometers * 1000 * 1000 / InchUnit.InchToMilimeters), (inch * mile).Value);
            Assert.AreEqual(25d / (0.5d * MileUnit.MileToKilometers * 1000 * 1000 / InchUnit.InchToMilimeters), (inch / mile).Value);
        }

        [TestMethod]
        public void TestLengthUnitConditions()
        {
            MillimeterUnit mil = 100d;
            MeterUnit met = 10d;
            KilometerUnit kmet = 1d;
            MileUnit mile = 0.5d;
            InchUnit inch = 25d;

            //**********************

            Assert.IsTrue(mil < met);
            Assert.IsTrue(met > mil);
            Assert.IsFalse(mil > met);
            Assert.IsFalse(met < mil);

            Assert.IsTrue(mil < kmet);
            Assert.IsTrue(kmet > mil);
            Assert.IsFalse(mil > kmet);
            Assert.IsFalse(kmet < mil);

            Assert.IsTrue(mil < mile);
            Assert.IsTrue(mile > mil);
            Assert.IsFalse(mil > mile);
            Assert.IsFalse(mile < mil);

            Assert.IsTrue(mil < inch);
            Assert.IsTrue(inch > mil);
            Assert.IsFalse(mil > inch);
            Assert.IsFalse(inch < mil);

            //************************

            Assert.IsTrue(met < kmet);
            Assert.IsTrue(kmet > met);
            Assert.IsFalse(met > kmet);
            Assert.IsFalse(kmet < met);

            Assert.IsTrue(met < mile);
            Assert.IsTrue(mile > met);
            Assert.IsFalse(met > mile);
            Assert.IsFalse(mile < met);

            Assert.IsTrue(met > inch);
            Assert.IsTrue(inch < met);
            Assert.IsFalse(met < inch);
            Assert.IsFalse(inch > met);

            //************************

            Assert.IsTrue(kmet > mile);
            Assert.IsTrue(mile < kmet);
            Assert.IsFalse(kmet < mile);
            Assert.IsFalse(mile > kmet);

            Assert.IsTrue(kmet > inch);
            Assert.IsTrue(inch < kmet);
            Assert.IsFalse(kmet < inch);
            Assert.IsFalse(inch > kmet);

            //************************

            Assert.IsTrue(mile > inch);
            Assert.IsTrue(inch < mile);
            Assert.IsFalse(mile < inch);
            Assert.IsFalse(inch > mile);
        }

        //***********************************************************************

        [TestMethod]
        public void TestRadian()
        {
            RadianUnit val1 = 100d;
            RadianUnit val2 = 10d;

            Assert.AreEqual(110d, (val1 + val2).Value);
            Assert.AreEqual(90d, (val1 - val2).Value);
            Assert.AreEqual(1000d, (val1 * val2).Value);
            Assert.AreEqual(10d, (val1 / val2).Value);
        }

        [TestMethod]
        public void TestDegree()
        {
            DegreeUnit val1 = 100d;
            DegreeUnit val2 = 10d;

            Assert.AreEqual(110d, (val1 + val2).Value);
            Assert.AreEqual(90d, (val1 - val2).Value);
            Assert.AreEqual(1000d, (val1 * val2).Value);
            Assert.AreEqual(10d, (val1 / val2).Value);
        }

        [TestMethod]
        public void TestRadianDegree()
        {
            DegreeUnit degree = 45d;
            RadianUnit radian = 0.3d;

            Assert.AreEqual(45d + (180 * 0.3d / Math.PI), (degree + radian).Value);
            Assert.AreEqual(45d - (180 * 0.3d / Math.PI), (degree - radian).Value);
            Assert.AreEqual(45d * (180 * 0.3d / Math.PI), (degree * radian).Value);
            Assert.AreEqual(45d / (180 * 0.3d / Math.PI), (degree / radian).Value);

            Assert.AreEqual(0.3d + (Math.PI * 45d / 180), (radian + degree).Value);
            Assert.AreEqual(0.3d - (Math.PI * 45d / 180), (radian - degree).Value);
            Assert.AreEqual(0.3d * (Math.PI * 45d / 180), (radian * degree).Value);
            Assert.AreEqual(0.3d / (Math.PI * 45d / 180), (radian / degree).Value);

            Assert.IsTrue(degree > radian);
            Assert.IsTrue(radian < degree);
            Assert.IsFalse(degree < radian);
            Assert.IsFalse(radian > degree);
        }

        //**************************************************************

        [TestMethod]
        public void TestDPI()
        {
            DPIUnit val1 = 100d;
            DPIUnit val2 = 10d;

            Assert.AreEqual(110d, (val1 + val2).Value);
            Assert.AreEqual(90d, (val1 - val2).Value);
            Assert.AreEqual(1000d, (val1 * val2).Value);
            Assert.AreEqual(10d, (val1 / val2).Value);
        }

        [TestMethod]
        public void TestPixel()
        {
            PixelUnit val1 = 100d;
            PixelUnit val2 = 10d;

            Assert.AreEqual(110d, (val1 + val2).Value);
            Assert.AreEqual(90d, (val1 - val2).Value);
            Assert.AreEqual(1000d, (val1 * val2).Value);
            Assert.AreEqual(10d, (val1 / val2).Value);
        }

        [TestMethod]
        public void TestPixelDPI()
        {
            PixelUnit pixel = 1000d;
            DPIUnit dpi = 600d;
            InchUnit inch = 25d;

            Assert.AreEqual(1000d / 600d, pixel.ToInchLength(dpi).Value);
            Assert.AreEqual(25d / (1d / 600d), inch.ToPixelCount(dpi).Value);
        }
    }
}
