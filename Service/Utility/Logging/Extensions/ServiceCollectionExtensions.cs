using Configuration.Core.Interfaces;
using Logging;
using Logging.Loggers;
using Serilog;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureLogging(this IServiceCollection services, ILoggingConfiguration config)
        {
            var loggerFactory = new LoggerFactory(config);
            var logger = loggerFactory.CreateLogger(LoggerType.Log2Console);

            services.AddTransient(serviceProvider => logger);
        }
    }
}