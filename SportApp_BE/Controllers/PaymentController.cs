using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportApp_Business.Commands.BookingCommand;
using SportApp_Business.Commands.OrderCommand;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure.Services.Interfaces;

namespace SportApp_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IVnPayService _vnPayService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public PaymentController(IVnPayService vnPayService, IUnitOfWork unitOfWork,IMediator mediator)
        {
            _vnPayService = vnPayService;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> PaymentCallback(CancellationToken cancellationToken)
        {
            var response = _vnPayService.PaymentExecute(Request.Query);
            string id = Request.Query["vnp_TxnRef"];
            if(response.BookingDescription.Contains("Thanh toán đặt sân"))
            {
                var command = new UpdateBookingCommnad
                {
                    BookingId = Guid.Parse(id)
                };
                await _mediator.Send(command, cancellationToken);
                Response.Cookies.Append("PaymentStatus", response.Success ? "success" : "failure", new CookieOptions
                {
                    Domain = "https://localhost:7274",
                    HttpOnly = false,
                    SameSite = SameSiteMode.None,
                    Secure = true,
                    Expires = DateTimeOffset.UtcNow.AddMinutes(5),
                    IsEssential = true
                });
            }    
            else if(response.BookingDescription.Contains("Thanh toán đơn hàng"))
            {
                var command = new UpdateOrderCommand
                {
                    OrderId = Guid.Parse(id)
                };
                await _mediator.Send(command, cancellationToken);
                Response.Cookies.Append("PaymentStatus", response.Success ? "success" : "failure", new CookieOptions
                {
                    Domain = "https://localhost:7274",
                    HttpOnly = false,
                    SameSite = SameSiteMode.None,
                    Secure = true,
                    Expires = DateTimeOffset.UtcNow.AddMinutes(5),
                    IsEssential = true
                });
            }    
            return Redirect($"http://localhost:3000/payment");
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetStatusPayment(CancellationToken cancellationToken)
        {
            var response = _vnPayService.PaymentExecute(Request.Query);
            string bookingId = Request.Query["vnp_TxnRef"];
            var command = new UpdateBookingCommnad
            {
                BookingId = Guid.Parse(bookingId)
            };
            await _mediator.Send(command, cancellationToken);
            return Redirect($"http://localhost:3000/user/order?status={response.Success}");
        }
    }
}
