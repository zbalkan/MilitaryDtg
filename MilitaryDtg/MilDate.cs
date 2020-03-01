﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryDtg.Properties;

namespace MilitaryDtg
{
    sealed class MilDate : IMilDate
    {
        public DateTimeOffset? MilDateOffset
        {
            get;
            set;
        }

        public IMilTimeZone MilTimeZone
        {
            get;
            set;
        }

        /// <summary>
        /// Return a default Date Time Group (DTG) string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var format = "{0:" + Settings.Default.DefaultDateTimeGroupStringFormat + "}";
            var mdtoString = String.Format(new MilDateFormatProvider(), format, this);
            return mdtoString;
        }

        /// <summary>
        /// Return Date Time Group (DTG) string passing a format
        /// </summary>
        /// <param name="format">The DateTimeOffset string format</param>
        /// <returns></returns>
        string IMilDate.ToString(string format)
        {
            var mdtoString = string.Empty;
            if (!string.IsNullOrEmpty(format))
            {
                if (!format.StartsWith("{"))
                {
                    format = "{0:" + format + "}";
                }
                mdtoString = String.Format(new MilDateFormatProvider(), format, this);
            }                
                        
            return mdtoString;
        }                      
    }
}
