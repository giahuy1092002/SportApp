using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.TimeSlotDtos;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.SportFieldQuery
{
    public class GetSchedulerQuery : IQuery<List<TimeSlotDto>>
    {
        public string EndPoint {  get; set; }
        public DateTime BookingDate { get; set; }
        public class GetSchedulerHandler : IQueryHandler<GetSchedulerQuery,List<TimeSlotDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly SportAppDbContext _context;
            public GetSchedulerHandler(IUnitOfWork unitOfWork,IMapper mapper,SportAppDbContext context)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
                _context = context;
            }

            public async Task<List<TimeSlotDto>> Handle(GetSchedulerQuery request, CancellationToken cancellationToken)
            {
                var sportField = await _context.SportField.Include(s=>s.TimeSlots)
                    .FirstOrDefaultAsync(s => s.EndPoint == request.EndPoint);
                var bookings = await _context.Booking
                    .Include(b=>b.SportField)
                    .Include(b=>b.TimeSlotBookeds)
                        .ThenInclude(t=>t.TimeSlot)
                    .Where(b=>b.BookingDate.Date == request.BookingDate.Date && b.SportField.EndPoint==request.EndPoint).ToListAsync();
                var timeSlots = _mapper.Map<List<TimeSlotDto>>(sportField.TimeSlots);
                foreach (var timeSlot in timeSlots)
                {
                    foreach (var booking in bookings)
                    {
                        foreach (var timeBooked in booking.TimeSlotBookeds)
                        {
                            if (timeBooked.TimeSlot.StartTime == timeSlot.StartTime)
                            {
                                timeSlot.Status = true;
                            }
                        }
                    }
                }
                return timeSlots;

            }
        }
    }
}
