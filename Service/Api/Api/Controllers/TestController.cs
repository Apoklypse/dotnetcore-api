using Configuration.Core.Interfaces;
using Dapper;
using Data.Core.Interfaces;
using Domain.Sql.Request;
using Domain.Sql.Result;
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
            var result = this.dapperClient.ExecuteStoredProcedure<GetTeamsResult>("GetTeams");

            return new JsonResult(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UpsertTeamRequest requestParam)
        {
            var request = requestParam ?? throw new ArgumentNullException();

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(nameof(requestParam.Name), requestParam.Name);

            var result = this.dapperClient.ExecuteStoredProcedure<UpsertTeamResult>("UpsertTeam", parameters);

            return new JsonResult(result);
        }
    }
}