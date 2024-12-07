using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.OwnerCommand
{
    public class RejectBooking : ICommand<bool>
    {
        public Guid BookingId { get; set; }
        public string Reason { get; set; }
        public class RejectBookingHandler : ICommandHandler<RejectBooking,bool>
        {
            private readonly SportAppDbContext _context;
            public RejectBookingHandler(SportAppDbContext context)
            {
                _context = context;
            }
            public async Task<bool> Handle(RejectBooking request, CancellationToken cancellationToken)
            {
                var booking = await _context.Booking.FirstOrDefaultAsync(b=>b.Id== request.BookingId);  
                if(booking.Status == BookingStatus.Pending || booking.Status == BookingStatus.PaymentReceived)
                {
                    booking.Status = BookingStatus.Rejected;
                    booking.IsRejectByOwner = true;
                    _context.Booking.Update(booking);
                    _context.SaveChanges();
                }
                else
                {
                    throw new AppException("Bạn không thể hủy đơn đặt sân này");
                }
                return await Task.FromResult(true);

            }
        }
    }
}
