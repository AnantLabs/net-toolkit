using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.Tools;

namespace NET.Tools.Test
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für DateTimeExtensionsTest
    /// </summary>
    [TestClass]
    public class DateTimeExtensionsTest
    {
        public DateTimeExtensionsTest()
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
        public void TestDateTimeBefore()
        {
            DateTime dateTime = new DateTime(1999, 12, 12);
            Assert.IsTrue(dateTime.IsBeforeNow(), "Is not an old date!");
            Assert.IsFalse(dateTime.IsAfterNow(), "Is a future date!");
        }

        [TestMethod]
        public void TestDateTimeAfter()
        {
            DateTime dateTime = new DateTime(2100, 12, 12);
            Assert.IsTrue(dateTime.IsAfterNow(), "Is not a future date!");
            Assert.IsFalse(dateTime.IsBeforeNow(), "Is a old date!");
        }

        //[TestMethod]
        //public void TestDateTimeNow()
        //{
        //    DateTime dateTime = DateTime.Now;
        //    Assert.IsTrue(dateTime.IsNow(), "Is not the date now!");
        //}

        [TestMethod]
        public void TestDateTimeLeap()
        {
            DateTime dateTime = new DateTime(2004, 12, 12);
            Assert.IsTrue(dateTime.IsLeapYear(), "Is not a leap date!");

            dateTime = new DateTime(2003, 12, 12);
            Assert.IsFalse(dateTime.IsLeapYear(), "Is a leap date!");
        }

        [TestMethod]
        public void TestDateTimeAddDaysUntilNextDayOfWeek()
        {
            DateTime dateTime = new DateTime(2010, 12, 2);
            dateTime = dateTime.AddDaysUntilNextDayOfWeek(DayOfWeek.Sunday);

            Assert.IsTrue(
                (dateTime.Year == 2010) && (dateTime.Month == 12) &&
                (dateTime.Day == 5) && (dateTime.DayOfWeek == DayOfWeek.Sunday));
        }

        [TestMethod]
        public void TestDateTimeAddDaysUntilPrevDayOfWeek()
        {
            DateTime dateTime = new DateTime(2010, 12, 2);
            dateTime = dateTime.AddDaysUntilPrevDayOfWeek(DayOfWeek.Sunday);

            Assert.IsTrue(
                (dateTime.Year == 2010) && (dateTime.Month == 11) &&
                (dateTime.Day == 28) && (dateTime.DayOfWeek == DayOfWeek.Sunday));
        }

        [TestMethod]
        public void TestDateTimeAddDaysUntilNextDayOfWeekEquals()
        {
            DateTime dateTime = new DateTime(2010, 12, 2);
            DateTime ignore = dateTime.AddDaysUntilNextDayOfWeek(DayOfWeek.Thursday, false);
            DateTime add = dateTime.AddDaysUntilNextDayOfWeek(DayOfWeek.Thursday, true);

            Assert.IsTrue(
                (ignore.Year == 2010) && (ignore.Month == 12) &&
                (ignore.Day == 2) && (dateTime.DayOfWeek == DayOfWeek.Thursday));
            Assert.IsTrue(
                (add.Year == 2010) && (add.Month == 12) &&
                (add.Day == 9) && (add.DayOfWeek == DayOfWeek.Thursday));
        }

        [TestMethod]
        public void TestDateTimeAddDaysUntilPrevDayOfWeekEquals()
        {
            DateTime dateTime = new DateTime(2010, 12, 2);
            DateTime ignore = dateTime.AddDaysUntilPrevDayOfWeek(DayOfWeek.Thursday, false);
            DateTime add = dateTime.AddDaysUntilPrevDayOfWeek(DayOfWeek.Thursday, true);

            Assert.IsTrue(
                (ignore.Year == 2010) && (ignore.Month == 12) &&
                (ignore.Day == 2) && (dateTime.DayOfWeek == DayOfWeek.Thursday));
            Assert.IsTrue(
                (add.Year == 2010) && (add.Month == 11) &&
                (add.Day == 25) && (add.DayOfWeek == DayOfWeek.Thursday));
        }
    }
}
