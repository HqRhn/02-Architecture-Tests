using MediatR;

namespace OrderManagement.Application.Interfaces
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
