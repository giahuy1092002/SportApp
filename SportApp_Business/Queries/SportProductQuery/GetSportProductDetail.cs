using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.BookingDtos;
using SportApp_Business.Dtos.SportProductDtos;
using SportApp_Infrastructure;
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
        public class GetSportProductDetailHandler : IQueryHandler<GetSportProductDetail,SportProductDetailDto>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetSportProductDetailHandler(SportAppDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<SportProductDetailDto> Handle(GetSportProductDetail request, CancellationToken cancellationToken)
            {
                var sportSproductVariant = await _context.SportProductVariant
                    .Include(sv=>sv.SportProduct)
                    .Include(sv=>sv.Color)
                    .Include(sv=>sv.Sizes)
                    .Include(sv=>sv.ImageProducts)
                    .FirstOrDefaultAsync(sv=>sv.EndPoint==request.EndPoint);
                var sizes = sportSproductVariant.Sizes;
                var product = sportSproductVariant.SportProduct;
                var imageEndPoint = product.Variants
                    .Select(sv => new ImageEndPoint
                    {
                        PictureUrl = sv.ImageProducts.FirstOrDefault(i => i.SportProductVariantId == sv.Id && i.Type == "List").PictureUrl,
                        EndPoint = sv.EndPoint
                    }).ToList();
                var result = new SportProductDetailDto
                {
                    Name = sportSproductVariant.SportProduct.Name + " " + sportSproductVariant.Color.Name,
                    Price = sportSproductVariant.Price,
                    Sizes = _mapper.Map<List<SizeDto>>(sizes),
                    ImageEndPoints = imageEndPoint
                };
                return result;
            }
        }
    }
}
