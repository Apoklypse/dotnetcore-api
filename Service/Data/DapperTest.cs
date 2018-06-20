using Configuration.Core.Interfaces;
using Dapper;
using Domain.Result;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class DapperTest
    {
        IDbConnection connection;

        public DapperTest(ISqlConfiguration config)
        {
            var connectionString = 
                $"Server={ config.Server };" +
                $"Initial Catalog={ config.InitialCatalog };" +
                $"Integrated Security={ config.IntegratedSecurity };" +
                $"MultipleActiveResultSets={ config.MultipleActiveResultSets };";

            this.connection = new SqlConnection(connectionString);
        }
        
        public IEnumerable<TestResult> Test(string value)
        {
            connection.Open();

            IEnumerable<TestResult> result = null;
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@name", value);

                result = connection.Query<TestResult>(
                    "UpsertTeam",
                    param: parameters,
                    commandType: CommandType.StoredProcedure) as IEnumerable<TestResult>;
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }

            return result;
        }
    }
}
