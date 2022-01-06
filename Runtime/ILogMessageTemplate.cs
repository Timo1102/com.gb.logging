namespace gb.Runtime
{
    using UnityEngine;

    public interface ILogMessageTemplate
    {
        /// <summary>
        /// The message.
        /// </summary>
        /// <param name="logType">
        /// The log type.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string Message(LogType logType, Object context, string format, params object[] args);
    }
}
