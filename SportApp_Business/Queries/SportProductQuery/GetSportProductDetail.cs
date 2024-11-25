using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.BookingDtos;
using SportApp_Business.Dtos.SportProductDtos;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.SportProductQuery
{
    public class GetSportProductDetail : IQuery<SportProductDetailDto>
    {
        public string EndPoint { get; set; }
        public class GetSportProductDetailHandler : IQueryHandler<GetSportProductDetail, SportProductDetailDto>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetSportProductDetailHandler(SportAppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<SportProductDetailDto> Handle(GetSportProductDetail request, CancellationToken cancellationToken)
            {
                var sportSproductVariant = await _context.SportProductVariant
                    .Include(sv => sv.SportProduct)
                        .ThenInclude(s=>s.ImageProducts)
                    .Include(sv => sv.Color)
                    .Include(s=>s.Size)
                    .Where(sv => sv.EndPoint == request.EndPoint).ToListAsync();
                var productId = sportSproductVariant.FirstOrDefault().SportProductId;
                var product = await _context.SportProduct
                    .Include(s => s.Variants)
                        .ThenInclude(sv=>sv.Color)
                    .Include(s=>s.ImageProducts)
                    .FirstOrDefaultAsync(s => s.Id == productId);
                    ;
                var imageEndPoint = product.Variants
                    .GroupBy(s => s.Color)
                    .Select(g => new ImageEndPoint
                    {
                        EndPoint = CreateEndpoint.AddEndpoint(product.Name + " " + g.Key.Name),
                        PictureUrl = product.ImageProducts.FirstOrDefault(i => i.SportProductId == product.Id && i.ColorId == g.Key.Id && i.Type == "List").PictureUrl,
                        IsSelected = g.Key.Name == sportSproductVariant.FirstOrDefault().Color.Name ? true : false
                    }).ToList();
                var sizes = sportSproductVariant.Select(
                    s=> new SizeDto
                    {
                        Id = s.Id,
                        Value = s.Size.Value,
                        QuantityInStock = s.QuantityInStock
                    }
                    ).ToList();
                var result = new SportProductDetailDto
                {
                    Name = product.Name + " " + sportSproductVariant.FirstOrDefault().Color.Name,
                    Price = sportSproductVariant.FirstOrDefault().Price,
                    Sizes = sizes,
                    ImageEndPoints = imageEndPoint
                };
                return result;
            }
        }
    }
}
