using Configuration.Core.Interfaces;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseSwagger(this IApplicationBuilder app, ISwaggerConfiguration swaggerConfig)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(swaggerConfig.EndpointUrl, swaggerConfig.EndpointName);
            });
        }
    }
}