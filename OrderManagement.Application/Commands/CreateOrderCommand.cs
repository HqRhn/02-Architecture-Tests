using MediatR;
using OrderManagement.Domain.Entities;


namespace OrderManagement.Application.Commands
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public string OrderReference { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
