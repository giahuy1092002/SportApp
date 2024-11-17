using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportApp_Business.Commands.SportCommand;
using SportApp_Business.Commands.SportTeamCommand;
using SportApp_Business.Queries.SportTeamQuery;

namespace SportApp_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportTeamController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SportTeamController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateSportTeam(CreateSportTeamCommand command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command,cancellationToken));
        }
        [HttpPatch("[action]")]
        public async Task<IActionResult> UpdateSportTeam(UpdateSportTeamCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));    
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteSportTeam(DeleteSportTeamCommand command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSportTeams([FromQuery]GetSportTeams query,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByCustomer([FromQuery]GetSportTeamByCustomer query,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query,cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSportTeamDetail([FromQuery]GetSportTeamDetail query,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> JoinSportTeam(JoinSportTeamCommand command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> HandleRequest(HandleJoinRequest command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteMember(DeleteMemberCommand command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
