using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.RatingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface IRatingRepository : IRepository<Rating>
    {
        Task<bool> Create(CreateRatingModel request);
    }
}
