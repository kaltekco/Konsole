using System;
using System.Threading.Tasks;
using Kaltek.Konsole;

namespace KonsoleExample.Commands
{
    public class WelcomeCommand : IConsoleCommand
    {
        public WelcomeCommand()
        {
        }

        public Task Execute(ConsoleCommandArguments args)
        {
            if (args.HasArgument("--name", "-n"))
            {
                var name = args.GetValueForArgument<string>("--name", "-n");

                Console.WriteLine($"Hello {name}! Welcome to Konsole.");
            }

            return Task.CompletedTask;
        }

        public void PrintUsage()
        {
            Console.WriteLine("Welcome Command");
            Console.WriteLine("Prints a welcome message");
        }
    }
}
