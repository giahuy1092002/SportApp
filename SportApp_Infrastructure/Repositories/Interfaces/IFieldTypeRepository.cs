using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.FieldType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface IFieldTypeRepository : IRepository<FieldType>
    {
        Task<bool> Create(CreateFieldTypeModel request);
    }
}
