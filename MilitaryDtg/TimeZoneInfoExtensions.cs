using System;
using System.Linq;

namespace MilitaryDtg
{
    public static class TimeZoneInfoExtensions
    {
        public static TimeZoneInfo FromMilitaryTimeZone(this string militaryTimeZone)
        {
            return TimeZoneInfo.GetSystemTimeZones()
                .FirstOrDefault(t => t.BaseUtcOffset.Hours == int.Parse(militaryTimeZone));
        }

        public static DTZ ToDTZ(this TimeZoneInfo timeZoneInfo)
        {
            return new DTZ
            {
                Abbreviation = ((Mil.TimeZoneOffset)timeZoneInfo.BaseUtcOffset.Hours).ToString(),
                MilTimeZoneName = Mil.TimeZoneNames.FirstOrDefault(n => n.StartsWith(((Mil.TimeZoneOffset)timeZoneInfo.BaseUtcOffset.Hours).ToString())),
                Offset = timeZoneInfo.BaseUtcOffset.Hours,
                TimeZoneInfo = timeZoneInfo
            };
        }
    }
}