using MediatR;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Queries
{
    public class GetOrderByReferenceQuery : IRequest<Order>
    {
        public string OrderReference { get; set; }
    }
}
