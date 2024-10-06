using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.TimeSlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface ITimeSlotRepository : IRepository<TimeSlot>
    {
        Task<bool> Create(CreateTimeSlotModel request);
    }
}
