using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.SportProductVariantModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface ISportProductVariantRepository : IRepository<SportProductVariant>
    {
        Task<bool> Create(CreateSportProductVariantModel request);
        Task<bool> Delete(Guid sportProductId);
    }
}
