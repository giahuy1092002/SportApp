using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SportApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Services
{
    public class UpdateBookingStatusService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public UpdateBookingStatusService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<SportAppDbContext>();
                    var expiredBookings = await dbContext.Booking
                        .Include(b=>b.Customer)
                            .ThenInclude(c=>c.User)
                        .Include(b=>b.SportField)
                        .Where(b => b.BookingDate <= DateTime.Now.AddDays(1) && (b.Status == BookingStatus.PaymentReceived|| b.Status==BookingStatus.Pending))
                        .ToListAsync();

                    foreach (var booking in expiredBookings)
                    {
                        var utcNow = DateTime.UtcNow;
                        var vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                        var vietnamTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, vietnamTimeZone);
                        booking.Status = BookingStatus.Completed;
                        var notification = new Notification
                        {
                            Title = "Đánh giá " + booking.SportField.Name,
                            Content = "Cảm ơn bạn đã sử dụng sân, vui lòng đánh giá để có trải nghiệm tốt hơn",
                            CreateAt = vietnamTime,
                            RelatedId = booking.SportFieldId,
                            RelatedType = "SportField",
                            EndPoint = booking.SportField.EndPoint,
                        };
                        dbContext.Notifications.Add(notification);
                        dbContext.SaveChanges();
                        var userNotify = new UserNotification
                        {
                            NotificationId = notification.Id,
                            UserId = booking.Customer.User.Id
                        };
                        dbContext.UserNotifications.Add(userNotify);
                        dbContext.SaveChanges();
                    }

                    if (expiredBookings.Any())
                    {
                        await dbContext.SaveChangesAsync();
                    }
                }
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
    }
}
