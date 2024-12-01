using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportApp_Business.Commands.SportTeamCommand
{
    public class DeleteMemberCommand : ICommand<bool>
    {
        public Guid SportTeamId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CaptainId { get; set; }
        public class DeleteMemberHandler : ICommandHandler<DeleteMemberCommand,bool>
        {
            private readonly SportAppDbContext _context;
            public DeleteMemberHandler(SportAppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
            {
                var captain = await _context.UserSportTeam.FirstOrDefaultAsync(u=>u.SportTeamId == request.SportTeamId&&u.CustomerId==request.CaptainId);
                if (captain.Role != RoleType.Leader) throw new AppException("Bạn không phải là quản lý của đội.");
                var member = await _context.UserSportTeam.FirstOrDefaultAsync(u=>u.SportTeamId==request.SportTeamId&&u.CustomerId==request.CustomerId);
                _context.UserSportTeam.Remove(member);
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
        }
    }
}
