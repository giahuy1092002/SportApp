using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportApp_Business.Commands.ColorCommand;
using SportApp_Business.Queries.ColorQuery;

namespace SportApp_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ColorController(IMediator mediator)
        {
            _mediator = mediator;   
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateColor(CreateColor command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetColors([FromQuery]GetColors query,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query,cancellationToken));
        }
    }
}
