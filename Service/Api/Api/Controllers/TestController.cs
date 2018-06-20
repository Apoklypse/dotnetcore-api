using Configuration.Core.Interfaces;
using Dapper;
using Data.Commands;
using Data.Core.Interfaces;
using Data.Enumerations;
using Domain.Sql;
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
        private readonly IDapperClient dapperClient;

        public TestController(
            ILogger loggerParam,
            ISqlConfiguration configParam,
            IDapperClient dapperClientParam)
        {
            this.logger = loggerParam ?? throw new ArgumentNullException(nameof(loggerParam));
            this.config = configParam ?? throw new ArgumentNullException(nameof(configParam));
            this.dapperClient = dapperClientParam ?? throw new ArgumentNullException(nameof(dapperClientParam));
        }

        [HttpGet]
        public IActionResult Get()
        {
            var command = new GetTeamsCommand(this.dapperClient);
            var result = command.Execute();

            return new JsonResult(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UpsertTeamRequest requestParam)
        {
            var request = requestParam ?? throw new ArgumentNullException();

            var command = new UpsertTeamCommand(this.dapperClient, request);
            var result = command.Execute();

            return new JsonResult(result);
        }
    }
}