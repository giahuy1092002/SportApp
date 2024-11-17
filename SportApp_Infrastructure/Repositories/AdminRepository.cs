using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.AdminModel;
using SportApp_Infrastructure.Model.CustomerModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminRepository(SportAppDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAdmin(CreateAdminModel request)
        {
            try
            {
                var admin = await Entities.FirstOrDefaultAsync(c => c.UserId == request.UserId);
                if (admin != null)
                {
                    throw new Exception("Admin is exist");
                }
                var obj = new Admin
                {
                    UserId = request.UserId,
                };
                Entities.Add(obj);
                var result = _unitOfWork.SaveChanges();
                if (result != 0) return await Task.FromResult(true);
                return await Task.FromResult(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
