using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SportApp_Infrastructure.Model.Mail;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure.Services.Interfaces;

namespace SportApp_Infrastructure.Services
{
    public class NotifyReminderService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly MailService _mailService;

        public NotifyReminderService(IServiceScopeFactory scopeFactory, MailService mailService)
        {
            _scopeFactory = scopeFactory;
            _mailService = mailService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await SendNotifications();
                await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
            }
        }

        private async Task SendNotifications()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<SportAppDbContext>();
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var utcNow = DateTime.UtcNow;
                var vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                var vietnamTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, vietnamTimeZone);
                var today = vietnamTime.Date;
                var bookings = await context.Booking
                            .Include(b => b.Customer)
                                .ThenInclude(u => u.User)
                             .Include(b=>b.SportField)
                            .Where(booking => booking.BookingDate >= today && booking.BookingDate < today.AddDays(1) && booking.IsRemind==false)
                            .ToListAsync();
                foreach (var booking in bookings)
                {
                    var reminderTime = booking.BookingDate.AddHours(-4);
                    if (vietnamTime >= reminderTime)
                    {
                        var templatePath = "C:\\Users\\Gia Huy\\source\\repos\\SportApp\\SportApp_Infrastructure\\EmailBody\\EmailReminder.html";
                        var placeholders = new Dictionary<string, string>
                        {
                            { "UserName", booking.Customer.User.Email},
                            { "FieldName", booking.SportField.Name },
                            { "BookingDate", "Khung giờ: " + booking.TimeFrameBooked + " ngày " + booking.BookingDate.ToString("dd/MM/yyyy") },
                            { "Address", booking.SportField.Address }
                        };
                        var request = new MailRequest
                        {
                            ToEmail = "huy.nguyen1092002@hcmut.edu.vn",
                            Subject = "Nhắc nhở đặt sân thể thao",
                            Body = $"Sân thể thao mà bạn đặt sẽ diễn ra vào các khung giờ {booking.TimeFrameBooked}. ngày {booking.BookingDate:HH:mm}",
                        };
                        await _mailService.SendEmailWithHtmlTemplate(request, templatePath, placeholders);
                        booking.IsRemind = true;
                        context.Booking.Update(booking);
                        await unitOfWork.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
