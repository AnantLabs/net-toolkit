using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.Tools.Test
{
    [TestClass]
    public class DecimalExtensionTest
    {
        [TestMethod]
        public void TestRound()
        {
            double number = 1.2367d;
            Assert.AreEqual(1.24d, number.Round(2));
        }

        [TestMethod]
        public void TestTruncate()
        {
            double number = 1.2367d;
            Assert.AreEqual(1.23d, number.Truncate(2));
        }
    }
}
