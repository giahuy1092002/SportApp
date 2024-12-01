using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using SportApp_Business.Commands.OrderCommand;
using SportApp_Business.Queries.OrderQuery;
using SportApp_Infrastructure.Model.PaymentModel;

namespace SportApp_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));    
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrderByUser([FromQuery] GetByUser query, CancellationToken cancellationToken)
        {
            var orders = await _mediator.Send(query, cancellationToken);
            return Ok(orders);
        }
    }
}
