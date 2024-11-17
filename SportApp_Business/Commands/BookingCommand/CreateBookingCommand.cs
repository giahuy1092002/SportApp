using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Hubs;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Model.BookingModel;
using SportApp_Infrastructure.Model.PaymentModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportApp_Business.Commands.BookingCommand
{
    public class CreateBookingCommand : ICommand<Guid>
    {
        public string Name { get; set; }
        public long TotalPrice { get; set; }
        public Guid SportFieldId { get; set; }
        public Guid CustomerId { get; set; }
        public string? Note { get; set; }
        public List<Guid> TimeBookedIds { get; set; }
        public DateTime BookingDate { get; set; }
        public class CreateBookingHandler : ICommandHandler<CreateBookingCommand, Guid>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IHubContext<GetSchedulerHub> _hubContext;
            private readonly SportAppDbContext _context;
            private readonly IVnPayService _vnPayService;
            private readonly IHttpContextAccessor _httpContextAccessor;
            public CreateBookingHandler(IUnitOfWork unitOfWork, IHubContext<GetSchedulerHub> hubContext, SportAppDbContext context
                ,IVnPayService vnPayService,IHttpContextAccessor httpContextAccessor)
            {
                _unitOfWork = unitOfWork;
                _hubContext = hubContext;
                _context = context;
                _vnPayService = vnPayService;
                _httpContextAccessor = httpContextAccessor;
            }
            public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    foreach (var id in request.TimeBookedIds)
                    {
                        var existingBooking = await _context.BookingTimeSlots
                            .Include(b=>b.Booking)
                            .AnyAsync(bts => bts.TimeSlotId == id && bts.Booking.SportFieldId == request.SportFieldId && bts.Booking.BookingDate.Date==request.BookingDate.Date);

                        if (existingBooking)
                        {
                            throw new Exception($"Time slot {id} is already booked.");
                        }
                    }
                    var createBooking = new CreateBookingModel
                    {
                        Name = request.Name,
                        TotalPrice = request.TotalPrice,
                        SportFieldId = request.SportFieldId,
                        CustomerId = request.CustomerId,
                        Note = request.Note,
                        BookingDate = request.BookingDate,
                    };

                    var booking = await _unitOfWork.Bookings.Create(createBooking);
                    for (int i=0;i<request.TimeBookedIds.Count();i++)
                    {
                        var timeslot = await _context.TimeSlot.FirstOrDefaultAsync(t=>t.Id== request.TimeBookedIds[i]);
                        if (i != request.TimeBookedIds.Count() - 1) booking.TimeFrameBooked = booking.TimeFrameBooked + $"{timeslot.StartTime}-{timeslot.EndTime}" + ";";
                        else booking.TimeFrameBooked = booking.TimeFrameBooked + $"{timeslot.StartTime}-{timeslot.EndTime}";
                        var bookedTimeSlot = new BookingTimeSlot
                        {
                            BookingId = booking.Id,
                            TimeSlotId = request.TimeBookedIds[i]
                        };
                        await _unitOfWork.BookingTimeSlots.Add(bookedTimeSlot);
                    }

                    await _unitOfWork.SaveChangesAsync();
                    foreach (var timeSlotId in request.TimeBookedIds)
                    {
                        await _hubContext.Clients.All.SendAsync("GetScheduler", request.SportFieldId, timeSlotId);
                    }
                    var model = new PaymentInformationModel
                    {
                        BookingType = "Booking SportField",
                        BookingDescription = "Thanh toán đặt sân",
                        Amount = request.TotalPrice,
                        BookingId = booking.Id.ToString(),
                        Name = "Thanh toán đặt sân"
                    };
                    var url = _vnPayService.CreatePaymentUrl(model, _httpContextAccessor.HttpContext);
                    return booking.Id;
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }
    }
        public class TimeBooked
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
