using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.CustomerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<bool> CreateCustomer(CreateCustomerModel request);
    }
}
