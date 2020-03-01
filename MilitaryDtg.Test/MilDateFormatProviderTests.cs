using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MilitaryDtg.Properties;

namespace MilitaryDtg.Tests
{
    [TestClass()]
    public class MilDateFormatProviderTests
    {
        [TestMethod()]
        public void FormatTest()
        {
            var dtgString = "07142509 Z OCT 2017";
            var format = "{0:" + Settings.Default.DefaultDateTimeGroupStringFormat + "}";
            var mdto = DateTimeMil.GetMilDateFromString(dtgString);
            if (mdto.MilDateOffset.HasValue)
            {
                var mdtoString = String.Format(new MilDateFormatProvider(), format, mdto).ToUpper();
                Assert.AreEqual(dtgString, mdtoString);
            }
        }
    }
}