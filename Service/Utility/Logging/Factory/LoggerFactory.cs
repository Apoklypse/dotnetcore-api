using Configuration.Core.Interfaces;
using Logging.Exceptions;
using Logging.Factory.Interfaces;
using Serilog;
using Serilog.Core;

namespace Logging.Loggers
{
    public class LoggerFactory : ILoggerFactory
    {
        private readonly ILoggingConfiguration config;

        public LoggerFactory(ILoggingConfiguration config)
        {
            this.config = config;
        }

        public ILogger CreateLogger(LoggerType loggerType)
        {
            switch (loggerType)
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
                .MinimumLevel.ControlledBy(new LoggingLevelSwitch(config.LogLevel))
                .WriteTo.Udp(config.DestinationAddress, config.DestinationPort)
                .CreateLogger();
        }
    }
}