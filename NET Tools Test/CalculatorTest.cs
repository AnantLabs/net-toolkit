using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.Tools;
using System.Text.RegularExpressions;

namespace NET.Tools.Test
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für CalculatorTest
    /// </summary>
    [TestClass]
    public class CalculatorTest
    {
        public CalculatorTest()
        {
            //
            // TODO: Konstruktorlogik hier hinzufügen
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        /// Ruft den Textkontext mit Informationen über
        /// den aktuellen Testlauf sowie Funktionalität für diesen auf oder legt diese fest.
        /// </summary>
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
        public void TestCalcAdd()
        {
            double value = "3+5".ParseCalculationString();
            Assert.AreEqual<double>(3d + 5d, value);
        }

        [TestMethod]
        public void TestCalcSub()
        {
            double value = "3-5".ParseCalculationString();
            Assert.AreEqual<double>(3d - 5d, value);
        }

        [TestMethod]
        public void TestCalcMul()
        {
            double value = "3*5".ParseCalculationString();
            Assert.AreEqual<double>(3d * 5d, value);
        }

        [TestMethod]
        public void TestCalcDiv()
        {
            double value = "3/5".ParseCalculationString();
            Assert.AreEqual<double>(3d / 5d, value);
        }

        [TestMethod]
        public void TestCalcPow()
        {
            double value = "3^5".ParseCalculationString();
            Assert.AreEqual<double>(Math.Pow(3, 5), value);
        }

        [TestMethod]
        public void TestCalcMod()
        {
            double value = "3%5".ParseCalculationString();
            Assert.AreEqual<double>(3 % 5, value);
        }

        [TestMethod]
        public void TestCalcAddDecimal()
        {
            double value = "3,0+5,0".ParseCalculationString();
            Assert.AreEqual<double>(3d + 5d, value);
        }

        [TestMethod]
        public void TestCalcSubDecimal()
        {
            double value = "3,0-5,0".ParseCalculationString();
            Assert.AreEqual<double>(3d - 5d, value);
        }

        [TestMethod]
        public void TestCalcMulDecimal()
        {
            double value = "3,0*5,0".ParseCalculationString();
            Assert.AreEqual<double>(3d * 5d, value);
        }

        [TestMethod]
        public void TestCalcDivDecimal()
        {
            double value = "3,0/5,0".ParseCalculationString();
            Assert.AreEqual<double>(3d / 5d, value);
        }

        [TestMethod]
        public void TestCalcPowDecimal()
        {
            double value = "3,0^5,0".ParseCalculationString();
            Assert.AreEqual<double>(Math.Pow(3, 5), value);
        }

        [TestMethod]
        public void TestCalcModDecimal()
        {
            double value = "3,0%5,0".ParseCalculationString();
            Assert.AreEqual<double>(3 % 5, value);
        }

        [TestMethod]
        public void TestCalcFirstDot()
        {
            double value = "3+5*10".ParseCalculationString();
            Assert.AreEqual<double>(3d + 5d * 10d, value);

            value = "3-5/10".ParseCalculationString();
            Assert.AreEqual<double>(3d - 5d / 10d, value);
        }

        [TestMethod]
        public void TestCalcFirstPow()
        {
            double value = "3+5^10".ParseCalculationString();
            Assert.AreEqual<double>(3d + Math.Pow(5d, 10d), value);

            value = "3*5^10".ParseCalculationString();
            Assert.AreEqual<double>(3d * Math.Pow(5d, 10d), value);
        }

        [TestMethod]
        public void TestClacBreaks()
        {
            double value = "(3-(4*(6-5))*7)*2".ParseCalculationString();
            Assert.AreEqual<double>((3 - (4 * (6 - 5)) * 7) * 2, value);
        }

        [TestMethod]
        public void TestCalcNegative()
        {
            double value = "-4*5".ParseCalculationString();
            Assert.AreEqual<double>(-4 * 5, value);
        }

        [TestMethod]
        public void TestCalcNegativeBreaks()
        {
            double value = "4*(-5)".ParseCalculationString();
            Assert.AreEqual<double>(4 * (-5), value);
        }

        [TestMethod]
        public void TestClacBreaksNegative()
        {
            double value = "-(3-(-4*(6-5))*7)*-2".ParseCalculationString();
            Assert.AreEqual<double>(-(3 - (-4 * (6 - 5)) * 7) * -2, value);
        }

        [TestMethod]
        public void TestClacFunctionSin()
        {
            double value = "sin(3*4,5)*2".ParseCalculationString();
            Assert.AreEqual<double>((Math.Sin(3d * 4.5d) * 2d).Truncate(6), value);
        }

        [TestMethod]
        public void TestClacFunctionCos()
        {
            double value = "cos(3*4,5)*2".ParseCalculationString();
            Assert.AreEqual<double>((Math.Cos(3d * 4.5d) * 2d).Truncate(3), value.Truncate(3));
        }

        [TestMethod]
        public void TestClacFunctionTan()
        {
            double value = "tan(3*4,5)*2".ParseCalculationString();
            Assert.AreEqual<double>((Math.Tan(3d * 4.5d) * 2d).Truncate(6), value);
        }

        [TestMethod]
        public void TestClacFunctionSinh()
        {
            double value = "sinh(3*4,5)*2".ParseCalculationString();
            Assert.AreEqual<double>((Math.Sinh(3d * 4.5d) * 2d).Truncate(6), value);
        }

        [TestMethod]
        public void TestClacFunctionCosh()
        {
            double value = "cosh(3*4,5)*2".ParseCalculationString();
            Assert.AreEqual<double>((Math.Cosh(3d * 4.5d) * 2d).Truncate(3), value.Truncate(3));
        }

        [TestMethod]
        public void TestClacFunctionTanh()
        {
            double value = "tanh(0.1)*2".ParseCalculationString();
            Assert.AreEqual<double>((Math.Tanh(0.1d) * 2d).Truncate(3), value.Truncate(3));
        }

        [TestMethod]
        public void TestClacFunctionSinA()
        {
            double value = "sina(0.75)*2".ParseCalculationString();
            Assert.AreEqual<double>((Math.Asin(0.75) * 2d).Truncate(3), value.Truncate(3));
        }

        [TestMethod]
        public void TestClacFunctionCosA()
        {
            double value = "cosa(0.75)*2".ParseCalculationString();
            Assert.AreEqual<double>((Math.Acos(0.75) * 2d).Truncate(3), value.Truncate(3));
        }

        [TestMethod]
        public void TestClacFunctionTanA()
        {
            double value = "tana(0.75)*2".ParseCalculationString();
            Assert.AreEqual<double>((Math.Atan(0.75) * 2d).Truncate(3), value.Truncate(3));
        }

        [TestMethod]
        public void TestClacFunctionAbs()
        {
            double value = "abs(-3*4,5)*2".ParseCalculationString();
            Assert.AreEqual<double>((Math.Abs(-3d * 4.5d) * 2d).Truncate(6), value);
        }

        [TestMethod]
        public void TestClacFunctionRound()
        {
            double value = "round(3*4,5)*2".ParseCalculationString();
            Assert.AreEqual<double>((Math.Round(3d * 4.5d) * 2d).Truncate(6), value);
        }

        [TestMethod]
        public void TestClacFunctionTrunc()
        {
            double value = "trunc(3*4,5)*2".ParseCalculationString();
            Assert.AreEqual<double>((Math.Truncate(3d * 4.5d) * 2d).Truncate(6), value);
        }

        [TestMethod]
        public void TestClacFunctionSqrt()
        {
            double value = "sqrt(3*4,5)*2".ParseCalculationString();
            Assert.AreEqual<double>((Math.Sqrt(3d * 4.5d) * 2d).Truncate(3), value.Truncate(3));
        }

        [TestMethod]
        public void TestClacFunctionMultiFunc()
        {
            double value = "-(4 * 5.23) * sin(cos(-3.45)/1.2) + 0.567".ParseCalculationString();
            Assert.AreEqual<double>((-(4 * 5.23) * Math.Sin(Math.Cos(-3.45) / 1.2) + 0.567).Truncate(3), value.Truncate(3));
        }

        [TestMethod]
        public void TestClacFunctionComplex()
        {
            double value = "3.456*(-6.2)+(-3.12*sin(8*(-cos(6.4))+9))%5.6-3/tan(7.25)".ParseCalculationString();
            Assert.AreEqual<double>((3.456 * (-6.2) + (-3.12 * Math.Sin(8 * (-Math.Cos(6.4)) + 9)) % 5.6 - 3 / Math.Tan(7.25)).Truncate(3), value.Truncate(3));
        }

        [TestMethod]
        public void Test()
        {
            double value = "3*5+8".ParseCalculationString();
        }
    }
}
