using Configuration.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Configuration.Core
{
    public class SqlConfiguration : ISqlConfiguration
    {
        public static readonly string SectionName = "Sql";

        public SqlConfiguration(IConfigurationSection section)
        {
            this.Server = section[nameof(Server)];
            this.InitialCatalog = section[nameof(InitialCatalog)];
            this.IntegratedSecurity = section[nameof(IntegratedSecurity)];
            this.MultipleActiveResultSets = section[nameof(MultipleActiveResultSets)];
        }

        public string Server { get; }

        public string InitialCatalog { get; }

        public string IntegratedSecurity { get; }

        public string MultipleActiveResultSets { get; }
    }
}