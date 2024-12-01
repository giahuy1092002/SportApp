using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.CategoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<bool> Create(CreateCategoryModel request);
        Task<bool> Update(UpdateCategoryModel request);
        Task<bool> Delete(Guid categoryId);
    }
}
