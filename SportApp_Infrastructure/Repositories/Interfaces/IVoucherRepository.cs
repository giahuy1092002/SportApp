using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.VoucherModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface IVoucherRepository : IRepository<Voucher>
    {
        Task<bool> Create(CreateVoucherModel request);
    }
}
