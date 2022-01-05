namespace gb.Runtime
{
    using UnityEngine;

    public static class Logging
    {
        public static ILogger Debug;

        private static LogSettings settings;

        [RuntimeInitializeOnLoadMethod]
        static void OnRuntimeMethodLoad()
        {
            if (settings == null)
            {
                settings = Resources.Load<LogSettings>($"{nameof(LogSettings)}");
            }

            Debug = new Logger(UnityEngine.Debug.unityLogger);
            // Debug.Log("After Scene is loaded and game is running from LogManager");
            //CreateInstance();
        }

        private static void CreateInstance()
        {
           
            var go = new GameObject("LogManager");
            go.AddComponent<LogManager>();

            MonoBehaviour.DontDestroyOnLoad(go);
        }

        public static void Log(string message)
        {
            Debug.Log(LogType.Log, message: Get(message));
        }

        private static string Get(string message)
        {
            string a = "Null";
            if (settings != null)
            {
                a = settings.count.ToString();
            }

            return $"{a} <b>{message}</b>";
        }

    }
}