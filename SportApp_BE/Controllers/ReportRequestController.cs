using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportApp_Business.Commands.ReportRequestCommand;
using SportApp_Business.Queries.ReportRequestQuery;

namespace SportApp_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportRequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReportRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateRequest command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command,cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery]GetReportRequests query,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query,cancellationToken));
        }
    }
}
