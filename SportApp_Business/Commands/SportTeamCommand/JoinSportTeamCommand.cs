using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.SportTeamCommand
{
    public class JoinSportTeamCommand : ICommand<bool>
    {
        public Guid CustomerId { get; set; }
        public Guid SportTeamId { get; set; }
        public class JoinSportTeamHandler : ICommandHandler<JoinSportTeamCommand, bool>
        {
            private readonly SportAppDbContext _context;
            private readonly IUnitOfWork _unitOfWork;
            public JoinSportTeamHandler(SportAppDbContext context,IUnitOfWork unitOfWork)
            {
                _context = context;
                _unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(JoinSportTeamCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    var sportTeam = await _context.SportTeam.FirstOrDefaultAsync(s => s.Id == request.SportTeamId);
                    if (sportTeam == null) throw new AppException(ErrorMessage.SportTeamNotExist);
                    var team = await _context.UserSportTeam.FirstOrDefaultAsync(u=>u.CustomerId==request.CustomerId&&u.SportTeamId==request.SportTeamId);
                    if (team!=null)
                    {
                        throw new AppException("Bạn đã là thành viên của câu lạc bộ này");
                    }
                    var customer = await _context.Customer
                        .Include(c => c.User)
                        .FirstOrDefaultAsync(c => c.Id == request.CustomerId);
                    var captain = await _context.UserSportTeam
                        .Include(c => c.Customer)
                        .FirstOrDefaultAsync(u => u.SportTeamId == request.SportTeamId && u.Role == RoleType.Leader);
                    var notify = new Notification
                    {
                        Title = "Yêu cầu tham gia" + sportTeam.Name,
                        Content = "Người chơi " + customer.User.FirstName + " " + customer.User.LastName + " yêu cầu tham gia vào câu lạc bộ của bạn",
                        CreateAt = DateTime.Now,
                        RelatedId = request.SportTeamId,
                        RelatedType = NotifyType.SportTeam.ToString(),
                        EndPoint = request.CustomerId.ToString(),
                    };
                    _context.Notifications.Add(notify);
                    var userNotify = new UserNotification
                    {
                        NotificationId = notify.Id,
                        UserId = captain.Customer.UserId,
                    };
                    _context.UserNotifications.Add(userNotify);
                    var userSportTeam = new UserSportTeam
                    {
                        SportTeamId = request.SportTeamId,
                        CustomerId = request.CustomerId,
                        Role = RoleType.Member,
                        IsAccept = false
                    };
                    _context.UserSportTeam.Add(userSportTeam);
                    await _context.SaveChangesAsync();
                    _unitOfWork.CommitTransaction();
                    return await Task.FromResult(true);
                }
                catch
                {
                    _unitOfWork.RollbackTransaction();
                    throw;
                }
            }

        }
    }
}
