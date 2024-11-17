using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Services
{
    public class NotifyRatingService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public NotifyRatingService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var utcNow = DateTime.UtcNow;
                var vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                var vietnamTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, vietnamTimeZone);
                var nextRunTime = vietnamTime.Date.AddHours(23).AddMinutes(27);
                Console.WriteLine(nextRunTime.ToString());
                if (vietnamTime > nextRunTime)
                {
                    nextRunTime = vietnamTime.Date.AddDays(1).AddHours(23).AddMinutes(27);
                }
                var delay = nextRunTime - vietnamTime;
               
                if (delay > TimeSpan.Zero)
                {
                    await Task.Delay(delay, stoppingToken);
                    await SendNotifications();
                }
            }
        }

        private async Task SendNotifications()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<SportAppDbContext>();
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var today = DateTime.Today;
                var bookings = await context.Booking
                            .Include(b => b.Customer)
                                .ThenInclude(u => u.User)
                            .Include(b=>b.SportField)
                            .Where(booking => booking.BookingDate >= today && booking.BookingDate < today.AddDays(1))
                            .ToListAsync();
                foreach (var booking in bookings)
                {
                    Console.WriteLine("ABC");
                    var utcNow = DateTime.UtcNow;
                    var vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                    var vietnamTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, vietnamTimeZone);
                    var notification = new Notification
                    {
                        Title = "Đánh giá sân thể thao",
                        Content = "Cảm ơn bạn đã sử dụng sân, vui lòng đánh giá để có trải nghiệm tốt nhất cho lần sau.",
                        CreateAt = vietnamTime,
                        RelatedId = booking.SportFieldId,
                        RelatedType = "SportField", 
                        EndPoint = booking.SportField.EndPoint,
                    };
                    context.Notifications.Add(notification);
                    await unitOfWork.SaveChangesAsync();
                    var userNotify = new UserNotification
                    {
                        NotificationId = notification.Id,
                        UserId = booking.Customer.User.Id
                    };
                    context.UserNotifications.Add(userNotify);
                    await unitOfWork.SaveChangesAsync();
                }
            }
        }
    }
}
