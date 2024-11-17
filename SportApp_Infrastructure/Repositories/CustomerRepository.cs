using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.CustomerModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class CustomerRepository : Repository<Customer>,ICustomerRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SportAppDbContext _context;
        public CustomerRepository(SportAppDbContext context,IUnitOfWork unitOfWork):base(context)
        {
            _unitOfWork = unitOfWork;   
            _context = context;
        }

        public async Task<bool> CreateCustomer(CreateCustomerModel request)
        {
            try
            {
                var customer = await Entities.FirstOrDefaultAsync(c=>c.UserId == request.UserId);
                if (customer!=null)
                {
                    throw new Exception("Customer is exist");
                }
                var obj = new Customer
                {
                    UserId = request.UserId,
                    Interest = request.Interest,
                    Height = request.Height,
                    Weight  = request.Weight,
                    Skills = request.Skills,
                };
                Entities.Add(obj);
                var result = _unitOfWork.SaveChanges();
                if(result!=0) return await Task.FromResult(true);
                return await Task.FromResult(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteCustomer(Guid customerId)
        {
            try
            {
                var customer = await Entities.FirstOrDefaultAsync(c => c.Id == customerId);
                var user = await _context.Users.FirstOrDefaultAsync(u=>u.Id==customer.UserId);
                Entities.Remove(customer);
                _context.Users.Remove(user);
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateCustomer(UpdateCustomerModel request)
        {
            try
            {
                var customer = await Entities.FirstOrDefaultAsync(c=>c.Id==request.CustomerId);
                if (customer == null) throw new AppException("Người chơi không tồn tại");
                customer.Interest = request.Interest;
                customer.Weight = request.Weight;
                customer.Height = request.Height;
                customer.Skills = request.Skills;
                Entities.Update(customer);
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch
            {
                throw;
            }
        }
    }
}
