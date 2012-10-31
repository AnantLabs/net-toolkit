using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.Tools;

namespace NET.Tools.Test
{
    [TestClass]
    public class RomanNumbersCreationTest
    {
        [TestMethod]
        public void TestSimple1()
        {
            long number = 1;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("I", str);
        }

        [TestMethod]
        public void TestSimple3()
        {
            long number = 3;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("III", str);
        }

        [TestMethod]
        public void TestSimple4()
        {
            long number = 10;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("X", str);
        }

        [TestMethod]
        public void TestSimple5()
        {
            long number = 30;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("XXX", str);
        }

        [TestMethod]
        public void TestSimple6()
        {
            long number = 100;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("C", str);
        }

        [TestMethod]
        public void TestSimple7()
        {
            long number = 300;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("CCC", str);
        }

        [TestMethod]
        public void TestSimple8()
        {
            long number = 1000;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("M", str);
        }

        [TestMethod]
        public void TestSimple9()
        {
            long number = 3000;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("MMM", str);
        }

        [TestMethod]
        public void TestHalf1()
        {
            long number = 5;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("V", str);
        }

        [TestMethod]
        public void TestHalf2()
        {
            long number = 50;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("L", str);
        }

        [TestMethod]
        public void TestHalf3()
        {
            long number = 500;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("D", str);
        }

        [TestMethod]
        public void TestSubtraction1()
        {
            long number = 4;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("IV", str);
        }

        [TestMethod]
        public void TestSubtraction2()
        {
            long number = 40;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("XL", str);
        }

        [TestMethod]
        public void TestSubtraction3()
        {
            long number = 400;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("CD", str);
        }

        [TestMethod]
        public void TestSubtraction4()
        {
            long number = 9;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("IX", str);
        }

        [TestMethod]
        public void TestSubtraction5()
        {
            long number = 90;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("XC", str);
        }

        [TestMethod]
        public void TestSubtraction6()
        {
            long number = 900;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("CM", str);
        }

        [TestMethod]
        public void TestAddition1()
        {
            long number = 6;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("VI", str);
        }

        [TestMethod]
        public void TestAddition2()
        {
            long number = 8;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("VIII", str);
        }

        [TestMethod]
        public void TestAddition3()
        {
            long number = 60;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("LX", str);
        }

        [TestMethod]
        public void TestAddition4()
        {
            long number = 80;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("LXXX", str);
        }

        [TestMethod]
        public void TestAddition5()
        {
            long number = 600;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("DC", str);
        }

        [TestMethod]
        public void TestAddition6()
        {
            long number = 800;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("DCCC", str);
        }

        [TestMethod]
        public void TestComplex1()
        {
            long number = 99;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("XCIX", str);
        }

        [TestMethod]
        public void TestComplex2()
        {
            long number = 1984;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("MCMLXXXIV", str);
        }

        [TestMethod]
        public void TestComplex3()
        {
            long number = 1493;
            String str = number.ToString(IntegerStringFormatType.ToRomanNumeral);

            Assert.AreEqual("MCDXCIII", str);
        }
    }
}
