﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MilitaryDtg.Properties;

namespace MilitaryDtg.Test
{
    [TestClass]
    public class DateTimeMilTests
    {
        [TestMethod]
        public void GetMilDateTest()
        {
            var milZoneAbbr = Mil.TimeZoneAbbreviation.C;
            var dt = new DateTime(2012, 4, 14, 7, 8, 11);
            var milDtgOffset = DateTimeMil.GetMilDate(dt, milZoneAbbr);
            Assert.AreEqual(Mil.Alphabet.Charlie, milDtgOffset.MilTimeZone.MilTimeZoneName);
            Assert.AreEqual(milZoneAbbr, milDtgOffset.MilTimeZone.Abbreviation);
        }

        [TestMethod]
        public void GetMilDateFromStringTest()
        {
            var dtgString = "07142509 Z OCT 2017";
            var format = Settings.Default.DefaultDateTimeGroupStringFormat;

            var mdto = DateTimeMil.GetMilDateFromString(dtgString);
            if (mdto.MilDateOffset.HasValue)
            {
                Assert.AreEqual(7, mdto.MilDateOffset.Value.Day);
                Assert.AreEqual(14, mdto.MilDateOffset.Value.Hour);
                Assert.AreEqual(25, mdto.MilDateOffset.Value.Minute);
                Assert.AreEqual(9, mdto.MilDateOffset.Value.Second);
                Assert.AreEqual(Mil.Alphabet.Zulu, mdto.MilTimeZone.MilTimeZoneName);
                Assert.AreEqual(10, mdto.MilDateOffset.Value.Month);
                Assert.AreEqual(2017, mdto.MilDateOffset.Value.Year);
                Assert.AreEqual(dtgString, mdto.ToString().ToUpper());
                Assert.AreEqual(dtgString, mdto.ToString(format).ToUpper());
            }

            dtgString = "07ZOCT17";
            if (mdto.MilDateOffset.HasValue)
            {
                mdto = DateTimeMil.GetMilDateFromString(dtgString);
                Assert.AreEqual(7, mdto.MilDateOffset.Value.Day);
                Assert.AreEqual(Mil.Alphabet.Zulu, mdto.MilTimeZone.MilTimeZoneName);
                Assert.AreEqual(10, mdto.MilDateOffset.Value.Month);
                Assert.AreEqual(2017, mdto.MilDateOffset.Value.Year);
            }

            dtgString = "071345CNOV17";
            if (!mdto.MilDateOffset.HasValue) return;
            mdto = DateTimeMil.GetMilDateFromString(dtgString);
            Assert.AreEqual(7, mdto.MilDateOffset.Value.Day);
            Assert.AreEqual(13, mdto.MilDateOffset.Value.Hour);
            Assert.AreEqual(45, mdto.MilDateOffset.Value.Minute);
            Assert.AreEqual(0, mdto.MilDateOffset.Value.Second);
            Assert.AreEqual(Mil.Alphabet.Charlie, mdto.MilTimeZone.MilTimeZoneName);
            Assert.AreEqual(11, mdto.MilDateOffset.Value.Month);
            Assert.AreEqual(2017, mdto.MilDateOffset.Value.Year);
        }

        [TestMethod]
        public void GetMilDateFromString_NotValidDtgStringTest()
        {
            const string dtgString = "7ZOCT17"; // Time format is not correct 7 should be 07.  Only a valid DTG format is supported.
            var milDtgOffset = DateTimeMil.GetMilDateFromString(dtgString);
            Assert.AreEqual(null, milDtgOffset.MilDateOffset);
            Assert.AreEqual(null, milDtgOffset.MilTimeZone);
        }
    }
}