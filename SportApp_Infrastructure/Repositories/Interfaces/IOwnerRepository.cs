using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.Owner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface IOwnerRepository : IRepository<Owner>
    {
        Task<bool> Create(CreateOwnerModel request);
        Task<bool> Delete(Guid ownerId);
    }
}
