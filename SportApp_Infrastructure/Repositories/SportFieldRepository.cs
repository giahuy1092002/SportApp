using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Dto.TimeSlotDto;
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
                    Description = request.Description,
                    FieldTypeId = request.FieldTypeId,
                    OwnerId = request.OwnerId,
                    EndPoint = CreateEndpoint(request.Name)
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

        public async Task<List<TimeSlot>> GetScheduler(Guid sportFieldId)
        {
            var scheduler = await Entities.FirstOrDefaultAsync(s => s.Id == sportFieldId);
            return scheduler.TimeSlots.ToList();
        }

        public async Task<bool> Update(UpdateSportFieldModel request)
        {
            try
            {
                var sportField = await _unitOfWork.SportFields.GetById(request.SportFieldId);
                if (sportField == null) throw new Exception("Sport field is not exist");
                sportField.Sport = request.Sport;
                sportField.Address = request.Address;
                sportField.Description = request.Description;
                sportField.Name = request.Name;
                Entities.Update(sportField);
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
        private string CreateEndpoint(string name)
        {
            var array = name.ToLower().Split(" ");
            return string.Join("-", array);
        }
    }
}
