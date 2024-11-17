using AutoMapper;
using SportApp_Business.Common;
using SportApp_Infrastructure.Model.UserModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.UserCommand
{
    public class UpdateGeoCommand : ICommand<bool>
    {
        public Guid UserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public class UpdateGeoHandler : ICommandHandler<UpdateGeoCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public UpdateGeoHandler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<bool> Handle(UpdateGeoCommand command,CancellationToken cancellationToken)
            {
                try
                {
                    var model = _mapper.Map<UpdateGeoModel>(command);
                    return await _unitOfWork.Users.UpdateGeo(model);
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                } 
                
            }
        }
    }
}
