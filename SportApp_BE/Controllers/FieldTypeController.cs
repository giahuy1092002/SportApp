using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportApp_Business.Commands.FieldType;

namespace SportApp_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FieldTypeController (IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateFieldTypeCommand request,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request,cancellationToken));
        }
    }
}
