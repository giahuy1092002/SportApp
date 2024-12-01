using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.SportProductVariantModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class SportProductVariantRepository : Repository<SportProductVariant>,ISportProductVariantRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public SportProductVariantRepository(SportAppDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(CreateSportProductVariantModel request)
        {
            try
            {
                var variant = new SportProductVariant
                {
                   Price = request.Price,
                   SportProductId = request.SportProductId,
                   ColorId = request.ColorId,
                   EndPoint = request.EndPoint
                };
                Entities.Add(variant);  
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch
            {
                throw;
            }
        }

        public Task<bool> Delete(Guid sportProductId)
        {
            throw new NotImplementedException();
        }
    }
}
