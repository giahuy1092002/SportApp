using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportApp_Business.Commands.Booking;

namespace SportApp_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookingController(IMediator mediator)
        {
            _mediator = mediator;   
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateBooking(CreateBookingCommand request,CancellationToken cancellationToken)
        {
            return Ok(await  _mediator.Send(request,cancellationToken));
        }
    }
}
