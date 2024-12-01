using SportApp_Domain.Entities;
using SportApp_Infrastructure.Dto.TimeSlotDto;
using SportApp_Infrastructure.Model.SportFieldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface ISportFieldRepository : IRepository<SportField>    
    {
        Task<SportField> Create(CreateSportFieldModel request);
        Task<bool> Update(UpdateSportFieldModel request);
        Task<List<TimeSlot>> GetScheduler(Guid sportFieldId);
        Task<bool> Delete(Guid sportFieldId);
    }
}
