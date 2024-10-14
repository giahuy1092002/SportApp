using AutoMapper;
using SportApp_Business.Common;
using SportApp_Infrastructure.Model.TimeSlotModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.TimeSlotCommand
{
    public class CreateTimeSlotCommand : ICommand<bool>
    {
        public string StartTime {  get; set; }
        public string EndTime { get; set; }
        public Guid SportFieldId { get; set; }
        public long Price { get; set; }
        public class CreateTimeSlotHandler : ICommandHandler<CreateTimeSlotCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public CreateTimeSlotHandler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<bool> Handle(CreateTimeSlotCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var createTimeSlot = _mapper.Map<CreateTimeSlotModel>(request);
                    var result = await _unitOfWork.TimeSlots.Create(createTimeSlot);
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
