using AutoMapper;
using SportApp_Business.Common;
using SportApp_Infrastructure.Model.SportTeamModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.SportTeamCommand
{
    public class UpdateSportTeamCommand : ICommand<bool>
    {
        public Guid SportTeamId { get; set; }
        public string Sport { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string? Note { get; set; }
        public int LimitMember { get; set; }
        public class UpdateSportTeamHandler : ICommandHandler<UpdateSportTeamCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public UpdateSportTeamHandler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<bool> Handle(UpdateSportTeamCommand request, CancellationToken cancellationToken)
            {
                var model = _mapper.Map<UpdateSportTeamModel>(request);
                return await _unitOfWork.SportTeams.Update(model);
            }
        }
    }
}
