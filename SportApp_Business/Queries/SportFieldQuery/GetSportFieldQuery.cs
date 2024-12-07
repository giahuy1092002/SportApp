using AutoMapper;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Dtos.SportFieldDtos;
using SportApp_Business.Dtos.RatingDtos;

namespace SportApp_Business.Queries.SportFieldQuery
{
    public class GetSportFieldQuery : IQuery<SportFieldDto>
    {
        public string EndPoint { get; set; }
        public class GetSportFieldHanlder : IQueryHandler<GetSportFieldQuery, SportFieldDto>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly SportAppDbContext _context;
            public GetSportFieldHanlder(IMapper mapper, IUnitOfWork unitOfWork, SportAppDbContext context)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
                _context = context;
            }

            public async Task<SportFieldDto> Handle(GetSportFieldQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var sportField = await _context.SportField
                        .Include(s => s.FieldType)
                        .Include(s => s.TimeSlots)
                        .Include(s => s.Images)
                        .Include(s => s.Ratings)
                            .ThenInclude(r=>r.Customer.User)
                        .Include(s => s.Owner)
                            .ThenInclude(o=>o.User)
                        .Include(s=>s.Vouchers)
                            .ThenInclude(v=>v.Voucher)
                        .FirstOrDefaultAsync(s => s.EndPoint == request.EndPoint);
                    if (sportField == null) throw new Exception("Sport field isn't exist");
                    sportField.Vouchers = sportField.Vouchers.Where(v => v.Quantity > 0 && v.Voucher.EndTime >= DateTime.Now).ToList();
                    var minPrice = sportField.TimeSlots.Min(t=>t.Price);
                    var maxPrice = sportField.TimeSlots.Max(t => t.Price);
                    var sportFieldDto = _mapper.Map<SportFieldDto>(sportField);
                    sportFieldDto.NumberOfReviews = sportField.Ratings.Count;
                    var bookings = await _context.Booking.Where(b=>b.SportFieldId==sportField.Id && b.Status == BookingStatus.Completed).ToListAsync();
                    sportFieldDto.NumberOfBooking = bookings.Count;
                    return sportFieldDto;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
