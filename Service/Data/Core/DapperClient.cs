using Configuration.Core.Interfaces;
using Dapper;
using Data.Core.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data.Core
{
    public class DapperClient : IDapperClient
    {
        private readonly IDbConnection connection;

        private readonly ILogger logger;

        public DapperClient(
            ISqlConfiguration configParam,
            ILogger loggerParam)
        {
            var config = configParam ?? throw new ArgumentNullException(nameof(configParam));
            this.logger = loggerParam ?? throw new ArgumentNullException(nameof(loggerParam));

            var connectionString =
                $"Server={ config.Server };" +
                $"Initial Catalog={ config.InitialCatalog };" +
                $"Integrated Security={ config.IntegratedSecurity };" +
                $"MultipleActiveResultSets={ config.MultipleActiveResultSets };";

            this.logger.Verbose($"Setting up DB Connection with connection string: { connectionString }");
            this.connection = new SqlConnection(connectionString);
        }

        public IEnumerable<ResultType> ExecuteStoredProcedure<ResultType>(string storedProcedureName)
        {
            connection.Open();

            IEnumerable<ResultType> result = null;
            try
            {
                result = connection.Query<ResultType>(
                    storedProcedureName,
                    commandType: CommandType.StoredProcedure) as IEnumerable<ResultType>;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"Error occurred executing stored procedure: ");
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        public IEnumerable<ResultType> ExecuteStoredProcedure<ResultType>(string storedProcedureName, DynamicParameters parameters)
        {
            connection.Open();

            IEnumerable<ResultType> result = null;
            try
            {
                result = connection.Query<ResultType>(
                    storedProcedureName,
                    param: parameters,
                    commandType: CommandType.StoredProcedure) as IEnumerable<ResultType>;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"Error occurred executing stored procedure: ");
            }
            finally
            {
                connection.Close();
            }

            return result;
        }
    }
}
