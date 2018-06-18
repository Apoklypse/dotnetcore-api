using Serilog;

namespace Logging.Factory.Interfaces
{
    public interface ILoggerFactory
    {
        ILogger CreateLogger(LoggerType loggerType);
    }
}