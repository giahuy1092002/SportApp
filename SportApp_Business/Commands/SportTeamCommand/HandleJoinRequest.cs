using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.SportTeamCommand
{
    public class HandleJoinRequest : ICommand<bool>
    { 
        public Guid CustomerId { get; set; }
        public Guid SportTeamId { get; set; }
        public bool Accept { get; set; }
        public class HandleJoinRequestHandler : ICommandHandler<HandleJoinRequest,bool>
        {
            private readonly SportAppDbContext _context;
            public HandleJoinRequestHandler(SportAppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(HandleJoinRequest request, CancellationToken cancellationToken)
            {
                if(request.Accept)
                {
                    var userTeam = await _context.UserSportTeam.FirstOrDefaultAsync(u=>u.CustomerId==request.CustomerId&&u.SportTeamId==request.SportTeamId);
                    userTeam.IsAccept = true;
                    _context.UserSportTeam.Update(userTeam);
                    await _context.SaveChangesAsync();
                   
                }
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
        }
    }
}
