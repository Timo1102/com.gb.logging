namespace gb.Runtime
{
    using UnityEngine;

    using System.Linq;

    using System;

    public static class Logging
    {
        public static ILogger Debug;

        private static LogSettings settings;

        private static Func<string, string> template;

        [RuntimeInitializeOnLoadMethod]
        static void OnRuntimeMethodLoad()
        {
            if (settings == null)
            {
                settings = Resources.Load<LogSettings>($"{nameof(LogSettings)}");
            }

            if (UnityEngine.Debug.isDebugBuild)
            {
                template = (message) => {
                    var templateString = settings.Templates.FirstOrDefault(x => x.Symbol == "Debug");
                    if(templateString != null)
                    {
                        return templateString.TemplateString.Replace("{message}", message);
                    }

                    return message;
                };
            }


            Debug = new Logger(UnityEngine.Debug.unityLogger);
        }

        public static void Log(string message)
        {
            Debug.Log(LogType.Log, message: template(message));
        }
    }
}