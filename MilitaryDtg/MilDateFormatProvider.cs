using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryDtg
{
    /// <summary>
    /// Custom IMilDate formatter.  
    /// Use Properties.Settings.Default.DateTimeGroupTimeZoneFormatString
    /// value to insert military time zone abbreviation.  MilDateFormatProvider uses 
    /// same string formats as System.DateTimeOffset type.
    /// </summary>
    public class MilDateFormatProvider : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            return (formatType == typeof(ICustomFormatter)) ? this : null;
        }

        /// <summary>
        /// Adds the Properties.Settings.Default.DateTimeGroupTimeZoneFormatString
        /// value to allow for Military Date Time Group (DTG) string formats.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="arg"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            var mildateString = string.Empty;
            var thisFmt = string.Empty;

            if (!string.IsNullOrEmpty(format))
                thisFmt = format;

            if (arg is IMilDate)
            {
                var repChar = '*';
                var dtgTimeZone = Properties.Settings.Default.DateTimeGroupTimeZoneFormatString;
                var replaceString = string.Empty.PadRight(dtgTimeZone.Length, repChar);
                var milDate = arg as IMilDate;
                var dto = milDate.MilDateOffset;
                mildateString = dto.Value.ToString(thisFmt.Replace(dtgTimeZone, replaceString)).Replace(replaceString, milDate.MilTimeZone.Abbreviation);
            }
            else
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(string.Format("The format of '{0}' is invalid.", format), e);
                }
            }

            return mildateString;                
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return string.Empty;
        }

    }
}
