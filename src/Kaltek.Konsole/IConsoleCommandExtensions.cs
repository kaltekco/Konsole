namespace Kaltek.Konsole
{
    /// <summary>
    /// The IConsoleCommandExtensions extension class.
    /// </summary>
    public static class IConsoleCommandExtensions
    {
        /// <summary>
        /// Gets the command name for the IConsoleCommand command.
        /// </summary>
        /// <param name="command">The IConsoleCommand command.</param>
        /// <returns>The name of the command.</returns>
        public static string GetCommandName(this IConsoleCommand command)
        {
            return command?.GetType().Name.Replace("Command", "");
        }
    }
}
