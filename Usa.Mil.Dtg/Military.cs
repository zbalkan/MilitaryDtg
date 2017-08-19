﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usa.Mil.Dtg
{
    public static class Military
    {
        public static string Alpha { get { return "Alpha"; } }
        public static string Bravo { get { return "Bravo"; } }
        public static string Charlie { get { return "Charlie"; } }
        public static string Delta { get { return "Delta"; } }
        public static string Echo { get { return "Echo"; } }
        public static string Foxtrot { get { return "Foxtrot"; } }
        public static string Golf { get { return "Golf"; } }
        public static string Hotel { get { return "Hotel"; } }
        public static string India { get { return "India"; } }
        public static string Kilo { get { return "Kilo"; } }
        public static string Lima { get { return "Lima"; } }
        public static string Mike { get { return "Mike"; } }
        public static string November { get { return "November"; } }
        public static string Oscar { get { return "Oscar"; } }
        public static string Papa { get { return "Papa"; } }
        public static string Quebec { get { return "Quebec"; } }
        public static string Romeo { get { return "Romeo"; } }
        public static string Sierra { get { return "Sierra"; } }
        public static string Tango { get { return "Tango"; } }
        public static string Uniform { get { return "Uniform"; } }
        public static string Victor { get { return "Victor"; } }
        public static string Whiskey { get { return "Whiskey"; } }
        public static string Xray { get { return "X-ray"; } }
        public static string Yankee { get { return "Yankee"; } }
        public static string Zulu { get { return "Zulu"; } }

        public static IReadOnlyCollection<String> MilitaryZoneNames = new String[]
        {
            Military.Alpha,
            Military.Bravo,
            Military.Charlie,
            Military.Delta,
            Military.Echo,
            Military.Foxtrot,
            Military.Golf,
            Military.Hotel,
            Military.India,
            Military.Kilo,
            Military.Lima,
            Military.Mike,
            Military.November,
            Military.Oscar,
            Military.Papa,
            Military.Quebec,
            Military.Romeo,
            Military.Sierra,
            Military.Tango,
            Military.Uniform,
            Military.Victor,
            Military.Whiskey,
            Military.Xray,
            Military.Yankee,
            Military.Zulu
        };

        public enum TimeZoneAbbreviationToOffsetVal
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

        public static IReadOnlyCollection<TimeZoneInfo> SystemTimeZones = TimeZoneInfo.GetSystemTimeZones();
    }
}
