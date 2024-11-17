using SportApp_Business.Common;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.OwnerCommand
{
    public class DeleteOwner : ICommand<bool>
    {
        public Guid OwnerId { get; set; }
        public class DeleteOwnerHandler : ICommandHandler<DeleteOwner,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteOwnerHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(DeleteOwner request, CancellationToken cancellationToken)
            {
                return await _unitOfWork.Owners.Delete(request.OwnerId);
            }
        }
    }
}
