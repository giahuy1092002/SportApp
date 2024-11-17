using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Repositories;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.NotificationCommand
{
    public class SendNotify : ICommand<bool>
    {
        public class SendNotifyHandler : ICommandHandler<SendNotify,bool>
        {
            private readonly SportAppDbContext _context;
            private readonly IUnitOfWork _unitOfWork;
            public SendNotifyHandler(SportAppDbContext context, IUnitOfWork unitOfWork)
            {
                _context = context;
                _unitOfWork = unitOfWork;   
            }

            public async Task<bool> Handle(SendNotify request, CancellationToken cancellationToken)
            {
                var today = DateTime.Today;
                var bookings = await _context.Booking
                            .Include(b => b.Customer)
                                .ThenInclude(u => u.User)
                            .Where(booking => booking.BookingDate >= today && booking.BookingDate < today.AddDays(1))
                            .ToListAsync();
                foreach (var booking in bookings)
                {
                        Console.WriteLine($"BookingDate: {booking.BookingDate.Day}, CurrentDate: {DateTime.Now.Day}");
                        var notification = new Notification
                        {
                            Title = "Đánh giá sân thể thao",
                            Content = "Cảm ơn bạn đã sử dụng sân, vui lòng đánh giá để có trải nghiệm tốt nhất cho lần sau.",
                        };
                        _context.Notifications.Add(notification);
                        var userNotify = new UserNotification
                        {
                            NotificationId = notification.Id,
                            UserId = booking.Customer.User.Id
                        };
                        _context.UserNotifications.Add(userNotify);
                        await _unitOfWork.SaveChangesAsync();       
                }
                return true;
            }
        }
    }
}
