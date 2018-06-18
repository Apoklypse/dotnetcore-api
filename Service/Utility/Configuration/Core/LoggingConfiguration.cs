using Configuration.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Serilog.Events;
using System;

namespace Configuration.Core
{
    public class LoggingConfiguration : ILoggingConfiguration
    {
        public static readonly string SectionName = "Logging";

        public LoggingConfiguration(IConfigurationSection section)
        {
            this.DestinationAddress = section[nameof(DestinationAddress)];
            this.LogLevel = LogEventLevel.Verbose;

            LogEventLevel logLevel;
            Enum.TryParse(section[nameof(LogLevel)], out logLevel);
            this.LogLevel = logLevel;

            int destinationPort;
            int.TryParse(section[nameof(DestinationPort)], out destinationPort);
            this.DestinationPort = destinationPort;
        }

        public string DestinationAddress { get; }

        public int DestinationPort { get; }

        public LogEventLevel LogLevel { get; }
    }
}