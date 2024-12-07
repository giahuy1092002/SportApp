using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.BookingCommand
{
    public class RejectBookingByCustomer : ICommand<bool>
    {
        public Guid BookingId { get; set; }
        public string Reason { get; set; }
        public class RejectBookingByCustomerHandler : ICommandHandler<RejectBookingByCustomer,bool>
        {
            private readonly SportAppDbContext _context;
            public RejectBookingByCustomerHandler(SportAppDbContext context)
            {
                _context = context;
            }
            public async Task<bool> Handle(RejectBookingByCustomer request, CancellationToken cancellationToken)
            {
                var booking = await _context.Booking.FirstOrDefaultAsync(b=>b.Id== request.BookingId);
                if (booking == null) throw new AppException("Đơn đặt sân không tồn tại");
                if (DateTime.Now.Date.AddDays(2) <= booking.BookingDate)
                {
                    booking.Status = BookingStatus.Rejected;
                    booking.Reason = request.Reason;
                    _context.Booking.Update(booking);
                    _context.SaveChanges();
                    return await Task.FromResult(true);
                }
                else if (DateTime.Now.Date.AddDays(1) <= booking.BookingDate)
                {
                    booking.Status = BookingStatus.Rejected;
                    booking.Reason = request.Reason;
                    booking.IsRight = true;
                    _context.Booking.Update(booking);
                    _context.SaveChanges();
                    return await Task.FromResult(true);
                }
                else throw new AppException("Bạn không thể hủy đơn đặt sân, vì đơn đặt sân sẽ diễn ra vào ngày hôm nay");
            }
        }
    }
}
