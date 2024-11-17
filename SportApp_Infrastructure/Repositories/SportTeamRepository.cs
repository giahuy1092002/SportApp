using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Helper;
using SportApp_Infrastructure.Model.SportTeamModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class SportTeamRepository : Repository<SportTeam>,ISportTeamRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public SportTeamRepository(SportAppDbContext context,IUnitOfWork unitOfWork): base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SportTeam> Create(CreateSportTeamModel request)
        {
            try
            {
                var sportTeamTest = await Entities.FirstOrDefaultAsync(s => s.Name == request.Name);
                if (sportTeamTest != null) throw new AppException(ErrorMessage.SportTeamExist);
                var sportTeam = new SportTeam
                {
                    Name = request.Name,
                    Address = request.Address,
                    Description = request.Description,
                    Note = request.Note,
                    LimitMember = request.LimitMember,
                    Sport = request.Sport,
                    Endpoint = CreateEndpoint.AddEndpoint(request.Name)
                };
                Entities.Add(sportTeam);
                await _unitOfWork.SaveChangesAsync();
                return sportTeam;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(Guid sportTeamId)
        {
            try
            {
                var sportTeam = await Entities.FirstOrDefaultAsync(s => s.Id == sportTeamId);
                if (sportTeam == null) throw new AppException(ErrorMessage.SportTeamNotExist);
                sportTeam.IsDelete = true;
                Entities.Update(sportTeam);
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Update(UpdateSportTeamModel request)
        {
            try
            {
                var sportTeam = await Entities.FirstOrDefaultAsync(s => s.Id == request.SportTeamId);
                if (sportTeam == null) throw new AppException(ErrorMessage.SportTeamNotExist);
                sportTeam.Name = request.Name;
                sportTeam.Address = request.Address;
                sportTeam.Sport = request.Sport;
                sportTeam.LimitMember = request.LimitMember;
                sportTeam.Endpoint = CreateEndpoint.AddEndpoint(request.Name);
                sportTeam.Note = request.Note;
                sportTeam.Description = request.Description;
                Entities.Update(sportTeam);
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
