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
        public string? Colors { get; set; }
        public string? Sizes { get; set; }
        public string? Sports { get; set; }
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
                    .OrderBy(s=>s.Name)
                    .Include(s=>s.Variants)
                        .ThenInclude(sv=>sv.Color)
                    .Include(s=>s.ImageProducts)
                    .ToListAsync();
                var productListDto = list
                    .SelectMany(s => s.Variants
                    .GroupBy(s => s.Color)
                    .Select(g => new SportProductDto
                    {
                        EndPoint = CreateEndpoint.AddEndpoint(s.Name + " " + g.Key.Name),
                        PictureUrl = s.ImageProducts.FirstOrDefault(i => i.Color == g.Key && i.Type == "List")?.PictureUrl,
                        Price = s.Variants.FirstOrDefault(sku => sku.Color == g.Key).Price,
                        Name = s.Name + " " + g.Key.Name,
                        ColorEndpoints = s.Variants
            .GroupBy(v => v.Color)
            .Select(cg => new ColorEndpoint
            {
                EndPoint = CreateEndpoint.AddEndpoint(s.Name + " " + cg.Key.Name),
                ColorCode = cg.Key.Value
            })
            .DistinctBy(ce => new { ce.EndPoint, ce.ColorCode })
            .ToList()
                    })).ToList();
                productListDto = query.OrderBy switch
                {
                    "$-$$$" => productListDto.OrderBy(p => p.Price).ToList(),
                    "$$$-$" => productListDto.OrderByDescending(p => p.Price).ToList(),
                    "A-Z" => productListDto.OrderBy(p => p.Name).ToList(),
                    "Z-A" => productListDto.OrderByDescending(p => p.Name).ToList(),
                    _ => productListDto.OrderBy(p => p.Name).ToList(),
                };
                return new SportProductListDto
                {
                    Products = productListDto,
                    Count = productListDto.Count
                };
            }
        }
    }
}
