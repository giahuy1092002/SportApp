using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportApp_Business.Queries.BookingQuery;
using SportApp_Business.Queries.OwnerQuery;
using SportApp_Business.Queries.SportFieldQuery;
using SportApp_Business.Queries.SportProductQuery;

namespace SportApp_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerDashboardController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OwnerDashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCustomers([FromQuery] GetCustomers query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSportFields([FromQuery] GetSportFieldsByOwner query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetTotalRevenue([FromQuery]GetTotalRevenue query,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBookingByOwner([FromQuery]GetBookingByOwner query,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetRevenueByYear([FromQuery] GetRevenueByYear query,CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(query, cancellation));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetRevenueCurrentMonth([FromQuery]GetRevenueCurrentMonth query,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetRevenueToday([FromQuery] GetRevenueToday query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
    }
}
