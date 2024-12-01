using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.SportModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface ISportRepository : IRepository<Sport>
    {
        Task<bool> Create(CreateSportModel request);
        Task<bool> Update(UpdateSportModel request);
        Task<bool> Delete(Guid SportId);
    }
}
