using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.ImageModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class ImageRepository : Repository<Image>,IImageRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public ImageRepository(SportAppDbContext context,IUnitOfWork unitOfWork):base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(CreateImageModel request)
        {
            try
            {
                var image = new Image
                {
                    SportFieldId = request.SportFieldId,
                    PictureUrl = request.PictureUrl,
                    PublicId = request.PublicId,
                };
                Entities.Add(image);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Add image failed");
            }
        }
    }
}
