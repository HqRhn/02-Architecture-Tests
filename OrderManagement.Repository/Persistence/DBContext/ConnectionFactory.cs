using Microsoft.Data.SqlClient;
using System.Data;


namespace OrderManagement.Repository.Persistence.DBContext
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;

        public ConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
            if (_connectionString == null)
                throw new ApplicationException("ConnectionString is not available.");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
