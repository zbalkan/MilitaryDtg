using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MilitaryDtg
{
    internal struct Mil
    {
        /// <summary>
        ///     Military Phonetic Alphabet properties.
        /// </summary>
        public struct Alphabet
        {
            public static string Alpha => "Alpha";
            public static string Bravo => "Bravo";
            public static string Charlie => "Charlie";
            public static string Delta => "Delta";
            public static string Echo => "Echo";
            public static string Foxtrot => "Foxtrot";
            public static string Golf => "Golf";
            public static string Hotel => "Hotel";
            public static string India => "India";
            public static string Kilo => "Kilo";
            public static string Lima => "Lima";
            public static string Mike => "Mike";
            public static string November => "November";
            public static string Oscar => "Oscar";
            public static string Papa => "Papa";
            public static string Quebec => "Quebec";
            public static string Romeo => "Romeo";
            public static string Sierra => "Sierra";
            public static string Tango => "Tango";
            public static string Uniform => "Uniform";
            public static string Victor => "Victor";
            public static string Whiskey => "Whiskey";
            public static string Xray => "X-ray";
            public static string Yankee => "Yankee";
            public static string Zulu => "Zulu";
        }

        /// <summary>
        ///     Military time zone abbreviations
        /// </summary>
        public struct TimeZoneAbbreviation
        {
            public static string A => "A";
            public static string B => "B";
            public static string C => "C";
            public static string D => "D";
            public static string E => "E";
            public static string F => "F";
            public static string G => "G";
            public static string H => "H";
            public static string I => "I";
            public static string K => "K";
            public static string L => "L";
            public static string M => "M";
            public static string N => "N";
            public static string O => "O";
            public static string P => "P";
            public static string Q => "Q";
            public static string R => "R";
            public static string S => "S";
            public static string T => "T";
            public static string U => "U";
            public static string V => "V";
            public static string W => "W";
            public static string X => "X";
            public static string Y => "Y";
            public static string Z => "Z";
        }

        #region Military Time Zone Names

        /// <summary>
        ///     Military time zone names
        /// </summary>
        public static readonly IReadOnlyCollection<string> TimeZoneNames = new[]
        {
            Alphabet.Alpha,
            Alphabet.Bravo,
            Alphabet.Charlie,
            Alphabet.Delta,
            Alphabet.Echo,
            Alphabet.Foxtrot,
            Alphabet.Golf,
            Alphabet.Hotel,
            Alphabet.India,
            Alphabet.Kilo,
            Alphabet.Lima,
            Alphabet.Mike,
            Alphabet.November,
            Alphabet.Oscar,
            Alphabet.Papa,
            Alphabet.Quebec,
            Alphabet.Romeo,
            Alphabet.Sierra,
            Alphabet.Tango,
            Alphabet.Uniform,
            Alphabet.Victor,
            Alphabet.Whiskey,
            Alphabet.Xray,
            Alphabet.Yankee,
            Alphabet.Zulu
        };

        #endregion

        #region Time Zone Letter Time Offset Relationship

        /// <summary>
        ///     Time zone abbreviation to time offset values
        /// </summary>
        public enum TimeZoneOffset
        {
            A = 1,
            B = 2,
            C = 3,
            D = 4,
            E = 5,
            F = 6,
            G = 7,
            H = 8,
            I = 9,
            K = 10,
            L = 11,
            M = 12,
            N = -1,
            O = -2,
            P = -3,
            Q = -4,
            R = -5,
            S = -6,
            T = -7,
            U = -8,
            V = -9,
            W = -10,
            X = -11,
            Y = -12,
            Z = 0
        }

        #endregion

        /// <summary>
        ///     Global time zones
        /// </summary>
        public static readonly IReadOnlyCollection<TimeZoneInfo> SystemTimeZones = TimeZoneInfo.GetSystemTimeZones();

        /// <summary>
        ///     Abbreviated month names
        /// </summary>
        public static readonly List<string> AbbreviatedMonthNames =
            DateTimeFormatInfo.CurrentInfo?.AbbreviatedMonthNames.ToList();
    }
}