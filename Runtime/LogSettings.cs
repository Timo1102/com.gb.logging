using System.Collections.Generic;

using Hextant;
#if UNITY_EDITOR
using Hextant.Editor;
using UnityEditor;
#endif 
using UnityEngine;

[Settings(SettingsUsage.RuntimeProject, "My Project Settings")]
public sealed class LogSettings : Settings<LogSettings>
{
#if UNITY_EDITOR
    [SettingsProvider]
    static SettingsProvider GetSettingsProvider() => instance.GetSettingsProvider();
#endif
    public int count { get => _count; set => Set(ref _count, value); }
    [SerializeField] int _count = 5;

    public List<string> Templates = new List<string>();

    // Example SubSettings class.
    [System.Serializable]
    public class AdvancedSettings : SubSettings
    {
        public string text { get => _text; set => Set(ref _text, value); }
        [SerializeField] string _text = "Some Text";
    }

    // The instance of the advanced settings.
    public AdvancedSettings advancedSettings => _advancedSettings;
    [SerializeField] AdvancedSettings _advancedSettings;
}