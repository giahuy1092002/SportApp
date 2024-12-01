using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.ImageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface IImageRepository : IRepository<Image>
    {
        Task<Image> Add(CreateImageModel request);
    }
}
