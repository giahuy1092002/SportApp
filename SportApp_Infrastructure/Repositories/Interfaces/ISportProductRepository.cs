using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.SportProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface ISportProductRepository : IRepository<SportProduct>
    {
        Task<Guid> Create(CreateSportProductModel request);
        Task<bool> Update();
    }
}
