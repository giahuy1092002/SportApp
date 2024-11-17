using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class ColorRepository : Repository<Color>,IColorRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public ColorRepository(SportAppDbContext context,IUnitOfWork unitOfWork):base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(CreateColorModel request)
        {
            try
            {
                var color = await Entities.FirstOrDefaultAsync(c => c.Name == request.Name);
                if (color != null) throw new AppException("Đã tồn tại màu này");
                var obj = new Color
                {
                    Name = request.Name,
                    Value = request.Value,
                };
                Entities.Add(obj);
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
