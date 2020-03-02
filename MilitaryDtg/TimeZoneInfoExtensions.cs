using System;
using System.Linq;

namespace MilitaryDtg
{
    public static class TimeZoneInfoExtensions
    {
        public static char ToMilitaryTimeZone(this TimeZoneInfo timeZoneInfo)
        {
            return ((Mil.TimeZoneOffset)timeZoneInfo.BaseUtcOffset.Hours).ToString()[0];
        }

        public static string ToMilitaryTimeZoneName(this TimeZoneInfo timeZoneInfo)
        {
            return Mil.TimeZoneNames.FirstOrDefault(n => n.StartsWith(timeZoneInfo.ToMilitaryTimeZone()));
        }

        public static TimeZoneInfo FromMilitaryTimeZone(this char militaryTimeZone)
        {
            return TimeZoneInfo.GetSystemTimeZones()
                .FirstOrDefault(t => t.BaseUtcOffset.Hours == int.Parse(militaryTimeZone.ToString()));
        }
    }
}
