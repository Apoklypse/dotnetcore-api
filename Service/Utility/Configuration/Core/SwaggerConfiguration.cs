using Configuration.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Configuration.Core
{
    public class SwaggerConfiguration : ISwaggerConfiguration
    {
        public static readonly string SectionName = "Swagger";

        public SwaggerConfiguration(IConfigurationSection section)
        {
            this.DocTitle = section[nameof(DocTitle)];
            this.Version = section[nameof(Version)];
            this.EndpointName = section[nameof(EndpointName)];
            this.EndpointUrl = section[nameof(EndpointUrl)];
        }

        public string DocTitle { get; }

        public string Version { get; }

        public string EndpointName { get; }

        public string EndpointUrl { get; }
    }
}
