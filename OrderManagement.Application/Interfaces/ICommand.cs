using MediatR;

namespace OrderManagement.Application.Interfaces
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
