using Microsoft.Extensions.DependencyInjection;

namespace Kaltek.Konsole
{
    /// <summary>
    /// The ServiceCollectionExtensions class.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds console commands to the service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The IServiceCollection object.</returns>
        public static IServiceCollection AddConsoleCommands(this IServiceCollection services)
        {
            var commandFinder = new ConsoleCommandFinder();

            foreach (var ti in commandFinder.AvailableCommands)
            {
                services.AddTransient(ti);
            }

            services.AddSingleton(commandFinder);
            services.AddSingleton<IConsoleCommandHandler, ConsoleCommandHandler>();

            return services;
        }
    }
}
