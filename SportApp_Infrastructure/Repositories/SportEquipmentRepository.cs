using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.SportEquipmentModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class SportEquipmentRepository : Repository<SportEquipment>,ISportEquipmentRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public SportEquipmentRepository(SportAppDbContext context,IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(CreateSportEquipmentModel request)
        {
            try
            {
                var equipment = await Entities.FirstOrDefaultAsync(e=>e.Name==request.Name && e.OwnerId==request.OwnerId);
                if (equipment != null) throw new Exception("Equipment is exist");
                var sportEquipment = new SportEquipment
                {
                    Name = request.Name,
                    Description = request.Description,
                    OwnerId = request.OwnerId,
                    RentPrice = request.RentPrice,
                    BuyPrice = request.BuyPrice,
                    QuantityInStock = request.QuantityInStock,
                    Sport = request.Sport
                };
                Entities.Add(sportEquipment);  
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
            
        }
    }
}
