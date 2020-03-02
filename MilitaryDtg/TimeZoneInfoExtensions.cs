using System;
using System.Linq;

namespace MilitaryDtg
{
    public static class TimeZoneInfoExtensions
    {
        public static string ToMilitaryTimeZone(this TimeZoneInfo timeZoneInfo) =>
            ((Mil.TimeZoneOffset) timeZoneInfo.BaseUtcOffset.Hours).ToString();

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