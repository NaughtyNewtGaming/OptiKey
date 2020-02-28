// Copyright (c) 2019 OPTIKEY LTD (UK company number 11854839) - All Rights Reserved
using System;
using System.Collections.Generic;
using System.Windows;
using JuliusSweetland.OptiKey.Enums;
using JuliusSweetland.OptiKey.Models;
using JuliusSweetland.OptiKey.Properties;
using JuliusSweetland.OptiKey.Services.PluginEngine;
using log4net;
using Prism.Mvvm;
using FontStretches = JuliusSweetland.OptiKey.Enums.FontStretches;
using FontWeights = JuliusSweetland.OptiKey.Enums.FontWeights;
using JuliusSweetland.OptiKey.StandardPlugins.Translation.Languages;
using JuliusSweetland.OptiKey.StandardPlugins.Properties;

namespace JuliusSweetland.OptiKey.UI.ViewModels.Management
{
    public class FeaturesViewModel : BindableBase
    {
        #region Private Member Vars

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
        
        #region Ctor

        public FeaturesViewModel()
        {
            Load();
        }
        
        #endregion
        
        #region Properties


        private bool enableQuitKeys;
        public bool EnableQuitKeys
        {
            get { return enableQuitKeys; }
            set { SetProperty(ref enableQuitKeys, value); }
        }

        private bool enableAttentionKey;
        public bool EnableAttentionKey
        {
            get { return enableAttentionKey; }
            set { SetProperty(ref enableAttentionKey, value); }
        }

        private bool enableCopyAllScratchpadKey;
        public bool EnableCopyAllScratchpadKey
        {
            get { return enableCopyAllScratchpadKey; }
            set { SetProperty(ref enableCopyAllScratchpadKey, value); }
        }

        private bool enableTranslationKey;

        public bool EnableTranslationKey
        {
            get { return enableTranslationKey; }
            set { SetProperty(ref enableTranslationKey, value); }
        }

        private string translationTargetLanguage;
        public string TranslationTargetLanguage
        {
            get { return translationTargetLanguage; }
            set { SetProperty(ref translationTargetLanguage, value); }
        }

        public static List<KeyValuePair<string, string>> AvailableTranslationTargetLanguages
        {
            get
            {
                return new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.AZERBAIJANI, TranslationTargetLanguages.AZERBAIJANI),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.ALBANIAN, TranslationTargetLanguages.ALBANIAN),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.ARABIC, TranslationTargetLanguages.ARABIC),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.ARMENIAN, TranslationTargetLanguages.ARMENIAN),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.BASHKIR, TranslationTargetLanguages.BASHKIR),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.BELARUSIAN, TranslationTargetLanguages.BELARUSIAN),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.BULGARIAN, TranslationTargetLanguages.BULGARIAN),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.CATALAN, TranslationTargetLanguages.CATALAN),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.CROATIAN, TranslationTargetLanguages.CROATIAN),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.CZECH, TranslationTargetLanguages.CZECH),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.DANISH, TranslationTargetLanguages.DANISH),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.DUTCH, TranslationTargetLanguages.DUTCH),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.ENGLISH, TranslationTargetLanguages.ENGLISH),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.ESTONIAN, TranslationTargetLanguages.ESTONIAN),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.FINNISH, TranslationTargetLanguages.FINNISH),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.FRENCH, TranslationTargetLanguages.FRENCH),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.GEORGIAN, TranslationTargetLanguages.GEORGIAN),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.GERMAN, TranslationTargetLanguages.GERMAN),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.GREEK, TranslationTargetLanguages.GREEK),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.HEBREW, TranslationTargetLanguages.HEBREW),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.HUNGARIAN, TranslationTargetLanguages.HUNGARIAN),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.ITALIAN, TranslationTargetLanguages.ITALIAN),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.KAZAKH, TranslationTargetLanguages.KAZAKH),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.LATVIAN, TranslationTargetLanguages.LATVIAN),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.LITHUANIAN, TranslationTargetLanguages.LITHUANIAN),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.MACEDONIAN, TranslationTargetLanguages.MACEDONIAN),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.NORWEGIAN, TranslationTargetLanguages.NORWEGIAN),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.PERSIAN, TranslationTargetLanguages.PERSIAN),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.POLISH, TranslationTargetLanguages.POLISH),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.PORTUGUESE, TranslationTargetLanguages.PORTUGUESE),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.ROMANIAN, TranslationTargetLanguages.ROMANIAN),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.RUSSIAN, TranslationTargetLanguages.RUSSIAN),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.SERBIAN, TranslationTargetLanguages.SERBIAN),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.SLOVAK, TranslationTargetLanguages.SLOVAK),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.SLOVENIAN, TranslationTargetLanguages.SLOVENIAN),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.SPANISH, TranslationTargetLanguages.SPANISH),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.SWEDISH, TranslationTargetLanguages.SWEDISH),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.TATAR, TranslationTargetLanguages.TATAR),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.TURKISH, TranslationTargetLanguages.TURKISH),
                    new KeyValuePair<string, string>(StandardPlugins.Properties.Resources.UKRAINIAN, TranslationTargetLanguages.UKRAINIAN)
                };
            }
        }


        private bool enableCommuniKateKeyboardLayout;
        public bool EnableCommuniKateKeyboardLayout
        {
            get { return enableCommuniKateKeyboardLayout; }
            set
            {
                SetProperty(ref enableCommuniKateKeyboardLayout, value);
            }
        }

        private bool allowMultipleInstances;
        public bool AllowMultipleInstances
        {
            get { return allowMultipleInstances; }
            set
            {
                SetProperty(ref allowMultipleInstances, value);
            }
        }

        private string pluginsLocation;
        public string PluginsLocation
        {
            get { return pluginsLocation; }
            set { SetProperty(ref pluginsLocation, value); }
        }

        public List<Plugin> AvailablePlugins
        {
            get
            {
                return PluginEngine.GetAllAvailablePlugins();
            }
        }

        public bool ChangesRequireRestart
        {
            get {
                return  Settings.Default.CommuniKatePagesetLocation != CommuniKatePagesetLocation;
            }
        }

        private bool enablePlugins;
        public bool EnablePlugins
        {
            get { return enablePlugins; }
            set { SetProperty(ref enablePlugins, value); }
        }

        #endregion

        #region Communikate properties
        private string communiKatePagesetLocation;
        public string CommuniKatePagesetLocation
        {
            get { return communiKatePagesetLocation; }
            set { SetProperty(ref communiKatePagesetLocation, value); }
        }

        private bool communiKateStagedForDeletion;
        public bool CommuniKateStagedForDeletion
        {
            get { return communiKateStagedForDeletion; }
            set { SetProperty(ref communiKateStagedForDeletion, value); }
        }

        private int communiKateSoundVolume;
        public int CommuniKateSoundVolume
        {
            get { return communiKateSoundVolume; }
            set { SetProperty(ref communiKateSoundVolume, value); }
        }

        private bool communiKateSpeakSelected;
        public bool CommuniKateSpeakSelected
        {
            get { return communiKateSpeakSelected; }
            set { SetProperty(ref communiKateSpeakSelected, value); }
        }

        private int communiKateSpeakSelectedVolume;
        public int CommuniKateSpeakSelectedVolume
        {
            get { return communiKateSpeakSelectedVolume; }
            set { SetProperty(ref communiKateSpeakSelectedVolume, value); }
        }

        private int communiKateSpeakSelectedRate;
        public int CommuniKateSpeakSelectedRate
        {
            get { return communiKateSpeakSelectedRate; }
            set { SetProperty(ref communiKateSpeakSelectedRate, value); }
        }

        #endregion

        #region Methods

        private void Load()
        {
            EnableQuitKeys = Settings.Default.EnableQuitKeys;
            EnableAttentionKey = Settings.Default.EnableAttentionKey;
            EnableCopyAllScratchpadKey = Settings.Default.EnableCopyAllScratchpadKey;
            EnableTranslationKey = Settings.Default.EnableTranslationKey;

            EnableCommuniKateKeyboardLayout = Settings.Default.EnableCommuniKateKeyboardLayout;
            CommuniKatePagesetLocation = Settings.Default.CommuniKatePagesetLocation;
            CommuniKateStagedForDeletion = Settings.Default.CommuniKateStagedForDeletion;
            CommuniKateSoundVolume = Settings.Default.CommuniKateSoundVolume;
            CommuniKateSpeakSelected = Settings.Default.CommuniKateSpeakSelected;
            CommuniKateSpeakSelectedVolume = Settings.Default.CommuniKateSpeakSelectedVolume;
            CommuniKateSpeakSelectedRate = Settings.Default.CommuniKateSpeakSelectedRate;

            PluginsLocation = Settings.Default.PluginsLocation;
            EnablePlugins = Settings.Default.EnablePlugins;
            AllowMultipleInstances = Settings.Default.AllowMultipleInstances;
        }

        public void ApplyChanges()
        {
            Settings.Default.EnableQuitKeys = EnableQuitKeys;
            Settings.Default.EnableAttentionKey = EnableAttentionKey;
            Settings.Default.EnableCopyAllScratchpadKey = EnableCopyAllScratchpadKey;
            Settings.Default.EnableTranslationKey = EnableTranslationKey;

            Settings.Default.EnableCommuniKateKeyboardLayout = EnableCommuniKateKeyboardLayout;
            Settings.Default.CommuniKatePagesetLocation = CommuniKatePagesetLocation;
            Settings.Default.CommuniKateStagedForDeletion = CommuniKateStagedForDeletion;
            Settings.Default.CommuniKateSoundVolume = CommuniKateSoundVolume;
            Settings.Default.CommuniKateSpeakSelected = CommuniKateSpeakSelected;
            Settings.Default.CommuniKateSpeakSelectedVolume = CommuniKateSpeakSelectedVolume;
            Settings.Default.CommuniKateSpeakSelectedRate = CommuniKateSpeakSelectedRate;

            Settings.Default.PluginsLocation = PluginsLocation;
            Settings.Default.EnablePlugins = EnablePlugins;
            Settings.Default.AllowMultipleInstances = AllowMultipleInstances;
        }

        #endregion
    }
}
