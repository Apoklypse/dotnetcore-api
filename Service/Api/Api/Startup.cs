using Configuration.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(this.config.Swagger);
            }

            app.UseMvc();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddServices(this.config.Logging);
            services.AddSwagger(this.config.Swagger);
        }
    }
}