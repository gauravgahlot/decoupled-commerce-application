using Commerce.Shared.Contracts;
using System;

namespace Commerce.Core
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"{message} Timestamp: {DateTime.Now}.");
        }
    }
}
