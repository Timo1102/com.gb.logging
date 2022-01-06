namespace gb.Runtime
{
    using System;

    using UnityEngine;

    using Object = UnityEngine.Object;

    [CreateAssetMenu(menuName = "LogMessageTemplate", fileName = "LogMessageTemplate")]
    public class LogMessageSetting : ScriptableObject, ILogMessageTemplate
    {

        [SerializeReference]
        private Color logColor;


        [SerializeReference]
        private Color errorColor;


        [SerializeReference]
        private Color warningColor;


        public string Message(LogType logType, Object context, string format, params object[] args)
        {
            switch (logType)
            {
                case LogType.Error:
                    break;
                case LogType.Assert:
                    break;
                case LogType.Warning:
                    break;
                case LogType.Log:
                    var time = DateTime.Now;
                    return $"{time.ToString()} <color=#{ColorUtility.ToHtmlStringRGB(this.logColor)}><b>{string.Format(format, args)}</b></color>";
                case LogType.Exception:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logType), logType, null);
            }

            return string.Format(format, args);
        }
    }
}
