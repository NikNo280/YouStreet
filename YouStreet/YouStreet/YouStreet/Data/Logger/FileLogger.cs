using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace YouStreet.Data.Logger
{
    public class FileLogger : ILogger
    {
        private string globalLoggerPath;
        private string errorLoggerPath;
        private static object _lock = new object();
        public FileLogger(string globalLoggerPath, string errorLoggerPath)
        {
            this.globalLoggerPath = globalLoggerPath;
            this.errorLoggerPath = errorLoggerPath;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            //return logLevel == LogLevel.Trace;
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                lock (_lock)
                {
                    File.AppendAllText(globalLoggerPath, formatter(state, exception) + Environment.NewLine);
                    if (logLevel == LogLevel.Warning || logLevel == LogLevel.Error || 
                        logLevel == LogLevel.Critical)
                    {
                        File.AppendAllText(errorLoggerPath, formatter(state, exception) + Environment.NewLine);
                    }
                }
            }
        }
    }
}
