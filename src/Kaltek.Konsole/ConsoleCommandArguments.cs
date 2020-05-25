using System;
using System.Linq;

namespace Kaltek.Konsole
{
    /// <summary>
    /// The console command arguments class.
    /// </summary>
    public class ConsoleCommandArguments
    {
        private readonly string[] _args;

        /// <summary>
        /// Initializes an instance of ConsoleCommandArguments class.
        /// </summary>
        /// <param name="args">The arguments list</param>
        public ConsoleCommandArguments(params string[] args)
        {
            _args = args;
        }

        /// <summary>
        /// Returns the value for the specified argument.
        /// </summary>
        /// <typeparam name="T">Return value type</typeparam>
        /// <param name="arg">Argument name</param>
        /// <param name="alternativeArg">Alternative argument name</param>
        /// <returns>The value of type T</returns>
        public T GetValueForArgument<T>(string arg, string alternativeArg)
        {
            if ((_args == null) || 
                !(_args.Contains(arg) || 
                 (!string.IsNullOrEmpty(alternativeArg) && _args.Contains(alternativeArg))))
            {
                throw new ConsoleCommandArgumentNotFoundException(arg);
            }

            var indexOfArg = Array.IndexOf(_args, arg);

            if (indexOfArg < 0)
            {
                indexOfArg = Array.IndexOf(_args, alternativeArg);
            }

            if (_args.Length <= indexOfArg)
            {
                throw new ConsoleCommandArgumentNotFoundException($"Value not found for ${arg}");
            }

            return (T)Convert.ChangeType(_args[indexOfArg + 1], typeof(T));
        }

        /// <summary>
        /// Checks if the argument exists
        /// </summary>
        /// <param name="arg">Argument name</param>
        /// <param name="alternativeArg">Alternative argument name</param>
        /// <returns>True if argument exists</returns>
        public bool HasArgument(string arg, string alternativeArg)
        {
            return (_args?.Contains(arg) == true) || (!string.IsNullOrEmpty(alternativeArg) && (_args?.Contains(alternativeArg) == true));
        }

        /// <summary>
        /// Checks if minimum number of arguments are supplied
        /// </summary>
        /// <param name="count">The count</param>
        /// <returns>True if minimum number of arguments exists</returns>
        public bool HasMinimumCount(int count)
        {
            return (_args?.Length >= count);
        }

        /// <summary>
        /// Returns the value at a specified index.
        /// </summary>
        /// <typeparam name="T">The return type</typeparam>
        /// <param name="index">Index</param>
        /// <returns>The value at index</returns>
        public T GetValueAtIndex<T>(int index)
        {
            if (HasMinimumCount(index + 1))
            {
                return (T)Convert.ChangeType(_args[index], typeof(T));
            }

            return default;
        }
    }
}
