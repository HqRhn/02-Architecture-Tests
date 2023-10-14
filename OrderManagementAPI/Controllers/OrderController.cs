using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Commands;
using OrderManagement.Application.Queries;
using OrderManagement.Domain.Entities;

namespace OrderManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetOrderByReference")]
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> GetOrderByReference([FromQuery]  GetOrderByReferenceQuery request)
        {
            var order = await _mediator.Send(request);
            return Ok(order);
        }

        [HttpPost("CreateOrder")]
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> CreateOrder([FromBody]  CreateOrderCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}