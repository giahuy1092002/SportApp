using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.Owner;
using SportApp_Infrastructure.Model.SpecModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class SpecRepository : Repository<Spec>, ISpecRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public SpecRepository(SportAppDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(CreateSpecModel request)
        {
            var spec = await Entities.FirstOrDefaultAsync(x => x.UserId == request.UserId);
            if (spec != null) throw new Exception("Spec is exist");
            try
            {
                var obj = new Spec
                {
                    UserId = request.UserId,
                    Skills = request.Skills,
                    Note = request.Note
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
