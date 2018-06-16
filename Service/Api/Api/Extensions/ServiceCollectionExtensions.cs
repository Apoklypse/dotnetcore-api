﻿using Services.Email;
using Services.EmailService;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IEmailSender, MailKitSender>();
            services.ConfigureLogging();
        }
    }
}