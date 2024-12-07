using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.BookingModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookingRepository(SportAppDbContext context,IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Booking> Create(CreateBookingModel request)
        {
            try
            {
                var booking = new Booking
                {
                    Name = request.Name,
                    CustomerId = request.CustomerId,
                    TotalPrice = request.TotalPrice,
                    SportFieldId = request.SportFieldId,
                    Note = request.Note,
                    BookingDate = request.BookingDate,
                    TimeFrameBooked ="",
                    FullName = request.FullName,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber
                };
                Entities.Add(booking);
                await _unitOfWork.SaveChangesAsync();
                return booking;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            } 
            

        }

    }
}
