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
using SportApp_Infrastructure.Services;

namespace SportApp_Business.Queries.SportFieldQuery
{
    public class GetSportFieldQuery : IQuery<SportFieldDto>
    {
        public string EndPoint { get; set; }
        public double? UserLat { get; set; }
        public double? UserLong { get; set; }
        public class GetSportFieldHanlder : IQueryHandler<GetSportFieldQuery, SportFieldDto>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly SportAppDbContext _context;
            private readonly DistanceService _distanceService;
            public GetSportFieldHanlder(IMapper mapper, IUnitOfWork unitOfWork, SportAppDbContext context, DistanceService distanceService)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
                _context = context;
                _distanceService = distanceService;
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
                    var reject = _context.Booking.Where(b=>b.Status==BookingStatus.Rejected&&b.IsRejectByOwner==true).ToList();
                    var all = _context.Booking.ToList();
                    sportFieldDto.RatioAccept = 100-reject.Count/all.Count*100;
                    if(request.UserLat!=null && request.UserLong!=null)
                    {
                        var result_distance = await _distanceService.GetDistance(request.UserLat, request.UserLong, sportField.Latitude, sportField.Longitude);
                        sportFieldDto.Distance = result_distance.Distance;
                        sportFieldDto.Duration = result_distance.Duration;
                    }    
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
