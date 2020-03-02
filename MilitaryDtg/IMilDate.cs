using System;

namespace MilitaryDtg
{
    internal interface IMilDate
    {
        IMilTimeZone MilTimeZone { get; set; }
        DateTimeOffset? MilDateOffset { get; set; }
        string ToString(string format);
    }
}