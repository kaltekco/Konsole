using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Kaltek.Konsole
{
    /// <summary>
    /// The console command helper.
    /// </summary>
    internal class ConsoleCommandHandler : IConsoleCommandHandler
    {
        private static readonly Type _consoleCommandType = typeof(IConsoleCommand);

        private readonly IServiceProvider _services;

        private readonly ConsoleCommandFinder _consoleCommandFinder;

        /// <summary>
        /// Initializes an instance of ConsoleCommandHandler class.
        /// </summary>
        /// <param name="services"></param>
        public ConsoleCommandHandler(IServiceProvider services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
            _consoleCommandFinder = _services.GetService<ConsoleCommandFinder>();
        }

        /// <summary>
        /// Processes the command specified by the args.
        /// </summary>
        /// <param name="args">The command line args.</param>
        /// <returns>A task.</returns>
        public async Task Process(string[] args)
        {
            if (args == null || !args.Any() || (args[0] == "--help") || (args[0] == "-h"))
            {
                // Print available commands
                Console.WriteLine("Available commands");

                foreach (var cmd in _consoleCommandFinder.AvailableCommands)
                {
                    Console.WriteLine($"{cmd.Name.Replace("Command", "")}:");

                    var commandInfo = _services.GetService(cmd) as IConsoleCommand;
                    commandInfo.PrintUsage();
                    Console.WriteLine();
                }

                return;
            }

            var command = args[0] + "Command";

            var commandType = _consoleCommandFinder.Find(command);

            if (commandType == null)
            {
                throw new ConsoleCommandNotFoundException(args[0]);
            }

            var help = args.Length > 1 ? (args[1] == "--help") | (args[1] == "-h") : false;

            var consoleCommand = _services.GetService(commandType) as IConsoleCommand;

            if (help)
            {
                consoleCommand.PrintUsage();
                return;
            }

            await consoleCommand
                .Execute(new ConsoleCommandArguments(args.Skip(1).Take(args.Length - 1).ToArray()))
                .ConfigureAwait(false);
        }
    }
}
