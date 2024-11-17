using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.CategoryModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>,ICategoryRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryRepository(SportAppDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(CreateCategoryModel request)
        {
            try
            {
                var categoryTest = await Entities.FirstOrDefaultAsync(s => s.Name == request.Name);
                if (categoryTest != null) throw new AppException(ErrorMessage.SportExist);
                var category = new Category
                {
                    SportId = request.SportId,
                    Name = request.Name,
                    Description = request.Description
                };
                Entities.Add(category);
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(Guid categoryId)
        {
            try
            {
                var category = await Entities.FirstOrDefaultAsync(s => s.Id == categoryId);
                if (category == null) throw new AppException(ErrorMessage.CategoryNotExist);
                Entities.Remove(category);
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Update(UpdateCategoryModel request)
        {
            try
            {
                var categortTest = await Entities.FirstOrDefaultAsync(s => s.Name == request.Name);
                if (categortTest != null) throw new AppException(ErrorMessage.CategoryExist);
                var category = await Entities.FirstOrDefaultAsync(s => s.Id == request.CategoryId);
                category.Name = request.Name;
                category.Description = request.Description;
                Entities.Update(category);
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
