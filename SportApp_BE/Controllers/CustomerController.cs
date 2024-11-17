using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportApp_Business.Commands.CustomerCommand;
using SportApp_Business.Queries.CustomerQuery;

namespace SportApp_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCustomer([FromQuery]GetAllCustomerQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteCustomer(DeleteCustomer command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [HttpPatch("[action]")]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomer command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCustomerDetail([FromQuery] GetCustomer query,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
    }
}
