using MediatR;
using OrderManagement.Domain.Entities;
using OrderManagement.Repository.Persistence.Repositories;

namespace OrderManagement.Application.Commands.CommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newOrder = new Order {  OrderReference = request.OrderReference, CreatedOn = request.CreatedOn};
            _orderRepository.AddOrder(newOrder);
            return newOrder;
        }
    }
}
