using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Kaltek.Konsole;

namespace KonsoleExample
{
    public class MyApplication : IHostedService
    {
        /// <summary>
        /// The IConsoleCommandHandler object.
        /// </summary>
        private readonly IConsoleCommandHandler _consoleCommandHandler;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Application lifetime object.
        /// </summary>
        private readonly IHostApplicationLifetime _applicationLifetime;

        /// <summary>
        /// Initializes an instance of SyncWorkerApplication class.
        /// </summary>
        /// <param name="consoleCommandHandler">The IConsoleCommandHelper object.</param>
        /// <param name="applicationLifetime">The IApplicationLifetime object.</param>
        /// <param name="logger">The logger.</param>
        public MyApplication(
            IConsoleCommandHandler consoleCommandHandler,
            IHostApplicationLifetime applicationLifetime,
            ILogger<MyApplication> logger)
        {
            _consoleCommandHandler = consoleCommandHandler ?? throw new ArgumentNullException(nameof(consoleCommandHandler));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _applicationLifetime = applicationLifetime ?? throw new ArgumentNullException(nameof(applicationLifetime));
        }

        /// <summary>
        /// Starts the hosted service.
        /// </summary>
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug("Starting Console Application...");

            var args = Environment.GetCommandLineArgs();

            await _consoleCommandHandler
                .Process(args.Skip(1).Take(args.Length - 1).ToArray())
                .ConfigureAwait(false);

            _applicationLifetime.StopApplication();
        }

        /// <summary>
        /// Stops the hosted service.
        /// </summary>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
