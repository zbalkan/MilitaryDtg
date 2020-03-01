using Microsoft.VisualStudio.TestTools.UnitTesting;
using MilitaryDtg.Properties;

namespace MilitaryDtg.Test
{
    [TestClass]
    public class MilDateFormatProviderTests
    {
        [TestMethod]
        public void FormatTest()
        {
            var dtgString = "07142509 Z OCT 2017";
            var format = "{0:" + Settings.Default.DefaultDateTimeGroupStringFormat + "}";
            var mdto = DateTimeMil.GetMilDateFromString(dtgString);
            if (mdto.MilDateOffset.HasValue)
            {
                var mdtoString = string.Format(new MilDateFormatProvider(), format, mdto).ToUpper();
                Assert.AreEqual(dtgString, mdtoString);
            }
        }
    }
}