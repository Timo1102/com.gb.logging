using System.Collections.Generic;

using Hextant;
#if UNITY_EDITOR
using Hextant.Editor;
using UnityEditor;
#endif 
using UnityEngine;

[Settings(SettingsUsage.RuntimeProject, "Debug Log Settings")]
public sealed class LogSettings : Settings<LogSettings>
{
#if UNITY_EDITOR
    [SettingsProvider]
    static SettingsProvider GetSettingsProvider() => instance.GetSettingsProvider();
#endif
    [SerializeField]
    private List<TemplateLiteral> templates = new List<TemplateLiteral>();

    public List<TemplateLiteral> Templates => templates;

    [System.Serializable]
    public class TemplateLiteral
    {
        [SerializeField]
        private string symbol;
        [SerializeField]
        private string templateString;

        public string Symbol => symbol;

        public string TemplateString => templateString;
    }
}