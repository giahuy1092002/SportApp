using SportApp_Business.Common;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Model.Mail;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace SportApp_Business.Commands.UserCommand
{
    public class SendEmail : ICommand<bool>
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public class SendEmailHandler : ICommandHandler<SendEmail, bool>
        {
            private readonly MailService _mailService;
            private readonly SportAppDbContext _context;
            private readonly IUnitOfWork _unitOfWork;
            public SendEmailHandler(MailService mailService,SportAppDbContext context,IUnitOfWork unitOfWork)
            {
                _mailService = mailService;
                _context = context;
                _unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(SendEmail request, CancellationToken cancellationToken)
            {
                var utcNow = DateTime.UtcNow;
                var vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                var vietnamTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, vietnamTimeZone);
                var today = vietnamTime.Date;
                var bookings = await _context.Booking
                            .Include(b => b.Customer)
                                .ThenInclude(u => u.User)
                            .Include(b=>b.SportField)
                            .Where(booking => booking.BookingDate >= today && booking.BookingDate < today.AddDays(1))
                            .ToListAsync();
                foreach (var booking in bookings)
                {
                        var templatePath = "C:\\Users\\Gia Huy\\source\\repos\\SportApp\\SportApp_Infrastructure\\EmailBody\\EmailReminder.html";
                    var placeholders = new Dictionary<string, string>
                        {
                            { "UserName", booking.Customer.User.Email },
                            { "FieldName", booking.SportField.Name }, // Cập nhật thông tin sân nếu cần
                            { "BookingDate", booking.BookingDate.ToString("HH:mm dd/MM/yyyy") },
                            { "Address", booking.SportField.Address }
                        };
                    var model = new MailRequest
                        {
                            ToEmail = "huy.nguyen1092002@hcmut.edu.vn",
                            Subject = "Nhắc nhở đặt sân thể thao",
                            Body = $"Sân thể thao mà bạn đặt sẽ bắt đầu lúc {booking.BookingDate.ToString("MM/dd/yyyy HH:mm")}.",
                        };

                    await _mailService.SendEmailWithHtmlTemplate(model, templatePath, placeholders);
                }
                return await Task.FromResult(true);
            }
        }
    }
}
