using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System;

namespace TeamsApi.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger logger;

        public ExceptionFilter(ILogger loggerParam)
        {
            this.logger = loggerParam ?? throw new ArgumentNullException(nameof(loggerParam));
        }

        public void OnException(ExceptionContext context)
        {
            this.logger.Error(context.Exception, "An error occurred: ");
        }
    }
}
