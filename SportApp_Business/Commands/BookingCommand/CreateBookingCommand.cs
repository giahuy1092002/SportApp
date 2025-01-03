﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Hubs;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Model.BookingModel;
using SportApp_Infrastructure.Model.Mail;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure.Services;
using SportApp_Infrastructure.Services.Interfaces;
using System.Net.Sockets;

namespace SportApp_Business.Commands.BookingCommand
{
    public class CreateBookingCommand : ICommand<Guid>
    {
        public long TotalPrice { get; set; }
        public Guid SportFieldId { get; set; }
        public Guid CustomerId { get; set; }
        public string? Note { get; set; }
        public List<Guid> TimeBookedIds { get; set; }
        public DateTime BookingDate { get; set; }
        public Guid? VoucherId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
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
                    using (var transaction = await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.RepeatableRead))
                    {
                        var sportField = await _context.SportField.FirstOrDefaultAsync(s => s.Id == request.SportFieldId);
                        foreach (var id in request.TimeBookedIds)
                        {
                            var existingBooking = await _context.BookingTimeSlots
                                .Include(b => b.Booking)
                                .AnyAsync(bts => bts.TimeSlotId == id && bts.Booking.SportFieldId == request.SportFieldId && bts.Booking.BookingDate.Date == request.BookingDate.Date);

                            if (existingBooking)
                            {
                                var timeslot = await _context.TimeSlot.FirstOrDefaultAsync(t => t.Id == id);
                                throw new AppException($"Khung giờ {timeslot.StartTime}-{timeslot.EndTime} đã được đặt, vui lòng chọn khung giờ khác.");
                            }
                        }
                        var createBooking = new CreateBookingModel
                        {
                            Name = "Đặt sân: " + sportField.Name,
                            TotalPrice = request.TotalPrice,
                            SportFieldId = request.SportFieldId,
                            CustomerId = request.CustomerId,
                            Note = request.Note,
                            BookingDate = request.BookingDate,
                            FullName = request.FullName,
                            Email = request.Email,
                            PhoneNumber = request.PhoneNumber
                        };
                        var booking = await _unitOfWork.Bookings.Create(createBooking);
                        for (int i = 0; i < request.TimeBookedIds.Count(); i++)
                        {
                            var timeslot = await _context.TimeSlot.FirstOrDefaultAsync(t => t.Id == request.TimeBookedIds[i]);
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
                        // Voucher 
                        if (request.VoucherId != null)
                        {
                            var voucher = await _context.SportFieldVouchers.FirstOrDefaultAsync(v => v.VoucherId == request.VoucherId && v.SportFieldId == request.SportFieldId);
                            if (voucher == null) throw new AppException("Voucher không tồn tại");
                            voucher.Quantity -= 1;
                            _context.SportFieldVouchers.Update(voucher);
                        }
                        // Send notify
                        var notification = new Notification
                        {
                            Title = $"Đặt sân thành công: {sportField.Name}",
                            Content = "Bạn đã đặt sân thành công, vui lòng thanh toán để hoàn thành thủ tục",
                            CreateAt = DateTime.Now,
                            RelatedId = request.SportFieldId,
                            RelatedType = NotifyType.SportField.ToString(),
                            EndPoint = sportField.EndPoint
                        };
                        _context.Notifications.Add(notification);
                        await _unitOfWork.SaveChangesAsync();
                        var customer = await _context.Customer
                            .Include(c => c.User)
                            .FirstOrDefaultAsync(c => c.Id == request.CustomerId);
                        var userNotify = new UserNotification
                        {
                            NotificationId = notification.Id,
                            UserId = customer.User.Id
                        };
                        _context.UserNotifications.Add(userNotify);
                        await _unitOfWork.SaveChangesAsync();
                        await transaction.CommitAsync();
                        return booking.Id;
                    }
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
