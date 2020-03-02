using System;

namespace MilitaryDtg
{
    internal class MilTimeZone : IMilTimeZone
    {
        public int Offset { get; set; }

        public string Abbreviation { get; set; }

        public string MilTimeZoneName { get; set; }

        public TimeZoneInfo TimeZoneInfo { get; set; }
    }
}