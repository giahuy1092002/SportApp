using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportApp_Business.Commands.BookingCommand;
using SportApp_Business.Commands.OwnerCommand;
using SportApp_Business.Queries.BookingQuery;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.PaymentModel;
using SportApp_Infrastructure.Services.Interfaces;

namespace SportApp_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IVnPayService _vnPayService;
        public BookingController(IMediator mediator,IVnPayService vnPayService)
        {
            _mediator = mediator;   
            _vnPayService = vnPayService;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateBooking(CreateBookingCommand request,CancellationToken cancellationToken)
        {
            var result = await  _mediator.Send(request,cancellationToken);
            if(result!=null)
            {
                if(request.IsPaymentOnline)
                {
                    var model = new PaymentInformationModel
                    {
                        BookingType = "Thanh toán online qua VNPay",
                        BookingDescription = "Thanh toán đặt sân",
                        Amount = request.TotalPrice,
                        BookingId = result.ToString(),
                        Name = "Thanh toán đặt sân"
                    };
                    var url = _vnPayService.CreatePaymentUrl(model, HttpContext);
                    return Ok(url);
                }    
            }
            return Ok("Tạo đơn đặt sân thành công");
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBookingByCustomer([FromQuery]GetBookingByCustomer query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query,cancellationToken));
        }
        [HttpPatch("[action]")]
        public async Task<IActionResult> UpdateBookingStatus(UpdateBookingStatus command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command,cancellationToken));
        }
        [Authorize(Roles="Owner")]
        [HttpPatch("[action]")]
        public async Task<IActionResult> RejectBooking(RejectBooking command,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
