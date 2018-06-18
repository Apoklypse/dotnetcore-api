using Configuration.Core.Interfaces;
using Services.Email;
using Services.EmailService;
using Swashbuckle.AspNetCore.Swagger;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, ILoggingConfiguration loggingConfig)
        {
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IEmailSender, MailKitSender>();
            services.ConfigureLogging(loggingConfig);
        }

        public static void AddSwagger(this IServiceCollection services, ISwaggerConfiguration swaggerConfig)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    swaggerConfig.Version,
                    new Info
                    {
                        Title = swaggerConfig.DocTitle,
                        Version = swaggerConfig.Version
                    });
            });
        }
    }
}