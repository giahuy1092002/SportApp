using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.UserCommand
{
    public class DeleteUserCommand : ICommand<bool>
    {
        public Guid UserId { get; set; }
        public class DeleteUserHandler: ICommandHandler<DeleteUserCommand,bool>
        {
            private readonly SportAppDbContext _context;
            public DeleteUserHandler(SportAppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u=>u.Id== request.UserId);
                if (user == null) throw new AppException("Account không tồn tại");
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
