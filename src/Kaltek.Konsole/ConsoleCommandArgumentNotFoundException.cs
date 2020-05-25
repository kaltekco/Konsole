using System;
using System.Runtime.Serialization;

namespace Kaltek.Konsole
{
    /// <summary>
    /// The console command argument not found exception.
    /// </summary>
    [Serializable]
    internal class ConsoleCommandArgumentNotFoundException : Exception
    {
        /// <summary>
        /// Initializes an instance of ConsoleCommandArgumentNotFoundException class.
        /// </summary>
        public ConsoleCommandArgumentNotFoundException()
        {
        }

        /// <summary>
        /// Initializes an instance of ConsoleCommandArgumentNotFoundException class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ConsoleCommandArgumentNotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes an instance of ConsoleCommandArgumentNotFoundException class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ConsoleCommandArgumentNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes an instance of ConsoleCommandArgumentNotFoundException class.
        /// </summary>
        /// <param name="info">The Serialization info.</param>
        /// <param name="context">The streaming context.</param>
        protected ConsoleCommandArgumentNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}