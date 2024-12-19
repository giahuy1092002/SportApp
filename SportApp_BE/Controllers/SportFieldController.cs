using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportApp_Business.Commands.SportFieldCommand;
using SportApp_Business.Commands.SportProductCommand;
using SportApp_Business.Commands.UserCommand;
using SportApp_Business.Queries.SportFieldQuery;
using SportApp_Infrastructure.Services;

namespace SportApp_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportFieldController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly GeoCodeService _geoCodeService;
        public SportFieldController(IMediator mediator, GeoCodeService geoCodeService)
        {
            _mediator = mediator;
            _geoCodeService = geoCodeService;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateSportField([FromForm] CreateSportFieldCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetScheduler([FromQuery] GetSchedulerQuery command, CancellationToken cancellationToken)
        {
            return Ok(await  _mediator.Send(command, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSportField([FromQuery]GetSportFieldQuery command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteSportField(DeleteSportFieldCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddRating(AddRatingSportFieldCommand command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command,cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSportFields([FromQuery]GetSportFieldsQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSportList([FromQuery]GetSportListQuery query,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetGeocode([FromQuery]GetGeoCodeQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query,cancellationToken));
        }
        [HttpPatch("[action]")]
        public async Task<IActionResult> UpdateSportField([FromBody]UpdateSportFieldCommand command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSportFieldUpdate([FromQuery]GetSportFieldUpdate query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddVoucher([FromBody]AddVoucher command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteSportFieldVoucher([FromBody]DeleteSportFieldVoucher command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command,cancellationToken));
        }
        [HttpPatch("[action]")]
        public async Task<IActionResult> HandleCreateSportField([FromBody]HandleCreateSportField command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
