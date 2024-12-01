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
    public class GetSportTeamDetail:IQuery<SportTeamDetail>
    {
        public string EndPoint { get; set; }
        public class GetSportTeamDetailHandler : IQueryHandler<GetSportTeamDetail,SportTeamDetail>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetSportTeamDetailHandler(SportAppDbContext context,IMapper mapper)
            { 
              _context = context;  
              _mapper = mapper;
            }

            public async Task<SportTeamDetail> Handle(GetSportTeamDetail request, CancellationToken cancellationToken)
            {   
                var sportTeam = await _context.SportTeam
                    .Include(s => s.Members)
                        .ThenInclude(u => u.Customer)
                            .ThenInclude(c => c.User)
                    .FirstOrDefaultAsync(s=>s.Endpoint ==request.EndPoint);
                var captain = await _context.UserSportTeam.FirstOrDefaultAsync(u => u.SportTeamId == sportTeam.Id && u.Role == RoleType.Leader);
                var result = _mapper.Map<SportTeamDetail>(sportTeam);
                result.LeaderId = captain.CustomerId;
                result.Members = _mapper.Map<List<MemberDto>>(sportTeam.Members
                    .Where(u=>u.IsAccept==true)
                    .OrderBy(m=>m.JoinDate));

                var list = await _context.UserSportTeam
                    .Include(u=>u.Customer)
                        .ThenInclude(c=>c.User)
                    .Where(u=>u.SportTeamId==sportTeam.Id&&u.IsAccept==false).ToListAsync();
                var requests = _mapper.Map<List<RequestSportTeam>>(list);
                result.Requests = requests;
                return result;
            }
        }
    }
}
