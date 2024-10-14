using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.TimeSlotModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class TimeSlotRepository : Repository<TimeSlot>,ITimeSlotRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public TimeSlotRepository(SportAppDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(CreateTimeSlotModel request)
        {
            var timeslot = await Entities.FirstOrDefaultAsync(x => x.StartTime == request.EndTime && x.IsDeleted == false && x.SportFieldId == request.SportFieldId);
            if (timeslot != null) throw new Exception("Time slot is exist");
            try
            {
                var obj = new TimeSlot
                {
                    StartTime = request.StartTime,
                    EndTime = request.EndTime,
                    SportFieldId = request.SportFieldId,
                    Price = request.Price,
                };
                Entities.Add(obj);
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
