using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MilitaryDtg.Test
{
    [TestClass]
    public class DateTimeExtensionsTests
    {
        [TestMethod]
        public void GetMilDateFromDateTimeWithTimeZone()
        {
            var dateTime = new DateTime(2020,3,1,14,30,00);
            var tz = TimeZoneInfo.Utc;
            var milDate = dateTime.ToDTG(tz);
            
            Assert.AreEqual(tz.ToDTZ().MilTimeZoneName, milDate.DTZ.MilTimeZoneName);
            Assert.AreEqual(tz.ToDTZ().Abbreviation, milDate.DTZ.Abbreviation);
        }

        [TestMethod]
        public void GetMilDateFromDateTimeWithoutTimeZone()
        {
            var dateTime = new DateTime(2020,3,1,14,30,00);
            var tz = TimeZoneInfo.Local;
            var milDate = dateTime.ToDTG();

            Assert.AreEqual(tz.ToDTZ().MilTimeZoneName, milDate.DTZ.MilTimeZoneName);
            Assert.AreEqual(tz.ToDTZ().Abbreviation, milDate.DTZ.Abbreviation);
        }
    }
}
