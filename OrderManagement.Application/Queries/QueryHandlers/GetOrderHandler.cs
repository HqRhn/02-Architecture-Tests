using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;
using OrderManagement.Repository.Persistence.DBContext;
using OrderManagement.Repository.Persistence.Repositories;

namespace OrderManagement.Application.Queries.QueryHandlers
{
    public class GetOrderHandler : IRequestHandler<GetOrderByReferenceQuery, Order>
    {
        private readonly IOrderRepository _orderRepository;
        public GetOrderHandler(IOrderRepository orderRepository)       
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(GetOrderByReferenceQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrderByReference(request.OrderReference);
        }
    }
}
