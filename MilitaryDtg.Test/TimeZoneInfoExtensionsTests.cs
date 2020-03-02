using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MilitaryDtg.Test
{
    [TestClass]
    public class TimeZoneInfoExtensionsTests
    {
        [TestMethod]
        public void ShouldConvertUTCToDTZZulu()
        {
            var timezone = TimeZoneInfo.Utc;
            var dtz = timezone.ToDTZ();

            Assert.AreEqual("Z", dtz.Abbreviation);
            Assert.AreEqual("Zulu", dtz.MilTimeZoneName);
            Assert.AreEqual(0, dtz.Offset);
        } 

        [TestMethod]
        public void ShouldConvertLocalToDTZ()
        {
            var timezone = TimeZoneInfo.Local;
            var dtz = timezone.ToDTZ();

            Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset.Hours, dtz.Offset);
        } 
    }
}
