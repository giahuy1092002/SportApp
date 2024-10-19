using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.RatingModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class RatingRepository : Repository<Rating>,IRatingRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public RatingRepository(SportAppDbContext context,IUnitOfWork unitOfWork):base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(CreateRatingModel request)
        {
            try
            {
                var rating = new Rating
                {
                    SportFieldId = request.SportFieldId,
                    Comment = request.Comment,
                    NumberOfStar = request.NumberOfStar,
                    CustomerId = request.CustomerId,
                };
                await Entities.AddAsync(rating);
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            } 
            
        }
    }
}
