using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
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
    public class GetSportProducts : IQuery<SportProductListDto>
    {
        public string? Search { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string? OrderBy { get; set; }
        public class GetSportProductsHandler : IQueryHandler<GetSportProducts, SportProductListDto>
        {
            private readonly SportAppDbContext _context;
            public GetSportProductsHandler(SportAppDbContext context)
            {
                _context = context;
            }
            public async Task<SportProductListDto> Handle(GetSportProducts query, CancellationToken cancellationToken)
            {
                var list = await _context.SportProduct
                    .Include(s=>s.Variants)
                        .ThenInclude(sv=>sv.ImageProducts)
                    .Include(s=>s.Variants)
                        .ThenInclude(sv=>sv.Color)
                    .ToListAsync();

                var productListDto = list.SelectMany(
                    s=>s.Variants
                    .Select(sv=> new SportProductDto
                    {
                        Name = s.Name + " " + sv.Color.Name,
                        PictureUrl = sv.ImageProducts.FirstOrDefault(i=>i.SportProductVariantId==sv.Id&&i.Type=="List").PictureUrl,
                        Price = sv.Price,
                        ColorEndpoints = s.Variants.Select(
                            sv=> new ColorEndpoint
                            {
                                EndPoint = CreateEndpoint.AddEndpoint(s.Name + " " + sv.Color.Name),
                                ColorCode = sv.Color.Value
                            }
                            ).ToList()
                    })
                    ).ToList();

                return new SportProductListDto
                {
                    Products = productListDto,
                    Count = productListDto.Count
                };
            }
        }
    }
}
