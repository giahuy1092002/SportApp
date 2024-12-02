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
        public Guid SportProductId { get; set; }
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
                var sportProduct = await _context.SportProduct
                    .Include(s=>s.ImageProducts)
                    .FirstOrDefaultAsync(s=>s.Id == request.SportProductId);
                foreach(var item in sportProduct.ImageProducts)
                {
                    var result = await _imageService.DeleteImageAsync(item.PublicId);
                    if (result.Result != "ok") throw new Exception("Delete image failed");
                    _context.ImageProduct.Remove(item);
                    await _unitOfWork.SaveChangesAsync();
                }
                _context.SportProduct.Remove(sportProduct);
                return await Task.FromResult(true);
            }
        }
    }
}
