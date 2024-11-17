using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.SportProductModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class SportProductRepository : Repository<SportProduct>,ISportProductRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SportAppDbContext _context;
        public SportProductRepository(SportAppDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<Guid> Create(CreateSportProductModel request)
        {
            try
            {
                var category = await _context.Category.FirstOrDefaultAsync(c=>c.Id==request.CategoryId);
                if (category == null) throw new AppException(ErrorMessage.CategoryNotExist);
                var sportProduct = await Entities.FirstOrDefaultAsync(s=>s.Name== request.Name);
                if (sportProduct != null) throw new AppException(ErrorMessage.SportProductExist);
                var product = new SportProduct
                {
                    Name = request.Name,
                    Description = request.Description,
                    CategoryId = request.CategoryId,
                };
                Entities.Add(product);
                await _unitOfWork.SaveChangesAsync();
                return product.Id;
            }
            catch
            {
                throw;
            }
        }

        public Task<bool> Update()
        {
            throw new NotImplementedException();
        }
    }
}
