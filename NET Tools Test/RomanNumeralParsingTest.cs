using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.Tools.Test
{
    [TestClass]
    public class RomanNumeralParsingTest
    {
        [TestMethod]
        public void TestSimple1()
        {
            String romanNumeral = "I";
            long number = ExtendedConverter.ConvertStringToLong(romanNumeral, IntegerStringFormatType.RomanNumeral);

            Assert.AreEqual(1L, number);
        }

        [TestMethod]
        public void TestSimple2()
        {
            String romanNumeral = "III";
            long number = ExtendedConverter.ConvertStringToLong(romanNumeral, IntegerStringFormatType.RomanNumeral);

            Assert.AreEqual(3L, number);
        }

        [TestMethod]
        public void TestSimple3()
        {
            String romanNumeral = "V";
            long number = ExtendedConverter.ConvertStringToLong(romanNumeral, IntegerStringFormatType.RomanNumeral);

            Assert.AreEqual(5L, number);
        }

        [TestMethod]
        public void TestSimple4()
        {
            String romanNumeral = "X";
            long number = ExtendedConverter.ConvertStringToLong(romanNumeral, IntegerStringFormatType.RomanNumeral);

            Assert.AreEqual(10L, number);
        }

        [TestMethod]
        public void TestSimple5()
        {
            String romanNumeral = "L";
            long number = ExtendedConverter.ConvertStringToLong(romanNumeral, IntegerStringFormatType.RomanNumeral);

            Assert.AreEqual(50L, number);
        }

        [TestMethod]
        public void TestSimple6()
        {
            String romanNumeral = "C";
            long number = ExtendedConverter.ConvertStringToLong(romanNumeral, IntegerStringFormatType.RomanNumeral);

            Assert.AreEqual(100L, number);
        }

        [TestMethod]
        public void TestSimple7()
        {
            String romanNumeral = "D";
            long number = ExtendedConverter.ConvertStringToLong(romanNumeral, IntegerStringFormatType.RomanNumeral);

            Assert.AreEqual(500L, number);
        }

        [TestMethod]
        public void TestSimple8()
        {
            String romanNumeral = "M";
            long number = ExtendedConverter.ConvertStringToLong(romanNumeral, IntegerStringFormatType.RomanNumeral);

            Assert.AreEqual(1000L, number);
        }

        [TestMethod]
        public void TestSubtraction1()
        {
            String romanNumeral = "IV";
            long number = ExtendedConverter.ConvertStringToLong(romanNumeral, IntegerStringFormatType.RomanNumeral);

            Assert.AreEqual(4L, number);
        }

        [TestMethod]
        public void TestSubtraction2()
        {
            String romanNumeral = "IX";
            long number = ExtendedConverter.ConvertStringToLong(romanNumeral, IntegerStringFormatType.RomanNumeral);

            Assert.AreEqual(9L, number);
        }

        [TestMethod]
        public void TestSubtraction3()
        {
            String romanNumeral = "XL";
            long number = ExtendedConverter.ConvertStringToLong(romanNumeral, IntegerStringFormatType.RomanNumeral);

            Assert.AreEqual(40L, number);
        }

        [TestMethod]
        public void TestSubtraction4()
        {
            String romanNumeral = "XC";
            long number = ExtendedConverter.ConvertStringToLong(romanNumeral, IntegerStringFormatType.RomanNumeral);

            Assert.AreEqual(90, number);
        }

        [TestMethod]
        public void TestSubtraction5()
        {
            String romanNumeral = "CD";
            long number = ExtendedConverter.ConvertStringToLong(romanNumeral, IntegerStringFormatType.RomanNumeral);

            Assert.AreEqual(400L, number);
        }

        [TestMethod]
        public void TestSubtraction6()
        {
            String romanNumeral = "CM";
            long number = ExtendedConverter.ConvertStringToLong(romanNumeral, IntegerStringFormatType.RomanNumeral);

            Assert.AreEqual(900L, number);
        }

        [TestMethod]
        public void TestComplex1()
        {
            String romanNumeral = "MCCXII";
            long number = ExtendedConverter.ConvertStringToLong(romanNumeral, IntegerStringFormatType.RomanNumeral);

            Assert.AreEqual(1212L, number);
        }

        [TestMethod]
        public void TestComplex2()
        {
            String romanNumeral = "MCMLXXXIV";
            long number = ExtendedConverter.ConvertStringToLong(romanNumeral, IntegerStringFormatType.RomanNumeral);

            Assert.AreEqual(1984L, number);
        }
    }
}
