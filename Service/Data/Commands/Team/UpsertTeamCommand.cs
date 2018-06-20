using Dapper;
using Data.Core.Interfaces;
using Data.Enumerations;
using Domain.Sql;
using System;
using System.Collections.Generic;

namespace Data.Commands
{
    public class UpsertTeamCommand : ParametersCommand<UpsertTeamResult, UpsertTeamRequest>
    {
        private readonly DynamicParameters parameters;

        public UpsertTeamCommand(
            IDapperClient dapperClientParam,
            UpsertTeamRequest requestParam)
            : base(dapperClientParam)
        {
            var request = requestParam ?? throw new ArgumentNullException(nameof(requestParam));
            this.procedureName = StoredProcedures.UpsertTeam.ToString();

            this.parameters = new DynamicParameters();
            this.parameters.Add(nameof(requestParam.Name), requestParam.Name);
        }

        public override IEnumerable<UpsertTeamResult> Execute()
        {
            return this.dapperClient.ExecuteStoredProcedure<UpsertTeamResult>(procedureName, parameters);
        }
    }
}
