using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportApp_Business.Commands.SportProductCommand;
using SportApp_Business.Queries.SportProductQuery;

namespace SportApp_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SportProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateSportProduct([FromForm] CreateSportProductCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddColor([FromForm] AddColorForSportProduct command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSportProducts([FromQuery]GetSportProducts query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query,cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSportProductDetail([FromQuery] GetSportProductDetail query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteSportProduct(DeleteSportProduct command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command,cancellationToken));
        }
    }
}
