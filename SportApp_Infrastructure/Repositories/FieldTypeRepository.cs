using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.FieldType;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class FieldTypeRepository : Repository<FieldType>,IFieldTypeRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public FieldTypeRepository(SportAppDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(CreateFieldTypeModel request)
        {
            var owner = await Entities.FirstOrDefaultAsync(x => x.Name == request.Name && x.IsDeleted == false);
            if (owner != null) throw new Exception("FieldType is exist");
            try
            {
                var obj = new FieldType
                {
                    Name = request.Name,
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
    }
}
