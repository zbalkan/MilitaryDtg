﻿using System;

namespace MilitaryDtg
{
    public static class DateTimeExtensions
    {
        public static DTG ToDTG(this DateTime dateTime, TimeZoneInfo timeZone)
        {
            var milZoneAbbr = (Mil.TimeZoneOffset) timeZone.GetUtcOffset(dateTime).Hours;
            var milDateObj = DateTimeMil.GetMilDate(dateTime, milZoneAbbr.ToString());
            var dateTimeGroup = new DTG(milDateObj);
            return dateTimeGroup;
        }


        public static DTG ToDTG(this DateTime dateTime) => dateTime.ToDTG(TimeZoneInfo.Local);

        public static DateTime? ToDateTime(this string DTGAsString)
        {
            return new DTG(DateTimeMil.GetMilDateFromString(DTGAsString)).ToDateTime();
        }

        public static DateTime? ToDateTime(this DTG dtg)
        {
            return dtg.MilDateOffset?.DateTime;
        }
    }
}