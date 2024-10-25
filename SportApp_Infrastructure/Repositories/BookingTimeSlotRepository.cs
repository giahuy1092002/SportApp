using SportApp_Domain.Entities;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class BookingTimeSlotRepository : Repository<BookingTimeSlot>,IBookingTimeSlotRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookingTimeSlotRepository(IUnitOfWork unitOfWork,SportAppDbContext context):base(context)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
