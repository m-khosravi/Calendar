using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SavannahState.Calendar;
using System.Collections.Generic;

namespace CalendarTest
{
    [TestClass]
    public class UtilityTest
    {
        [TestMethod]
        public void ConvertFromJulian_valid()
        {
            DateTime actual = Utilities.ConvertFromJulian(2457136);
            DateTime expected = new DateTime(2015, 4, 23);
            Assert.AreEqual(expected, actual, "Convertion from Julian time failed");

            actual = Utilities.ConvertFromJulian(2457128);
            expected = new DateTime(2015, 4, 15);
            Assert.AreEqual(expected, actual, "Convertion from Julian time failed");
        }

        [TestMethod]
        public void ConvertToJulian_valid()
        {
            Double actual = Utilities.ConvertToJulian(new DateTime(2015, 4, 23));
            Double expected = 2457136;
            Assert.AreEqual(expected, actual, "Convertion to Julian time failed");

            actual = Utilities.ConvertToJulian(new DateTime(2015, 4, 15));
            expected = 2457128.5;
            Assert.AreEqual(expected, actual, "Convertion from Julian time failed");
        }
    }
}
