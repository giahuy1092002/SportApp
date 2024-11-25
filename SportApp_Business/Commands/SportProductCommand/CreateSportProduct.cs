using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Helper;
using SportApp_Infrastructure.Model.SportProductModel;
using SportApp_Infrastructure.Model.SportProductVariantModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using SportApp_Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportApp_Business.Commands.SportProductCommand
{
    public class CreateSportProductCommand : ICommand<bool>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public long Price { get; set; }
        public Guid ColorId { get; set; }
        public int QuantityInStock { get; set; }
        public List<IFormFile> Images { get; set; }
        public List<Guid> SizeIds { get; set; }
        public class CreateSportProductHandler : ICommandHandler<CreateSportProductCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ImageService _imageService;
            private readonly SportAppDbContext _context;
            public CreateSportProductHandler(IUnitOfWork unitOfWork,ImageService imageService, SportAppDbContext context)
            {
                _unitOfWork = unitOfWork;
                _imageService = imageService;
                _context = context;
            }

            public async Task<bool> Handle(CreateSportProductCommand request, CancellationToken cancellationToken)
            {

                try
                {
                    _unitOfWork.BeginTransaction();
                    // Add product
                    var model = new CreateSportProductModel
                    {
                        Name = request.Name,
                        Description = request.Description,
                        CategoryId = request.CategoryId,
                    };
                    var productId = await _unitOfWork.Products.Create(model);
                    var color = await _context.Color.FirstOrDefaultAsync(c=>c.Id==request.ColorId);
                    // Add image product
                    for (int i = 0; i < request.Images.Count; i++)
                    {
                        var result = await _imageService.AddImageAsync(request.Images[i]);
                        if (i == 0)
                        {
                            var image = new ImageProduct
                            {
                                SportProductId = productId,
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
                                SportProductId = productId,
                                ColorId = request.ColorId,
                                PictureUrl = result.SecureUrl.ToString(),
                                PublicId = result.PublicId,
                                Type = "Detail"
                            };
                            _context.ImageProduct.Add(image);
                        }
                    }
                    // Add variant
                    foreach (var sizeId in request.SizeIds)
                    {
                        var variant = new SportProductVariant
                        {
                            Price = request.Price,
                            SportProductId = productId,
                            SizeId = sizeId,
                            ColorId = request.ColorId,
                            EndPoint = CreateEndpoint.AddEndpoint(request.Name + " " + color.Name)
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
