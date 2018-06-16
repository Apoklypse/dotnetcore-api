using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Factory.Interfaces
{
    public interface ILoggerFactory
    {
        ILogger CreateLogger(LoggerType loggerType);
    }
}
