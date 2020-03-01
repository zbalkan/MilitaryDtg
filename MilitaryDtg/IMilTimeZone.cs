using System;

namespace MilitaryDtg
{
    public interface IMilTimeZone
    {
        int Offset { get; set; }
        string Abbreviation { get; set; }
        string MilTimeZoneName { get; set; }
        TimeZoneInfo TimeZoneInfo { get; set; }
    }
}