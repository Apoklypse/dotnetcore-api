using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Core.Interfaces
{
    public interface IDapperClient
    {
        IEnumerable<ResultType> ExecuteStoredProcedure<ResultType>(string storedProcedureName);

        IEnumerable<ResultType> ExecuteStoredProcedure<ResultType>(string storedProcedureName, DynamicParameters parameters);
    }
}
