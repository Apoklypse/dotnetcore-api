using Configuration.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Api
{
    public class Startup
    {
        private readonly AppConfiguration config;

        public Startup(IConfiguration configuration)
        {
            this.config = new AppConfiguration(configuration);
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.RegisterServices(this.config.Logging);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    this.config.Swagger.Version,
                    new Info {
                        Title = this.config.Swagger.DocTitle,
                        Version = this.config.Swagger.Version
                    });
            });
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(this.config.Swagger.EndpointUrl, this.config.Swagger.EndpointName);
            });

            app.UseMvc();
        }
    }
}
