﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usa.Mil.Dtg
{
    public class MilitaryTimeZone : IMilitaryTimeZone
    {
        public int Offset
        {
            get;
            set;
        }

        public string Abbreviation
        {
            get;
            set;
        }

        public string MilitarTimeZoneName
        {
            get;
            set;
        }

        public TimeZoneInfo TimeZoneInfo
        {
            get;
            set;
        }
    }
}
