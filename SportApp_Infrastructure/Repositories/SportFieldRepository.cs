using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Dto.TimeSlotDto;
using SportApp_Infrastructure.Model.SportFieldModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure.Helper;
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
        private readonly SportAppDbContext _context;
        public SportFieldRepository(SportAppDbContext context,IUnitOfWork unitOfWork):base(context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<SportField> Create(CreateSportFieldModel request)
        {
            var sportField = await Entities.FirstOrDefaultAsync(x => x.Name == request.Name && x.OwnerId==request.OwnerId);
            if (sportField != null) throw new AppException(ErrorMessage.SportFieldExist);
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
                    EndPoint = CreateEndpoint.AddEndpoint(request.Name),
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                };
                Entities.Add(obj);
                await _unitOfWork.SaveChangesAsync();
                return obj;
            }
            catch
            {
                throw;
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
                var sportFieldTest = await Entities.FirstOrDefaultAsync(s=>s.Name==request.Name);
                if (sportFieldTest != null) throw new AppException(ErrorMessage.SportFieldNameExist);
                var sportField = await _unitOfWork.SportFields.GetById(request.SportFieldId);
                if (sportField == null) throw new AppException(ErrorMessage.SportFieldNotExist);
                sportField.Sport = request.Sport;
                sportField.Address = request.Address;
                sportField.Description = request.Description;
                sportField.Name = request.Name;
                sportField.EndPoint = CreateEndpoint.AddEndpoint(request.Name);
                Entities.Update(sportField);
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Delete(Guid sportFieldId)
        {
            try
            {
                var sportField = await _unitOfWork.SportFields.GetById(sportFieldId);
                if (sportField == null) throw new AppException(ErrorMessage.SportFieldNotExist);
                sportField.IsDeleted = true;
                Entities.Update(sportField);
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
