using MediatR;
using Microsoft.AspNetCore.Mvc;
using SportApp_Business.Commands.VoucherCommand;
using SportApp_Business.Queries.VoucherQuery;


namespace SportApp_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IMediator _mediator;   
        public VoucherController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateVoucher(CreateVoucherCommand command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command,cancellationToken));
        }
        [HttpPatch("[action]")]
        public async Task<IActionResult> UpdateVoucher(UpdateVoucherCommand command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteVoucher(DeleteVoucherCommand command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetVouchers([FromQuery]GetVouchers query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
    }
}
