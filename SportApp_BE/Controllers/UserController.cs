using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using SportApp_Business.Commands.CartCommand;
using SportApp_Business.Commands.UserCommand;
using SportApp_Business.Dtos.UserDtos;
using SportApp_Business.Queries.CartQuery;
using SportApp_Business.Queries.UserQuery;
using System.Text;

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
        public async Task<IActionResult> AddRole(AddRoleCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command,cancellationToken));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(SignInCommand command,CancellationToken cancellationToken)
        {
            var nonCart = await _mediator.Send(new GetCart { BuyerId = Request.Cookies["buyerId"] }, cancellationToken);
            var userCart = await _mediator.Send(new GetCart { BuyerId = command.Email}, cancellationToken);
            if(nonCart!=null)
            {
                if (userCart != null) await _mediator.Send(new RemoveCart { CartId = userCart.Id });
                Response.Cookies.Delete("buyerId");
                await _mediator.Send(new UpdateCart { BuyerId=nonCart.BuyerId,Email=command.Email},cancellationToken);
            }    
            var user = await _mediator.Send(command, cancellationToken);
            return Ok(user);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        [HttpPatch("[action]")]
        public async Task<IActionResult> UpdateAvatar([FromForm] UpdateAvatarCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUser([FromQuery] GetUserQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> ConfirmEmail([FromQuery]GetEmailConfirmQuery query, CancellationToken cancellationToken)
        {
            var decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(query.EndcodedToken));
            query.EndcodedToken = decodedToken;
            await _mediator.Send(query, cancellationToken);
            return Redirect("http://localhost:3000");
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> ForgetPassword(ForgetPassWordCommand command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command,cancellationToken));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SendEmail(SendEmail command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
