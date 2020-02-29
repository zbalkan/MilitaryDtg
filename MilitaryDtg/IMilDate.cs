using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryDtg
{
    public interface IMilDate
    {
        IMilTimeZone MilTimeZone { get; set; }
        DateTimeOffset? MilDateOffset { get; set; }
        string ToString(string format);     
    }
}
