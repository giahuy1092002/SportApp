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
    public class UpdateBookingStatus : ICommand<bool>
    {
        public Guid BookingId { get; set; }
        public class UpdateBookingStatusHandler : ICommandHandler<UpdateBookingStatus,bool>
        {
            private readonly SportAppDbContext _context;
            public UpdateBookingStatusHandler(SportAppDbContext context)
            {
                _context = context;
            }
            public async Task<bool> Handle(UpdateBookingStatus request, CancellationToken cancellationToken)
            {
                try
                {
                    var booking = await _context.Booking.FirstOrDefaultAsync(b => b.Id == request.BookingId);
                    if (booking == null) throw new AppException("Đơn đặt sân không tồn tại");
                    if (booking.Status == BookingStatus.Pending)
                    {
                        booking.Status = BookingStatus.PaymentReceived;
                    }
                    _context.Booking.Update(booking);
                    _context.SaveChanges();
                    return await Task.FromResult(true);
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
