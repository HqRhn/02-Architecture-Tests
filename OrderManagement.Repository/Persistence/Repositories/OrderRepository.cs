using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;
using OrderManagement.Repository.Persistence.DBContext;

namespace OrderManagement.Repository.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public OrderRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddOrder(Order newOrder)
        {
            _dbContext.Set<Order>().Add(newOrder);
            _dbContext.SaveChanges();
        }

        public Task<Order> GetOrderByReference(string reference)
        {
            var order = _dbContext.Set<Order>().Where(order => order.OrderReference == reference).FirstOrDefaultAsync();
            return order;
        }
    }
}
