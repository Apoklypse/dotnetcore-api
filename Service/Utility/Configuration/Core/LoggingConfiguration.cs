using Configuration.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Configuration.Core
{
    public class LoggingConfiguration : ILoggingConfiguration
    {
        public static readonly string SectionName = "Logging";

        public LoggingConfiguration(IConfigurationSection section)
        {
            this.DestinationAddress = section[nameof(DestinationAddress)];
            this.LogLevel = section[nameof(LogLevel)];

            int port;
            int.TryParse(section[nameof(DestinationPort)], out port);
            this.DestinationPort = port;
        }

        public string DestinationAddress { get; }

        public int DestinationPort { get; }

        public string LogLevel { get; }
    }
}