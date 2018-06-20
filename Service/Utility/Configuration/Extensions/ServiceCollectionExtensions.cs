using Configuration.Core.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {

        public static void AddConfig(this IServiceCollection services, IAppConfiguration appConfig)
        {
            services.AddSingleton(appConfig.Sql);
        }
    }
}
