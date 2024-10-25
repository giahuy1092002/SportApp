using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Hubs;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Model.BookingModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportApp_Business.Commands.Booking
{
    public class CreateBookingCommand : ICommand<bool>
    {
        public string Name { get; set; }
        public long TotalPrice { get; set; }
        public Guid SportFieldId { get; set; }
        public Guid CustomerId { get; set; }
        public string? Note { get; set; }
        public Guid? SpecId { get; set; } = Guid.Empty;

        public List<Guid> TimeBookedIds { get; set; }
        public DateTime BookingDate { get; set; }
        public class CreateBookingHandler : ICommandHandler<CreateBookingCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IHubContext<GetSchedulerHub> _hubContext;
            private readonly SportAppDbContext _context;
            public CreateBookingHandler(IUnitOfWork unitOfWork, IHubContext<GetSchedulerHub> hubContext, SportAppDbContext context)
            {
                _unitOfWork = unitOfWork;
                _hubContext = hubContext;
                _context = context;
            }
            public async Task<bool> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
            {
                var executionStrategy = _context.Database.CreateExecutionStrategy();

                // Sử dụng execution strategy để thực hiện các thao tác trong một giao dịch
                await executionStrategy.ExecuteAsync(async () =>
                {
                    using (var transaction = await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable))
                    {
                        try
                        {
                            // Kiểm tra tính khả dụng của từng khung giờ
                            foreach (var id in request.TimeBookedIds)
                            {
                                var existingBooking = await _context.BookingTimeSlots
                                    .AnyAsync(bts => bts.TimeSlotId == id && bts.Booking.SportFieldId == request.SportFieldId);

                                if (existingBooking)
                                {
                                    throw new Exception($"Time slot {id} is already booked.");
                                }
                            }

                            // Tạo booking sau khi kiểm tra tính khả dụng
                            var createBooking = new CreateBookingModel
                            {
                                Name = request.Name,
                                TotalPrice = request.TotalPrice,
                                SportFieldId = request.SportFieldId,
                                CustomerId = request.CustomerId,
                                Note = request.Note,
                                SpecId = request.SpecId != Guid.Empty ? request.SpecId : Guid.Empty
                            };

                            var booking = await _unitOfWork.Bookings.Create(createBooking);

                            // Thêm các khung giờ đã đặt vào BookingTimeSlot
                            foreach (var id in request.TimeBookedIds)
                            {
                                var bookedTimeSlot = new BookingTimeSlot
                                {
                                    BookingId = booking.Id,
                                    TimeSlotId = id
                                };
                                await _unitOfWork.BookingTimeSlots.Add(bookedTimeSlot);
                            }

                            await _unitOfWork.SaveChangesAsync();

                            // Commit transaction
                            await transaction.CommitAsync();
                        }
                        catch (Exception)
                        {
                            // Rollback transaction nếu có lỗi
                            await transaction.RollbackAsync();
                            throw; // Ném lại ngoại lệ để được xử lý bên ngoài
                        }
                    }
                });

                return true;
            }

        }
    }
        public class TimeBooked
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
