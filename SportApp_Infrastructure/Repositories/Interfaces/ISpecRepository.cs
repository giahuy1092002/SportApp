using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.SpecModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface ISpecRepository : IRepository<Spec>
    {
        Task<bool> Create(CreateSpecModel request);
    }
}
