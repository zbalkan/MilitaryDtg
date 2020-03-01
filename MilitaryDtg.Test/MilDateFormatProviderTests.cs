﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MilitaryDtg.Properties;

namespace MilitaryDtg.Test
{
    [TestClass]
    public class MilDateFormatProviderTests
    {
        [TestMethod]
        public void FormatTest()
        {
            const string dtgString = "07142509 Z OCT 2017";
            var format = "{0:" + Resources.DefaultDateTimeGroupStringFormat + "}";
            var mdto = DateTimeMil.GetMilDateFromString(dtgString);
            if (!mdto.MilDateOffset.HasValue) return;
            var mdtoString = string.Format(new MilDateFormatProvider(), format, mdto).ToUpper();
            Assert.AreEqual(dtgString, mdtoString);
        }
    }
}