using SportApp_Business.Common;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.SportFieldCommand
{
    public class DeleteSportFieldCommand : ICommand<bool>
    {
        public Guid SportFieldId { get; set; }
        public class DeleteSportFieldHandler : ICommandHandler<DeleteSportFieldCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteSportFieldHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(DeleteSportFieldCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var sportField = await _unitOfWork.SportFields.GetById(request.SportFieldId);
                    if (sportField == null) throw new Exception("Sport field is not exist");
                    await _unitOfWork.SportFields.Delete(sportField);
                    return await Task.FromResult(true);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                } 
            }
        }
    }
}
