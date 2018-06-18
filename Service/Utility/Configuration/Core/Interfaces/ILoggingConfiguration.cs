using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Core.Interfaces
{
    public interface ILoggingConfiguration
    {
        string DestinationAddress { get; }

        int DestinationPort { get; }

        string LogLevel { get; }
    }
}
