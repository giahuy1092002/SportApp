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
    public class CreateSportCommand : ICommand<bool>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public class CreateSportHandler : ICommandHandler<CreateSportCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public CreateSportHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(CreateSportCommand request, CancellationToken cancellationToken)
            {
                var model = new CreateSportModel
                {
                    Name = request.Name,
                    Description = request.Description,
                };
                return await _unitOfWork.Sports.Create(model);
            }
        }
    }
}
