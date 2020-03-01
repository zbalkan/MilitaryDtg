using System;
using MilitaryDtg.Properties;

namespace MilitaryDtg
{
    internal sealed class MilDate : IMilDate
    {
        public DateTimeOffset? MilDateOffset { get; set; }

        public IMilTimeZone MilTimeZone { get; set; }

        /// <summary>
        ///     Return Date Time Group (DTG) string passing a format
        /// </summary>
        /// <param name="format">The DateTimeOffset string format</param>
        /// <returns></returns>
        string IMilDate.ToString(string format)
        {
            var mdtoString = string.Empty;
            if (string.IsNullOrEmpty(format)) return mdtoString;
            if (!format.StartsWith("{", StringComparison.InvariantCulture)) format = "{0:" + format + "}";
            mdtoString = string.Format(new MilDateFormatProvider(), format, this);

            return mdtoString;
        }

        /// <summary>
        ///     Return a default Date Time Group (DTG) string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var format = "{0:" + Resources.DefaultDateTimeGroupStringFormat + "}";
            var mdtoString = string.Format(new MilDateFormatProvider(), format, this);
            return mdtoString;
        }
    }
}