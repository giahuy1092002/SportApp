using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.AdminModel;
using SportApp_Infrastructure.Model.CustomerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface IAdminRepository : IRepository<Admin>
    {
        Task<bool> CreateAdmin(CreateAdminModel request);
    }
}
