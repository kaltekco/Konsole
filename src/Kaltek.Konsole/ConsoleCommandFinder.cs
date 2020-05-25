using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Kaltek.Konsole
{
    /// <summary>
    /// The console command finder.
    /// </summary>
    internal class ConsoleCommandFinder
    {
        private readonly Type _consoleCommandType = typeof(IConsoleCommand);

        /// <summary>
        /// Initializes an instance of ConsoleCommandFinder class.
        /// </summary>
        public ConsoleCommandFinder()
        {
            AvailableCommands.AddRange(GetCommandsFromMainAssembly());
            AvailableCommands.AddRange(GetCommandsFromReferencedAssemblies());
        }

        /// <summary>
        /// Gets or sets the available commands.
        /// </summary>
        internal List<TypeInfo> AvailableCommands { get; } = new List<TypeInfo>();

        /// <summary>
        /// Finds the specified command.
        /// </summary>
        /// <param name="command">The command name</param>
        /// <returns>The TypeInfo for the command.</returns>
        internal TypeInfo Find(string command)
        {
            return AvailableCommands.SingleOrDefault(c => c.Name == command);
        }

        private IEnumerable<TypeInfo> GetCommandsFromMainAssembly()
        {
            return Assembly
                .GetEntryAssembly().DefinedTypes
                .Where(p => _consoleCommandType.IsAssignableFrom(p) && !p.IsInterface)
                .ToList();
        }

        private IEnumerable<TypeInfo> GetCommandsFromReferencedAssemblies()
        {
            var referencedAssemblies = Assembly
                .GetEntryAssembly()
                .GetReferencedAssemblies();

            return referencedAssemblies
                .Select(Assembly.Load)
                .SelectMany(x => x.DefinedTypes)
                .Where(p => _consoleCommandType.IsAssignableFrom(p) && !p.IsInterface)
                .ToList();
        }
    }
}
