using SportApp_Business.Common;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.TimeSlotCommand
{
    public class DeleteTimeSlotCommand : ICommand<bool>
    {
        public Guid TimeSlotId { get; set; }
        public class DeleteTimeSlotHandler : ICommandHandler<DeleteTimeSlotCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteTimeSlotHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(DeleteTimeSlotCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var timeslot = await _unitOfWork.TimeSlots.GetById(request.TimeSlotId);
                    if (timeslot == null) throw new Exception("Time slot is not exist");
                    await _unitOfWork.TimeSlots.Delete(timeslot);
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
