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
        public List<IFormFile> Images { get; set; }
        public string Sizes { get; set; }
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
                    var model = new CreateSportProductModel
                    {
                        Name = request.Name,
                        Description = request.Description,
                        CategoryId = request.CategoryId,
                    };
                    var productId = await _unitOfWork.Products.Create(model);
                    var color = await _context.Color.FirstOrDefaultAsync(c=>c.Id==request.ColorId);
                    var variant = new SportProductVariant
                    {
                        ColorId = request.ColorId,
                        Price = request.Price,
                        SportProductId = productId,
                        EndPoint = CreateEndpoint.AddEndpoint(request.Name + " " + color.Name)
                    };
                    await _unitOfWork.ProductVariants.Add(variant);
                    for (int i = 0; i < request.Images.Count; i++)
                    {
                        var result = await _imageService.AddImageAsync(request.Images[i]);
                        if (i == 0)
                        {
                            var image = new ImageProduct
                            {
                                SportProductVariantId = variant.Id,
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
                                SportProductVariantId = variant.Id,
                                PictureUrl = result.SecureUrl.ToString(),
                                PublicId = result.PublicId,
                                Type = "Detail"
                            };
                            _context.ImageProduct.Add(image);
                        }
                    }
                    var sizes = JsonConvert.DeserializeObject<List<SizeQuantity>>(request.Sizes);
                    foreach (var sizeDto in sizes)
                    {
                        var size = new Size
                        {
                            Value = sizeDto.Value,
                            QuantityInStock = sizeDto.QuantityInStock,
                            SportProductVariantId = variant.Id
                        };
                        _context.Size.Add(size);
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
