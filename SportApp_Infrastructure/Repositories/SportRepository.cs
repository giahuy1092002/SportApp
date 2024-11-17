using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.SportModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class SportRepository : Repository<Sport>,ISportRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public SportRepository(SportAppDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(CreateSportModel request)
        {
            try
            {
                var sportTest = await Entities.FirstOrDefaultAsync(s=>s.Name == request.Name);
                if (sportTest != null) throw new AppException(ErrorMessage.SportExist);
                var sport = new Sport
                {
                    Name = request.Name,
                    Description = request.Description
                };
                Entities.Add(sport);
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch
            {
                throw;
            } 
            
        }

        public async Task<bool> Delete(Guid SportId)
        {
            try
            {
                var sport = await Entities.FirstOrDefaultAsync(s=>s.Id == SportId);
                if (sport == null) throw new AppException(ErrorMessage.SportNotExist);
                Entities.Remove(sport);
                await _unitOfWork.SaveChangesAsync();   
                return await Task.FromResult(true);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Update(UpdateSportModel request)
        {
            try
            {
                var sportTest = await Entities.FirstOrDefaultAsync(s => s.Name == request.Name);
                if (sportTest != null) throw new AppException(ErrorMessage.SportExist);
                var sport = await Entities.FirstOrDefaultAsync(s => s.Id == request.SportId);
                sport.Name = request.Name;
                sport.Description = request.Description;
                Entities.Update(sport);
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
