using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.SportDtos;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.SportQuery
{
    public class GetSportsQuery : IQuery<List<SportDto>>
    {
        public class GetSportHandler : IQueryHandler<GetSportsQuery,List<SportDto>>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetSportHandler(SportAppDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<SportDto>> Handle(GetSportsQuery request, CancellationToken cancellationToken)
            {
                var sports = await _context.Sport
                    .Include(s=>s.Categories)
                        .ToListAsync(); 
                var result = _mapper.Map<List<SportDto>>(sports);
                return result;
            }
        }
    }
}
