using System;

namespace Commerce.Core
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logging errors...");
        }
    }
}
