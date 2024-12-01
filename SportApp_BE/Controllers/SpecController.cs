using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportApp_Business.Commands.SpecCommand;
using SportApp_Business.Commands.UserCommand;
using SportApp_Business.Queries.SpecQuery;

namespace SportApp_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SpecController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateSpec(CreateSpecCommand request, CancellationToken cancellationToken)
        {
            var createUserCommand = new CreateUserCommand
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword,
                Avatar = request.Avatar,
                Gender = request.Gender,
                Location = request.Location,
                DateOfBirth = request.DateOfBirth,
                Role = "Spec",
            };
            var result = await _mediator.Send(createUserCommand, cancellationToken);
            if (result.Succeeded)
            {
                return Ok(await _mediator.Send(request, cancellationToken));
            }
            return BadRequest();
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllSpec([FromQuery]GetSpecsQuery query,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));  
        }
    }
}
