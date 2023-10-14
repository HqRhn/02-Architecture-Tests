using OrderManagement.Domain.Entities;

namespace OrderManagement.Repository.Persistence.Repositories
{
    public interface IOrderRepository
    {
        public void AddOrder(Order newOrder);

        Task<Order> GetOrderByReference(string reference);
    }
}
