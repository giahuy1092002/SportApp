using MediatR;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.SportFieldDtos;
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
            public GetSportFieldUpdateHanlder(SportAppDbContext context)
            {
                _context = context;
            }

            public async Task<SportFieldUpdateDto> Handle(GetSportFieldUpdate request, CancellationToken cancellationToken)
            {

                var sportField = await _context.SportField
                    .Include(s=>s.Images)
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
                var result = new SportFieldUpdateDto
                {
                    Id = sportField.Id,
                    Name = sportField.Name,
                    Address = sportField.Address,
                    Description = sportField.Description,
                    Sport = sportField.Sport,
                    Images = sportField.Images,
                    TimeFrames = groupTimeSlot
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
