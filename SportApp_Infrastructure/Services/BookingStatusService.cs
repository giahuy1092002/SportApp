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
    public class BookingStatusService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public BookingStatusService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<SportAppDbContext>();

                    var expiredBookings = await context.Booking
                        .Where(b => b.Status == BookingStatus.Pending && b.CreatedDate.AddMinutes(15) < DateTime.UtcNow)
                        .ToListAsync(stoppingToken);

                    foreach (var booking in expiredBookings)
                    {
                        booking.Status = BookingStatus.PaymentFailed;
                    }

                    await context.SaveChangesAsync(stoppingToken);
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
