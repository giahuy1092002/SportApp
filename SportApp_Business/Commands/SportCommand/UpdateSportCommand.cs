using SportApp_Business.Common;
using SportApp_Infrastructure.Model.SportModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.SportCommand
{
    public class UpdateSportCommand : ICommand<bool>
    {
        public Guid SportId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public class UpdateSportHandler : ICommandHandler<UpdateSportCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public UpdateSportHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(UpdateSportCommand request, CancellationToken cancellationToken)
            {
                var model = new UpdateSportModel
                {
                    SportId = request.SportId,
                    Name = request.Name,
                    Description = request.Description,
                };
                return await _unitOfWork.Sports.Update(model);
            }
        }
    }
}
