using Data.Core.Interfaces;
using Data.Enumerations;
using Domain.Sql;
using System;
using System.Collections.Generic;

namespace Data.Commands
{
    public class GetTeamsCommand : Command<GetTeamsResult>
    {
        public GetTeamsCommand(IDapperClient dapperClientParam)
            : base(dapperClientParam)
        {
            this.procedureName = StoredProcedures.GetTeams.ToString();
        }

        public override IEnumerable<GetTeamsResult> Execute()
        {
            return this.dapperClient.ExecuteStoredProcedure<GetTeamsResult>(procedureName);
        }
    }
}
