using System;

namespace MilitaryDtg
{
    internal interface IMilDate
    {
        DTZ DTZ { get; set; }
        DateTimeOffset? MilDateOffset { get; set; }
        string ToString(string format);
    }
}