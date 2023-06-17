using Microsoft.Extensions.Logging;

namespace Flights.Infrastructure.Log
{
    public class LoggerManager : ILoggerManager
    {
        private readonly ILogger _logger;

        public LoggerManager(ILogger<LoggerManager> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }

        public void LogError(string message)
        {
            _logger.LogError(message);
        }
    }

    public interface ILoggerManager
    {
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(string message);
    }
}
