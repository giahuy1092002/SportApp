using AutoMapper;
using SportApp_Business.Common;
using SportApp_Infrastructure.Model.SportEquipmentModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.SportEquipmentCommand
{
    public class CreateSportEquipmentCommand : ICommand<bool>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sport { get; set; }
        public Guid OwnerId { get; set; }
        public long RentPrice { get; set; }
        public long BuyPrice { get; set; }
        public int QuantityInStock { get; set; }
        public class CreateSportEquipmentHandler : ICommandHandler<CreateSportEquipmentCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public CreateSportEquipmentHandler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<bool> Handle(CreateSportEquipmentCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var createSportEquipment = _mapper.Map<CreateSportEquipmentModel>(request);
                    var result = await _unitOfWork.SportEquipments.Create(createSportEquipment);
                    return await Task.FromResult(result);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                } 
                
            }
        }
    }
}
