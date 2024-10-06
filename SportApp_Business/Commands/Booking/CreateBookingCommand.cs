using SportApp_Business.Common;
using SportApp_Infrastructure.Model.BookingModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportApp_Business.Commands.Booking
{
    public class CreateBookingCommand : ICommand<bool>
    {
        public string Name { get; set; }
        public long TotalPrice { get; set; }
        public Guid SportFieldId { get; set; }
        public Guid CustomerId { get; set; }
        public string? Note {  get; set; }
        public Guid? SpecId { get; set; } = Guid.Empty;

        public class CreateBookingHandler : ICommandHandler<CreateBookingCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public CreateBookingHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    var createBooking = new CreateBookingModel
                    {
                        Name = request.Name,
                        TotalPrice = request.TotalPrice,
                        SportFieldId = request.SportFieldId,
                        CustomerId = request.CustomerId,
                        Note = request.Note,
                        SpecId = request.SpecId != Guid.Empty ? request.SpecId : Guid.Empty
                    };
                    var result = await _unitOfWork.Bookings.Create(createBooking);
                    _unitOfWork.CommitTransaction();
                    return result != null ? true : false;
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
