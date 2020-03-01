using System;

namespace MilitaryDtg
{
    public interface IMilDate
    {
        IMilTimeZone MilTimeZone { get; set; }
        DateTimeOffset? MilDateOffset { get; set; }
        string ToString(string format);
    }
}