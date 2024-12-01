using SportApp_Business.Common;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.SportTeamCommand
{
    public class DeleteSportTeamCommand : ICommand<bool>
    {
        public Guid SportTeamId { get; set; }
        public class DeleteSportTeamHandler : ICommandHandler<DeleteSportTeamCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteSportTeamHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;   
            }
            public async Task<bool> Handle(DeleteSportTeamCommand request, CancellationToken cancellationToken)
            {
                return await _unitOfWork.SportTeams.Delete(request.SportTeamId);
            }
        }
    }
}
