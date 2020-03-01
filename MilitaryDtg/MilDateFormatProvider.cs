using System;
using System.Globalization;
using MilitaryDtg.Properties;

namespace MilitaryDtg
{
    /// <summary>
    ///     Custom IMilDate formatter.
    ///     Use Properties.Settings.Default.DateTimeGroupTimeZoneFormatString
    ///     value to insert military time zone abbreviation.  MilDateFormatProvider uses
    ///     same string formats as System.DateTimeOffset type.
    /// </summary>
    public class MilDateFormatProvider : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        ///     Adds the Properties.Settings.Default.DateTimeGroupTimeZoneFormatString
        ///     value to allow for Military Date Time Group (DTG) string formats.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="arg"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            string mildateString;
            var thisFmt = string.Empty;

            if (!string.IsNullOrEmpty(format))
                thisFmt = format;

            if (arg is IMilDate milDate)
            {
                const char repChar = '*';
                var dtgTimeZone = Resources.DateTimeGroupTimeZoneFormatString;
                var replaceString = string.Empty.PadRight(dtgTimeZone.Length, repChar);
                var dto = milDate.MilDateOffset;
                mildateString = dto.Value.ToString(thisFmt.Replace(dtgTimeZone, replaceString, StringComparison.InvariantCulture), formatProvider)
                    .Replace(replaceString, milDate.MilTimeZone.Abbreviation, StringComparison.InvariantCulture);
            }
            else
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException($"The format of '{format}' is invalid.", e);
                }
            }

            return mildateString;
        }

        public object GetFormat(Type formatType) => formatType == typeof(ICustomFormatter) ? this : null;

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable formattable)
                return formattable.ToString(format, CultureInfo.CurrentCulture);
            return arg != null ? arg.ToString() : string.Empty;
        }
    }
}