using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.SportFieldDtos;
using SportApp_Business.Helper;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SportApp_Business.Queries.SportFieldQuery
{
    public class GetSportFieldsQuery : IQuery<PaginatedList<SportFieldListDto>>
    {
        public string? Search { get; set; }
        public string? Sort { get; set; }
        public string? Sports { get; set; }
        public string? StarRatings { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        //public long? MinPrice { get; set; }
        //public long? MaxPrice { get; set; }
        public class GetSportFieldsHandler : IQueryHandler<GetSportFieldsQuery, PaginatedList<SportFieldListDto>>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetSportFieldsHandler(SportAppDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<PaginatedList<SportFieldListDto>> Handle(GetSportFieldsQuery request, CancellationToken cancellationToken)
            {
                var sportList = new List<string>();
                var stars = new List<decimal>();
                IQueryable<SportField> query = _context.SportField
                    .Include(s => s.Ratings)
                    .Include(s => s.TimeSlots)
                    .Include(s=>s.Images)
                    ;
                if(!string.IsNullOrEmpty(request.Search))
                {
                    query = query.Where(s=>s.Name.Contains(request.Search));
                }    
                if(!string.IsNullOrEmpty(request.Sort))
                {
                    switch (request.Sort)
                    {
                        case "Z-A":
                            query = query.OrderByDescending(s => s.Name);
                            break;
                        case "$-SSS":
                            query = query.OrderBy(s => s.TimeSlots.Min(s=>s.Price));
                            break;
                        case "$$$-$":
                            query = query.OrderByDescending(s => s.TimeSlots.Max(s=>s.Price));
                            break;
                        default:
                            query = query.OrderBy(s => s.Name);
                            break;
                    }
                }    
                if (!string.IsNullOrEmpty(request.Sports))
                {
                    sportList.AddRange(request.Sports.Split(",").ToList());
                }
                if (!string.IsNullOrEmpty(request.StarRatings))
                {
                    stars.AddRange(request.StarRatings.Split(",").Select(decimal.Parse));
                }
                if (sportList.Any())
                {
                    query = query.Where(s => sportList.Contains(s.Sport));

                }
                decimal minStar = 0;
                if (stars.Any())
                {
                    minStar = stars.Min();
                }
                var sportFieldList =  await PaginatedList<SportField>.CreateAsync(query, request.PageNumber, request.PageSize);
                var sportFieldListDtoItems = _mapper.Map<List<SportFieldListDto>>(sportFieldList).Where(s=>s.Stars>=minStar).ToList();
                var sportFieldListDto = new PaginatedList<SportFieldListDto>(
                    sportFieldListDtoItems,
                    sportFieldList.Count,
                    sportFieldList.PageIndex,
                    sportFieldList.TotalPages
                );

                return sportFieldListDto;
            }
            
        }
    }
}
