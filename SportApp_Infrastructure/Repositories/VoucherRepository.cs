using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.VoucherModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class VoucherRepository: Repository<Voucher>,IVoucherRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public VoucherRepository(SportAppDbContext context,IUnitOfWork unitOfWork):base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(CreateVoucherModel request)
        {
            try
            { 
                var obj = new Voucher
                {
                    Name = request.Name,
                    StartTime = request.StartTime,
                    EndTime = request.EndTime,
                    PercentSale = request.PercentSale,
                    MaxSale = request.MaxSale,
                    MinPrice = request.MinPrice
                };
                Entities.Add(obj);
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Update(UpdateVoucherModel request)
        {
            try
            {
                var voucher = await Entities.FirstOrDefaultAsync(v => v.Id == request.VoucherId);
                if (voucher == null) throw new Exception("Voucher is not exist");
                voucher.Quantity = request.Quantity;
                voucher.Name = request.Name;
                voucher.StartTime = request.StartTime;
                voucher.EndTime = request.EndTime;
                voucher.MinPrice = request.MinPrice;
                voucher.MaxSale = request.MaxSale;
                voucher.PercentSale = request.PercentSale;
                Entities.Update(voucher);
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
