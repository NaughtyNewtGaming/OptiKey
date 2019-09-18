﻿// Copyright (c) 2019 OPTIKEY LTD (UK company number 11854839) - All Rights Reserved

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WindowsInput.Native;
using JuliusSweetland.OptiKey.InstallerActions;
using JuliusSweetland.OptiKey.Enums;
using JuliusSweetland.OptiKey.Extensions;
using JuliusSweetland.OptiKey.UI.ViewModels.Management;
using NUnit.Framework;

namespace JuliusSweetland.OptiKey.UnitTests
{
    [TestFixture]
    public class InstallerTests
    {
        [Test]
        public void TestSupportedLanguageOnly()
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("de");
            string match = CustomActions.GetDefaultLanguageCode(culture);
            Assert.AreEqual("de-DE", match);
        }

        [Test]
        public void Wibble()
        {
            // doesn´t seem to work...
            OptiKey.Properties.Resources.Culture = Languages.CatalanSpain.ToCultureInfo();

            // Get list of available eyetrackers from PointingAndSelectingViewModel
            List<KeyValuePair<string, PointsSources>> trackers = PointingAndSelectingViewModel.PointsSources;
            foreach (KeyValuePair<string, PointsSources> tracker in trackers)
            {
                string trackerLabel = tracker.Key;
                string trackerEnum = tracker.Value.ToString();

            }

            // Get list of available languages to choose from
            List<KeyValuePair<string, Languages>> languagePairs = WordsViewModel.Languages;
            List<string> languages = (from kvp in languagePairs select kvp.Value.ToCultureInfo().Name).ToList();
            foreach (string lang in languages)
            {

            }


        }


        [Test]
        public void TestUnsupportedLanguageOnly()
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("vo-001");
            string match = CustomActions.GetDefaultLanguageCode(culture);
            // If not supported at all, default to uk english
            Assert.AreEqual("en-GB", match);
        }

        [Test]
        public void TestSupportedLanguageAndCountry()
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("da-DK");
            string match = CustomActions.GetDefaultLanguageCode(culture);
            Assert.AreEqual("da-DK", match);
        }

        [Test]
        public void TestSupportedLanguageAndUnsupportedCountry()
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("da-GL");
            string match = CustomActions.GetDefaultLanguageCode(culture);

            // Default to matching language, if not country
            Assert.True(match.Contains("da"));
        }

        [Test]
        public void TestSupportedLanguageAndUnsupportedCountryWithDefaults()
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("en-FK");
            string match = CustomActions.GetDefaultLanguageCode(culture);

            // Default to English UK 
            Assert.AreEqual( "en-GB", match);
        }

    }
}
