using Configuration.Core.Interfaces;
using Data;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly ILogger logger;
        private readonly ISqlConfiguration config;

        public TestController(
            ILogger loggerParam,
            ISqlConfiguration configParam)
        {
            this.logger = loggerParam ?? throw new ArgumentNullException(nameof(loggerParam));
            this.config = configParam ?? throw new ArgumentNullException(nameof(configParam));
        }

        [HttpGet("{nameParam}")]
        public IActionResult Get(string nameParam)
        {
            var tester = new DapperTest(config);

            this.logger.Debug("Running test");
            var result = tester.Test(nameParam);

            return new JsonResult(result);
        }
    }
}