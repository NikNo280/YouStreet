using Microsoft.Extensions.Logging;

namespace YouStreet.Data.Logger
{
    public static class FileLoggerExtensions
    {
        public static ILoggerFactory AddFile(this ILoggerFactory factory,
                                        string globalLoggerPath, string errorLoggerPath)
        {
            factory.AddProvider(new FileLoggerProvider(globalLoggerPath, errorLoggerPath));
            return factory;
        }
    }
}
