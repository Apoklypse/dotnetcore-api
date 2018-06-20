using Configuration.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Configuration.Core
{
    public class AppConfiguration : IAppConfiguration
    {
        public AppConfiguration(IConfiguration configuration)
        {
            this.Logging = new LoggingConfiguration(configuration.GetSection(LoggingConfiguration.SectionName));
            this.Swagger = new SwaggerConfiguration(configuration.GetSection(SwaggerConfiguration.SectionName));
            this.Sql = new SqlConfiguration(configuration.GetSection(SqlConfiguration.SectionName));
        }

        public ILoggingConfiguration Logging { get; }

        public ISwaggerConfiguration Swagger { get; }

        public ISqlConfiguration Sql { get; }
    }
}