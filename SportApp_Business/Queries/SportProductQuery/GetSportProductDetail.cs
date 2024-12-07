using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.BookingDtos;
using SportApp_Business.Dtos.RatingDtos;
using SportApp_Business.Dtos.SportProductDtos;
using SportApp_Domain.Entities;
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
                    .Include(sv=>sv.Size)
                    .Include(sv=>sv.Ratings)
                    .Where(sv => sv.EndPoint == request.EndPoint).ToListAsync();
                var ratings = sportSproductVariant
                    .SelectMany(sv => sv.Ratings)
                    .Select(r => new SportProductRatingDto
                    {
                        SportProductVariantName = r.SportProductVariantName,
                        SizeValue = r.SizeValue,
                        ColorName = r.ColorName,
                        StartRating = r.StartRating,
                        Comment = r.Comment,
                        FirstName = r.FirstName,
                        LastName = r.LastName,
                        Avatar = r.Avatar
                    })
                    .ToList();
                var average = ratings != null && ratings.Any() ? Math.Round((double)ratings.Average(r => r.StartRating), 2) : 0;
                var productId = sportSproductVariant.FirstOrDefault().SportProductId;
                var product = await _context.SportProduct
                    .Include(s => s.Variants)
                        .ThenInclude(sv=>sv.Color)
                    .Include(s=>s.Category)
                        .ThenInclude(c=>c.Sport)
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
                    SportProductId = productId,
                    CategoryName = product.Category.Name,
                    Sport = product.Category.Sport.Name,
                    Name = product.Name + " " + sportSproductVariant.FirstOrDefault().Color.Name,
                    Price = sportSproductVariant.FirstOrDefault().Price,
                    Sizes = sizes,
                    ImageEndPoints = imageEndPoint,
                    Ratings = ratings,
                    StarAverage = average
                };
                return result;
            }
        }
    }
}
