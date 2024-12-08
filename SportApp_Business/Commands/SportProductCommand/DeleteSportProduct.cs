using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.SportProductCommand
{
    public class DeleteSportProduct : ICommand<bool>
    {
        public string Endpoint { get; set; }
        public class DeleteSportProductHandler : ICommandHandler<DeleteSportProduct,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ImageService _imageService;
            private readonly SportAppDbContext _context;
            public DeleteSportProductHandler(IUnitOfWork unitOfWork, ImageService imageService,SportAppDbContext context)
            {
                _unitOfWork = unitOfWork;   
                _imageService = imageService;
                _context = context; 
            }
            public async Task<bool> Handle(DeleteSportProduct request, CancellationToken cancellationToken)
            {
                var listVariant = await _context.SportProductVariant
                    .Include(sv=>sv.Color)
                    .Include(sv=>sv.SportProduct)
                        .ThenInclude(s=>s.ImageProducts)
                    .Where(sv=>sv.EndPoint == request.Endpoint).ToListAsync();
                var sportProduct = await _context.SportProduct
                    .Include(s=>s.ImageProducts)
                    .FirstOrDefaultAsync(s => s.Id == listVariant.First().SportProductId);
                var images = sportProduct.ImageProducts.Where(i => i.ColorId == listVariant.First().ColorId);
                foreach (var item in images)
                {
                    var result = await _imageService.DeleteImageAsync(item.PublicId);
                    if (result.Result != "ok") throw new Exception("Delete image failed");
                    _context.ImageProduct.Remove(item);
                    await _unitOfWork.SaveChangesAsync();
                }
                foreach (var variant in listVariant)
                {
                    _context.SportProductVariant.Remove(variant);
                    _context.SaveChanges();
                }     
                return await Task.FromResult(true);
            }
        }
    }
}
