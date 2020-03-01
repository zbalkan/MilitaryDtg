using System;
using System.Globalization;
using System.Linq;

namespace MilitaryDtg
{
    public class DtgTransform : IDtgTransform
    {
        public DtgTransform(string dateTimeGroupString)
        {
            ProcessDtgTransform(dateTimeGroupString);
        }

        #region Properties

        public int Day { get; set; }

        public string DtgStringValue { get; set; }

        public int Hour { get; set; }

        public int Minute { get; set; }

        public int Month { get; set; }

        public int Second { get; set; }

        public int Year { get; set; }

        public string MilTimeZoneAbbreviation { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Process DTG string into values that can be used on a DateTime instance.
        /// </summary>
        /// <param name="dateTimeGroupString"></param>
        private void ProcessDtgTransform(string dateTimeGroupString)
        {
            if (string.IsNullOrEmpty(dateTimeGroupString)) throw new ArgumentNullException(nameof(dateTimeGroupString));

            DtgStringValue = dateTimeGroupString;
            var dtgVal = dateTimeGroupString.Replace(" ", string.Empty);

            var dayTimePart = new string(dtgVal.TakeWhile(c => !char.IsLetter(c)).ToArray());
            if (!string.IsNullOrEmpty(dayTimePart))
                SetDayHourMinuteSecond(dayTimePart);

            var timeZoneMonthPart = new string(dtgVal.Remove(0, dayTimePart.Length).TakeWhile(char.IsLetter).ToArray());
            if (!string.IsNullOrEmpty(timeZoneMonthPart))
            {
                var timeZonePart = timeZoneMonthPart.Substring(0, 1);
                if (!string.IsNullOrEmpty(timeZonePart))
                    SetTimeZonePart(timeZonePart);

                var monthPart = timeZoneMonthPart.Remove(0, timeZonePart.Length);
                if (!string.IsNullOrEmpty(monthPart))
                    SetMonthPart(monthPart);
            }

            var yearPart = dtgVal.Remove(0, dayTimePart.Length + timeZoneMonthPart.Length);
            if (!string.IsNullOrEmpty(yearPart))
                SetYearPart(yearPart);
        }

        /// <summary>
        ///     Set the day, hour, minute, and second values to be used on DateTime.
        /// </summary>
        /// <param name="dayTimePart"></param>
        private void SetDayHourMinuteSecond(string dayTimePart)
        {
            if (string.IsNullOrEmpty(dayTimePart)) throw new ArgumentNullException(nameof(dayTimePart));

            int day = 0, hour = 0, minute = 0, second = 0;
            var provider = new MilDateFormatProvider();

            if (dayTimePart.Length % 2 == 0)
            {
                var parts = dayTimePart.SplitInParts(2);
                /*
                 There are day and time values
                 */
                var enumerable = parts.ToList();
                if (enumerable.Count == 1)
                {
                    day = Convert.ToInt32(enumerable.First(), provider);
                }
                else if (enumerable.Count == 2)
                {
                    day = Convert.ToInt32(enumerable.First(), provider);
                    hour = Convert.ToInt32(enumerable.Last(), provider);
                }
                else if (enumerable.Count == 3)
                {
                    day = Convert.ToInt32(enumerable.First(), provider);
                    hour = Convert.ToInt32(enumerable.ElementAt(1), provider);
                    minute = Convert.ToInt32(enumerable.Last(), provider);
                }
                else if (enumerable.Count == 4)
                {
                    day = Convert.ToInt32(enumerable.First(), provider);
                    hour = Convert.ToInt32(enumerable.ElementAt(1), provider);
                    minute = Convert.ToInt32(enumerable.ElementAt(2), provider);
                    second = Convert.ToInt32(enumerable.Last(), provider);
                }
            }

            Day = day > 31 || day < 0 ? 0 : day;
            Hour = hour > 24 || hour < 0 ? 0 : hour;
            Minute = minute > 60 || minute < 0 ? 0 : minute;
            Second = second > 60 || second < 0 ? 0 : second;
        }

        /// <summary>
        ///     Set the year part
        /// </summary>
        /// <param name="yearPart"></param>
        private void SetYearPart(string yearPart)
        {
            if (string.IsNullOrEmpty(yearPart)) throw new ArgumentNullException(nameof(yearPart));
            var provider = new MilDateFormatProvider();
            int year;
            if (yearPart.Length == 2)
                // Adheres to current regional settings as defined in Control Panel (or group policy): 
                // When a two-digit year is entered, interpret it as a year between 1970 and 2069.
                year = CultureInfo.CurrentCulture.Calendar.ToFourDigitYear(Convert.ToInt32(yearPart, provider));
            else if (yearPart.Length == 4)
                year = Convert.ToInt32(yearPart, provider);
            else
                year = 0;
            Year = year;
        }

        /// <summary>
        ///     Set the time zone part military abbreviation
        /// </summary>
        /// <param name="timeZonePart"></param>
        private void SetTimeZonePart(string timeZonePart)
        {
            if (string.IsNullOrEmpty(timeZonePart)) throw new ArgumentNullException(nameof(timeZonePart));

            if (timeZonePart.Length == 1 && char.IsLetter(timeZonePart[0])) // It is one character and it is a letter.
                MilTimeZoneAbbreviation = timeZonePart;
        }

        /// <summary>
        ///     Set month part
        /// </summary>
        /// <param name="monthPart"></param>
        private void SetMonthPart(string monthPart)
        {
            if (string.IsNullOrEmpty(monthPart)) throw new ArgumentNullException(nameof(monthPart));

            if (monthPart.Length != 3) return;
            // var pair = Mil.AbbreviatedMonthNames.Select((Value, Index) => new { Value, Index }).Single(p => p.Value.Equals(monthPart, StringComparison.InvariantCultureIgnoreCase));
            var monthIdx =
                Mil.AbbreviatedMonthNames.FindIndex(x =>
                    x.Equals(monthPart, StringComparison.InvariantCultureIgnoreCase));
            Month = monthIdx + 1;
        }

        #endregion
    }
}