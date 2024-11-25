using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Helper;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.SportProductCommand
{
    public class AddColorForSportProduct : ICommand<bool>
    {
        public Guid ColorId { get; set; }
        public long Price { get; set; }
        public List<IFormFile> Images { get; set; }
        public List<Guid> SizeIds { get; set; }
        public Guid SportProductId { get; set; }
        public class AddColorForSportProductHandler : ICommandHandler<AddColorForSportProduct,bool>
        {
            private readonly SportAppDbContext _context;
            private readonly ImageService _imageService;
            private readonly IUnitOfWork _unitOfWork;
            public AddColorForSportProductHandler(SportAppDbContext context, ImageService imageService,IUnitOfWork unitOfWork)
            {
                _context = context;
                _imageService = imageService;
                _unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(AddColorForSportProduct request, CancellationToken cancellationToken)
            {
                try
                {
                    var color = await _context.Color.FirstOrDefaultAsync(c => c.Id == request.ColorId);
                    for (int i = 0; i < request.Images.Count; i++)
                    {
                        var result = await _imageService.AddImageAsync(request.Images[i]);
                        if (i == 0)
                        {
                            var image = new ImageProduct
                            {
                                SportProductId = request.SportProductId,
                                ColorId = request.ColorId,
                                PictureUrl = result.SecureUrl.ToString(),
                                PublicId = result.PublicId,
                                Type = "List"
                            };
                            _context.ImageProduct.Add(image);
                        }
                        else
                        {
                            var image = new ImageProduct
                            {
                                SportProductId = request.SportProductId,
                                ColorId = request.ColorId,
                                PictureUrl = result.SecureUrl.ToString(),
                                PublicId = result.PublicId,
                                Type = "Detail"
                            };
                            _context.ImageProduct.Add(image);
                        }
                    }
                    var sportProduct = await _context.SportProduct.FirstOrDefaultAsync(s => s.Id == request.SportProductId);
                    foreach (var sizeId in request.SizeIds)
                    {
                        var variant = new SportProductVariant
                        {
                            Price = request.Price,
                            SportProductId = request.SportProductId,
                            SizeId = sizeId,
                            ColorId = request.ColorId,
                            EndPoint = CreateEndpoint.AddEndpoint(sportProduct.Name + " " + color.Name)
                        };
                        _context.SportProductVariant.Add(variant);
                    }
                    await _unitOfWork.SaveChangesAsync();
                    _unitOfWork.CommitTransaction();
                    return await Task.FromResult(true);
                }
                catch
                {
                    _unitOfWork.RollbackTransaction();
                    throw;
                }
            }
        }
    }
}
