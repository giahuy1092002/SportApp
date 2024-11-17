using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.SportTeamDtos;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.SportTeamQuery
{
    public class GetSportTeams : IQuery<SportTeamListDto>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string? Search { get; set; }
        public class GetSportTeamsHandler : IQueryHandler<GetSportTeams, SportTeamListDto>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetSportTeamsHandler(SportAppDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<SportTeamListDto> Handle(GetSportTeams request, CancellationToken cancellationToken)
            {
                var list = await _context.SportTeam
                    .Where(s=>s.IsDelete == false)
                    .ToListAsync();
                var count = list.Count;
                if(request.Search!=null)
                {
                    list = list.Where(s=>s.Name.Contains(request.Search)).ToList();
                }    
                list = list.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
                var listDto = _mapper.Map<List<SportTeamDto>>(list);
                return new SportTeamListDto
                {
                    Count = count,
                    SportTeams = listDto
                };
            }
        }
    }
}
