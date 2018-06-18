using Serilog.Events;
namespace Configuration.Core.Interfaces
{
    public interface ILoggingConfiguration
    {
        string DestinationAddress { get; }

        int DestinationPort { get; }

        LogEventLevel LogLevel { get; }
    }
}
