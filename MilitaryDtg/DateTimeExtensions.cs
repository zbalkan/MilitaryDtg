using System;

namespace MilitaryDtg
{
    public static class DateTimeExtensions
    {
        public static DTG ToDTG(this DateTime dateTime, TimeZoneInfo timeZone)
        {
            var milZoneAbbr = (Mil.TimeZoneOffset)timeZone.GetUtcOffset(dateTime).Hours;
            var milDateObj = DateTimeMil.GetMilDate(dateTime, milZoneAbbr.ToString());
            var dateTimeGroup = new DTG(milDateObj);
            return dateTimeGroup;
        }


        public static DTG ToDTG(this DateTime dateTime)
        {
            return dateTime.ToDTG(TimeZoneInfo.Local);
        }

    }
}
