using Logging.Exceptions;
using Logging.Factory.Interfaces;
using Serilog;

namespace Logging.Loggers
{
    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger(LoggerType loggerType)
        {
            switch(loggerType)
            {
                case LoggerType.Log2Console:
                    return this.CreateLog2Console();
                default:
                    throw new UnconfiguredLoggerTypeException();
            }
        }

        private ILogger CreateLog2Console()
        {
            return new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Udp("localhost", 7071)
                .CreateLogger();
        }
    }
}
