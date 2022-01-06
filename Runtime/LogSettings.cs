#if UNITY_EDITOR
using Hextant.Editor;

using UnityEditor;
#endif

namespace gb.Runtime
{
    using System;
    using System.Collections.Generic;

    using Hextant;

    using UnityEngine;

    [Settings(SettingsUsage.RuntimeProject, "Debug Log Settings")]
    public sealed class LogSettings : Settings<LogSettings>
    {
        [SerializeField]
        private List<TemplateLiteral> templates = new();

        public List<TemplateLiteral> Templates => this.templates;
#if UNITY_EDITOR
        [SettingsProvider]
        private static SettingsProvider GetSettingsProvider()
        {
            return instance.GetSettingsProvider();
        }

#endif

        [Serializable]
        public class TemplateLiteral
        {
            [SerializeField]
            private string symbol;

            [SerializeReference]
            private LogMessageSetting templateString;

            public LogMessageSetting TemplateString => this.templateString;

            public string Symbol => this.symbol;
        }
    }
}