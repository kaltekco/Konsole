namespace Kaltek.Konsole
{
    using System.Threading.Tasks;

    /// <summary>
    /// The IConsoleCommandHelper interface.
    /// </summary>
    public interface IConsoleCommandHandler
    {
        /// <summary>
        /// Processes the command.
        /// </summary>
        /// <param name="args">The arguments for the command.</param>
        /// <returns>A task.</returns>
        Task Process(string[] args);
    }
}
