﻿using BreadPlayer.Core.Common;
using Windows.Storage;

namespace BreadPlayer.Common
{
    public class RoamingSettingsHelper : IEqualizerSettingsHelper
    {
        public static void SaveSetting(string key, object value)
        {
            ApplicationData.Current.RoamingSettings.Values[key] = value;
        }
        public static T GetSetting<T>(string key, object def)
        {
            object setting = ApplicationData.Current.RoamingSettings.Values[key] ?? def;
            return (T)setting;
        }

        public (float[] EqConfig, bool IsEnabled) LoadEqualizerSettings()
        {
            return (GetSetting<float[]>("EqualizerConfig", new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }),
                    GetSetting<bool>("IsEqEnabled", false));
        }

        public void SaveEqualizerSettings(float[] eqConfig, bool isEnabled)
        {
            SaveSetting("EqualizerConfig", eqConfig);
            SaveSetting("IsEqEnabled", isEnabled);
        }
    }
}
