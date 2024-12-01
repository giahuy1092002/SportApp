using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.SportTeamDtos;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.SportTeamQuery
{
    public class GetSportTeamByCustomer : IQuery<SportTeamListDto>
    {
        public Guid CustomerId { get; set; }
        public class GetSportTeamByUserHandler :IQueryHandler<GetSportTeamByCustomer,SportTeamListDto>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetSportTeamByUserHandler(SportAppDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<SportTeamListDto> Handle(GetSportTeamByCustomer request, CancellationToken cancellationToken)
            {
                var sportTeams = await _context.UserSportTeam
                    .Include(u=>u.SportTeam)
                    .Where(u => u.CustomerId == request.CustomerId && u.IsAccept==true).ToListAsync();
                var list = _mapper.Map<List<SportTeamDto>>(sportTeams);
                foreach(var team in list)
                {
                    var captain = await _context.UserSportTeam.FirstOrDefaultAsync(u => u.SportTeamId == team.Id && u.Role == RoleType.Leader);
                    team.LeaderId = captain.CustomerId;
                } 
                    
                return new SportTeamListDto
                {
                    SportTeams = list,
                    Count = list.Count()
                };
            }
        }
    }
}
