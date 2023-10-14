using System.Data;


namespace OrderManagement.Repository.Persistence.DBContext
{
    public interface IConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
