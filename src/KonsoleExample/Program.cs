using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Kaltek.Konsole;

namespace KonsoleExample
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            Console.WriteLine("Console App Example");

            var hostBuilder = new HostBuilder()
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddConsoleCommands();
                    services.AddSingleton<IHostedService, MyApplication>();
                })
                .ConfigureLogging((hostContext, logging) =>
                {
                });

            try
            {
                await hostBuilder
                    .RunConsoleAsync()
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                return -1;
            }

            return 0;
        }
    }
}
