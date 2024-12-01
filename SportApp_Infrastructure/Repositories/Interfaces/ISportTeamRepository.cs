using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.SportTeamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface ISportTeamRepository : IRepository<SportTeam>
    {
        Task<SportTeam> Create(CreateSportTeamModel request);
        Task<bool> Update(UpdateSportTeamModel request);
        Task<bool> Delete(Guid sportTeamId);
    }
}
