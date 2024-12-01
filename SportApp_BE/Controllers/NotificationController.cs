using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportApp_Business.Commands.NotificationCommand;
using SportApp_Business.Queries.NotifyQuery;

namespace SportApp_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateNotificationCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command,cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByUser([FromQuery]GetNotifyByUser query,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query,cancellationToken));  
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCountNotify([FromQuery]GetCountNotify query,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query,cancellationToken));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SendNotify(SendNotify command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
