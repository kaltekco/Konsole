using System;
using System.Runtime.Serialization;

namespace Kaltek.Konsole
{
    /// <summary>
    /// The ConsoleCommandNotFoundException class.
    /// </summary>
    [Serializable]
    internal class ConsoleCommandNotFoundException : Exception
    {
        /// <summary>
        /// Initializes an instance of ConsoleCommandNotFoundException class.
        /// </summary>
        public ConsoleCommandNotFoundException()
        {
        }

        /// <summary>
        /// Initializes an instance of ConsoleCommandNotFoundException class.
        /// </summary>
        /// <param name="command">The command name.</param>
        public ConsoleCommandNotFoundException(string command) : base($"Command {command} not found.")
        {
        }

        /// <summary>
        /// Initializes an instance of ConsoleCommandNotFoundException class.
        /// </summary>
        /// <param name="command">The command name.</param>
        /// <param name="innerException">The inner exception.</param>
        public ConsoleCommandNotFoundException(string command, Exception innerException) : base($"Command {command} not found.", innerException)
        {
        }

        /// <summary>
        /// Initializes an instance of ConsoleCommandNotFoundException class.
        /// </summary>
        /// <param name="info">The Serialization info.</param>
        /// <param name="context">The streaming context.</param>
        protected ConsoleCommandNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}