namespace gb.Runtime
{
    using UnityEngine;

    using System.Linq;

    using System;

    public static class Logging
    {
        public static ILogger Debug;

        private static LogSettings settings;

        private static ILogMessageTemplate template;

        [RuntimeInitializeOnLoadMethod]
        static void OnRuntimeMethodLoad()
        {
            if (settings == null)
            {
                settings = Resources.Load<LogSettings>($"{nameof(LogSettings)}");
            }

            if (UnityEngine.Debug.isDebugBuild)
            {
                var templateString = settings.Templates.FirstOrDefault(x => x.Symbol == "Debug");
                if (templateString != null)
                {
                    template = templateString.TemplateString;
                }
            }

            Debug = new Logger(new LogHandler(template));
        }
    }
}