using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportApp_Business.Commands.UserCommand;
using SportApp_Business.Dtos.UserDtos;

namespace SportApp_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SignUp(SignUpCommand command,CancellationToken cancellationToken)
        {
            var result = await  _mediator.Send(command,cancellationToken);
            if(result)
            {
                return Ok(await _mediator.Send(new AddUserToRoleCommand { Email = command.Email, Role = "Customer" },cancellationToken));
            }
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser(CreateUserCommand command,CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            if(result.Succeeded)
            {
                return Ok(await _mediator.Send(new AddUserToRoleCommand { Email = command.Email,Role=command.Role }));
            }
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(SignInCommand command,CancellationToken cancellationToken)
        {
            var user = await _mediator.Send(command, cancellationToken);
            return Ok(user);
        }
    }
}
