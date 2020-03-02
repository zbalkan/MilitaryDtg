using System;

namespace MilitaryDtg
{
    public class DTZ : IMilTimeZone
    {
        public int Offset { get; set; }
        public string Abbreviation { get; set; }
        public string MilTimeZoneName { get; set; }
        public TimeZoneInfo TimeZoneInfo { get; set; }
    }
}