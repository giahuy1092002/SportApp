using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.SportEquipmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface ISportEquipmentRepository : IRepository<SportEquipment>
    {
        Task<bool> Create(CreateSportEquipmentModel request);
    }
}
