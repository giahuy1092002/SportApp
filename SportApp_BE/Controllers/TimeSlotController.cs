using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportApp_Business.Commands.TimeSlotCommand;

namespace SportApp_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotController : ControllerBase
    {
        private IMediator _mediator;
        public TimeSlotController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteTimeSlot(DeleteTimeSlotCommand command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command,cancellationToken));   
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddTimeSlot(CreateTimeSlotCommand command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
