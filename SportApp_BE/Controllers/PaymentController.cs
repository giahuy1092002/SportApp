using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Commands.BookingCommand;
using SportApp_Business.Commands.OrderCommand;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Model.Mail;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure.Services;
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
        private readonly SportAppDbContext _context;
        private readonly MailService _mailService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PaymentController(IVnPayService vnPayService, IUnitOfWork unitOfWork,IMediator mediator,SportAppDbContext context,
            MailService mailService,IWebHostEnvironment webHostEnvironment)
        {
            _vnPayService = vnPayService;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _context = context;
            _mailService = mailService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> PaymentCallback(CancellationToken cancellationToken)
        {
            var response = _vnPayService.PaymentExecute(Request.Query);
            string id = Request.Query["vnp_TxnRef"];
            var paymentStatus = "failure";
            if(response.BookingDescription.Contains("Thanh toán đặt sân"))
            {
                var command = new UpdateBookingCommnad
                {
                    BookingId = Guid.Parse(id)
                };
                await _mediator.Send(command, cancellationToken);
                paymentStatus = response.Success ? "success" : "failure";
                if (response.Success)
                {
                    var booking = await _context.Booking
                        .Include(b=>b.SportField)
                        .Include(b => b.Customer)
                        .ThenInclude(c => c.User)
                        .FirstOrDefaultAsync(b => b.Id == Guid.Parse(id), cancellationToken);

                    if (booking != null)
                    {
                        string wwwrootPath = _webHostEnvironment.WebRootPath;
                        string bodyContentPath = Path.Combine(wwwrootPath, "BodyContent");
                        string filePath = Path.Combine(bodyContentPath, "EmailBooking.html");
                        var placeholders = new Dictionary<string, string>
                        {
                            { "UserName", booking.Email},
                            { "FieldName", booking.SportField.Name },
                            { "BookingDate", booking.TimeFrameBooked + " ngày " + booking.BookingDate.ToString("dd/MM/yyyy") },
                            { "Address", booking.SportField.Address },
                            { "Price",booking.TotalPrice.ToString()+"đ" }
                        };
                        var mailRequest = new MailRequest
                        {
                            ToEmail = booking.Email,
                            Subject = "Thông báo đặt sân thể thao",
                            Body = $"Sân thể thao mà bạn đặt sẽ diễn ra vào các khung giờ {booking.TimeFrameBooked}. ngày {booking.BookingDate:HH:mm}",
                        };
                        await _mailService.SendEmailWithHtmlTemplate(mailRequest, filePath, placeholders);
                    }
                }
            }    
            else if(response.BookingDescription.Contains("Thanh toán đơn hàng"))
            {
                var command = new UpdateOrderCommand
                {
                    OrderId = Guid.Parse(id)
                };
                await _mediator.Send(command, cancellationToken);
                paymentStatus = response.Success ? "success" : "failure";
            }    
            return Redirect($"http://localhost:3000/payment?status={paymentStatus}");
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
