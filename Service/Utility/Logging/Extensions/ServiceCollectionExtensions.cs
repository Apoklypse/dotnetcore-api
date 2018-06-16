using Logging;
using Logging.Loggers;
using Serilog;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureLogging(this IServiceCollection services)
        {
            var loggerFactory = new LoggerFactory();
            var logger = loggerFactory.CreateLogger(LoggerType.Log2Console);

            services.AddTransient<ILogger>(serviceProvider => logger);
        }
    }
}
