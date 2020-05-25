using System.Threading.Tasks;

namespace Kaltek.Konsole
{
    /// <summary>
    /// The IConsoleCommand interface.
    /// </summary>
    public interface IConsoleCommand
    {
        /// <summary>
        /// Prints the command usage.
        /// </summary>
        void PrintUsage();

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="args">The arguments for the command.</param>
        /// <returns></returns>
        Task Execute(ConsoleCommandArguments args);
    }
}
