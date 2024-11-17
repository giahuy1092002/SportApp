using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportApp_Business.Commands.SportCommand;
using SportApp_Business.Queries.SportQuery;
using System.Reflection.Metadata.Ecma335;

namespace SportApp_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SportController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateSport(CreateSportCommand command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command,cancellationToken));
        }
        [HttpPatch("[action]")]
        public async Task<IActionResult> UpdateSport(UpdateSportCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteSport(DeleteSportCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSports([FromQuery]GetSportsQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
    }
}
