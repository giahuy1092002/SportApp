using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportApp_Business.Commands.OwnerCommand;
using SportApp_Business.Queries.OwnerQuery;
using SportApp_Business.Queries.SportFieldQuery;

namespace SportApp_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OwnerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetFields([FromQuery]GetFieldsQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllOwner([FromQuery]GetOwnersQuery query,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query,cancellationToken));   
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteOwner(DeleteOwner command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
