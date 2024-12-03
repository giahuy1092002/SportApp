using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportApp_Business.Queries.OrderQuery;
using SportApp_Business.Queries.SportProductQuery;

namespace SportApp_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDashboardController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdminDashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrders([FromQuery]GetOrders query,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSportProductCount([FromQuery] GetSportProductCount query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetTotalRevenue([FromQuery]GetTotalOrderRevenue query,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetRevenueByYear([FromQuery] GetRevenueByYear query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetRevenueToday([FromQuery] GetRevenueToday query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetRevenueCurrentMonth([FromQuery] GetRevenueCurrontMonth query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
    }
}
