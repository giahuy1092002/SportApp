using SportApp_Business.Common;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.SportCommand
{
    public class DeleteSportCommand : ICommand<bool>
    {
        public Guid SportId { get; set; }
        public class DeleteSportHandler :ICommandHandler<DeleteSportCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteSportHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(DeleteSportCommand request, CancellationToken cancellationToken)
            {
               return await _unitOfWork.Sports.Delete(request.SportId);
            }
        }
    }
}
