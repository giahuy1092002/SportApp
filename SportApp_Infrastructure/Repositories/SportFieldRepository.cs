using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.SportFieldModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class SportFieldRepository : Repository<SportField>,ISportFieldRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public SportFieldRepository(SportAppDbContext context,IUnitOfWork unitOfWork):base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Create(CreateSportFieldModel request)
        {
            var sportField = await Entities.FirstOrDefaultAsync(x => x.Name == request.Name && x.IsDeleted == false && x.OwnerId==request.OwnerId);
            if (sportField != null) throw new Exception("Sport Field is exist");
            try
            {
                var obj = new SportField
                {
                    Name = request.Name,
                    Sport = request.Sport,
                    Address = request.Address,
                    FieldTypeId = request.FieldTypeId,
                    OwnerId = request.OwnerId
                };
                Entities.Add(obj);
                await _unitOfWork.SaveChangesAsync();
                return obj.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
