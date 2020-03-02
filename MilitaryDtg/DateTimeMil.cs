using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryDtg
{
    internal static class DateTimeMil
    {
        static DateTimeMil()
        {
            MilTimeZones = new List<IMilTimeZone>();
            foreach (var value in Enum.GetValues(typeof(Mil.TimeZoneOffset)))
            {
                var intVal = (int) value;
                var strVal = value.ToString();
                var tZ = Mil.SystemTimeZones.FirstOrDefault(i => i.BaseUtcOffset.Hours.Equals(intVal));
                var mTName = Mil.TimeZoneNames.FirstOrDefault(z =>
                    z.StartsWith(strVal, StringComparison.InvariantCultureIgnoreCase));
                MilTimeZones.Add(new MilTimeZone
                    {TimeZoneInfo = tZ, Abbreviation = strVal, Offset = intVal, MilTimeZoneName = mTName});
            }
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static IList<IMilTimeZone> MilTimeZones { get; }

        public static IMilDate GetMilDate(DateTime? date, string milTimeZoneAbbreviation)
        {
            IMilDate mdto = new MilDate();
            if (!date.HasValue) return mdto;
            var mtz = MilTimeZones.FirstOrDefault(i =>
                milTimeZoneAbbreviation != null &&
                i.Abbreviation.Equals(milTimeZoneAbbreviation, StringComparison.InvariantCulture));
            mdto.MilTimeZone = mtz;
            if (mtz != null) mdto.MilDateOffset = new DateTimeOffset(date.Value, mtz.TimeZoneInfo.BaseUtcOffset);
            return mdto;
        }

        public static IMilDate GetMilDateFromString(string dateTimeGroupString)
        {
            IDtgTransform dT = new DtgTransform(dateTimeGroupString);
            var date = GetDateTime(dT);
            IMilDate mdto = new MilDate();
            if (!date.HasValue) return mdto;
            var mtz = MilTimeZones.FirstOrDefault(i =>
                i.Abbreviation != null &&
                i.Abbreviation.Equals(dT.MilTimeZoneAbbreviation, StringComparison.InvariantCulture));
            mdto.MilTimeZone = mtz;
            if (mtz != null) mdto.MilDateOffset = new DateTimeOffset(date.Value, mtz.TimeZoneInfo.BaseUtcOffset);
            return mdto;
        }

        /// <summary>
        ///     Get DateTime either with the time or no time part as provided.
        /// </summary>
        /// <param name="dtgTransform"></param>
        /// <returns></returns>
        private static DateTime? GetDateTime(IDtgTransform dtgTransform)
        {
            var dT = dtgTransform;
            DateTime? date;
            var isValid = dT.Year != 0 && dT.Month != 0 && dT.Day != 0;
            if (isValid)
                date = new DateTime(dT.Year, dT.Month, dT.Day, dT.Hour, dT.Minute, dT.Second);
            else
                date = null;
            return date;
        }
    }
}