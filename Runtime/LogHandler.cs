namespace gb.Runtime
{
    using System;

    using UnityEngine;

    using Object = UnityEngine.Object;

    public class LogHandler : ILogHandler
    {
        private ILogMessageTemplate template;

        private ILogHandler m_DefaultLogHandler = Debug.unityLogger.logHandler;

        public LogHandler(ILogMessageTemplate template)
        {
            this.template = template;
        }

        public void LogFormat(LogType logType, Object context, string format, params object[] args)
        {

            switch (logType)
            {
                case LogType.Error:
                    Debug.LogError(this.template.Message(logType, context, format, args), context);
                    break;
                case LogType.Assert:
                    Debug.LogAssertion(this.template.Message(logType, context, format, args), context);
                    break;
                case LogType.Warning:
                    Debug.LogWarning(this.template.Message(logType, context, format, args), context);
                    break;
                case LogType.Log:
                    Debug.Log(this.template.Message(logType, context, format, args), context);
                    break;
                case LogType.Exception:
                   
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logType), logType, null);
            }
        }

        public void LogException(Exception exception, Object context)
        {
           // Debug.LogException(this.template.Message(logType, context, format, args), context);
        }
    }
}
