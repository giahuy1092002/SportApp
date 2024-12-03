using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.SportFieldDtos;
using SportApp_Business.Dtos.VoucherDtos;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.SportFieldQuery
{
    public class GetSportFieldUpdate : IQuery<SportFieldUpdateDto>
    {
        public string EndPoint { get; set; }
        public class GetSportFieldUpdateHanlder : IQueryHandler<GetSportFieldUpdate, SportFieldUpdateDto>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetSportFieldUpdateHanlder(SportAppDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<SportFieldUpdateDto> Handle(GetSportFieldUpdate request, CancellationToken cancellationToken)
            {

                var sportField = await _context.SportField
                    .Include(s=>s.Images)
                    .Include(s=>s.Vouchers)
                        .ThenInclude(sv=>sv.Voucher)
                    .FirstOrDefaultAsync(s => s.EndPoint == request.EndPoint);
                var timeslots = await _context.TimeSlot
                    .Include(t => t.SportField)
                    .OrderBy(t=>t.Price)
                    .Where(t => t.SportField.EndPoint == request.EndPoint).ToListAsync();
                var groupTimeSlot = timeslots
                    .GroupBy(t => t.Price)
                    .Select(
                    group => new TimeFrame
                    {
                        StartTime = group.ToList()[0].StartTime,
                        EndTime = group.ToList()[group.ToList().Count()-1].EndTime,
                        Price = group.Key
                    }).ToList();
                var vouchers = _mapper.Map<List<VoucherDto>>(sportField.Vouchers);
                var result = new SportFieldUpdateDto
                {
                    Id = sportField.Id,
                    Name = sportField.Name,
                    Address = sportField.Address,
                    Description = sportField.Description,
                    Sport = sportField.Sport,
                    Images = sportField.Images,
                    TimeFrames = groupTimeSlot,
                    Vouchers = vouchers
                };
                return result;
            }
        }
    }
    public class TimeFrame
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public long Price { get; set; }
    }
}
