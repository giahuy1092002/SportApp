using SportApp_Infrastructure.Model.SportFieldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface ISportFieldRepository
    {
        Task<Guid> Create(CreateSportFieldModel request);
    }
}
