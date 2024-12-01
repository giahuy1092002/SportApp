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
    public class UpdateBookingCommnad : ICommand<bool>
    {
        public Guid BookingId { get; set; }
        public class UpdateBookingHandler : ICommandHandler<UpdateBookingCommnad,bool>
        {
            private readonly SportAppDbContext _context;
            public UpdateBookingHandler(SportAppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(UpdateBookingCommnad request, CancellationToken cancellationToken)
            {
                var booking = await _context.Booking.FirstOrDefaultAsync(b=>b.Id==request.BookingId);
                booking.Status = BookingStatus.PaymentReceived;
                _context.Booking.Update(booking);
                await _context.SaveChangesAsync();
                return await Task.FromResult(true); 
            }
        }
    }
}
