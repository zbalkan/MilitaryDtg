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
            string dtgString = "07142509 Z OCT 2017";
            string format = "{0:" + Settings.Default.DefaultDateTimeGroupStringFormat + "}";
            IMilDate mdto = DateTimeMil.GetMilDateFromString(dtgString);
            if (mdto.MilDateOffset.HasValue)
            {
                string mdtoString = String.Format(new MilDateFormatProvider(), format, mdto).ToUpper();
                Assert.AreEqual(dtgString, mdtoString);
            }
        }
    }
}