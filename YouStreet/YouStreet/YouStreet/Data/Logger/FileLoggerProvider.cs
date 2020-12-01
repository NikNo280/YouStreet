using Microsoft.Extensions.Logging;

namespace YouStreet.Data.Logger
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private string globalLoggerPath;
        private string errorLoggerPath;
        public FileLoggerProvider(string globalLoggerPath, string errorLoggerPath)
        {
            this.globalLoggerPath = globalLoggerPath;
            this.errorLoggerPath = errorLoggerPath;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(globalLoggerPath, errorLoggerPath);
        }

        public void Dispose()
        {
        }
    }
}
