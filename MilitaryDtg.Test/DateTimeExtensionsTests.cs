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
            
            Assert.AreEqual(tz.ToMilitaryTimeZoneName(), milDate.MilTimeZone.MilTimeZoneName);
            Assert.AreEqual(tz.ToMilitaryTimeZone().ToString(), milDate.MilTimeZone.Abbreviation);
        }

        [TestMethod]
        public void GetMilDateFromDateTimeWithoutTimeZone()
        {
            var dateTime = new DateTime(2020,3,1,14,30,00);
            var tz = TimeZoneInfo.Local;
            var milDate = dateTime.ToDTG();

            Assert.AreEqual(tz.ToMilitaryTimeZoneName(), milDate.MilTimeZone.MilTimeZoneName);
            Assert.AreEqual(tz.ToMilitaryTimeZone().ToString(), milDate.MilTimeZone.Abbreviation);
        }
    }
}
