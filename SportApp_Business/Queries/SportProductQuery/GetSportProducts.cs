using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SportApp_Business.Common;
using SportApp_Business.Dtos.SportProductDtos;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            public async Task<SportProductListDto> Handle(GetSportProducts request, CancellationToken cancellationToken)
            {
                var sportList = new List<string>();
                var colorList = new List<string>();
                var sizeList = new List<string>();
                if (!string.IsNullOrEmpty(request.Sports))
                {
                    sportList.AddRange(request.Sports.Split(",").ToList());
                }
                if(!string.IsNullOrEmpty(request.Colors))
                {
                    colorList.AddRange(request.Colors.Split(",").ToList());
                }
                if (!string.IsNullOrEmpty(request.Sizes))
                {
                    sizeList.AddRange(request.Sizes.Split(",").ToList());
                }
                var list = await _context.SportProduct
                    .OrderBy(s=>s.Name)
                    .Include(s=>s.Variants)
                        .ThenInclude(sv=>sv.Color)
                    .Include(s => s.Variants)
                        .ThenInclude(sv => sv.Size)
                    .Include(s=>s.ImageProducts)
                    .Include(s=>s.Category)
                        .ThenInclude(c=>c.Sport)
                    .ToListAsync();
                var productListDto = list
                    .SelectMany(s => s.Variants
                    .GroupBy(s => s.Color)
                    .Select(g => new SportProductDto
                    {
                        SportProductId = s.Id,
                        CategoryName = s.Category.Name,
                        Sport = s.Category.Sport.Name,
                        EndPoint = CreateEndpoint.AddEndpoint(s.Name + " " + g.Key.Name),
                        PictureUrl = s.ImageProducts.FirstOrDefault(i => i.Color == g.Key && i.Type == "List")?.PictureUrl,
                        Price = s.Variants.FirstOrDefault(sku => sku.Color == g.Key).Price,
                        Name = s.Name + " " + g.Key.Name,
                        ColorEndpoints = s.Variants
                    .GroupBy(v => v.Color)
                    .Select(cg => new ColorEndpoint
                    {
                        EndPoint = CreateEndpoint.AddEndpoint(s.Name + " " + cg.Key.Name),
                        ColorCode = cg.Key.Value,
                        IsSelected = true ? CreateEndpoint.AddEndpoint(s.Name + " " + cg.Key.Name) == CreateEndpoint.AddEndpoint(s.Name + " " + g.Key.Name) : false,
                        Sizes = s.Variants.Where(sv=>sv.Color.Name == cg.Key.Name).ToList()
                        .Select(x=>new String(x.Size.Value)).ToList(),
                    })
                    .DistinctBy(ce => new { ce.EndPoint, ce.ColorCode })
                    .ToList()
                    })).ToList();
                productListDto = request.OrderBy switch
                {
                    "$-$$$" => productListDto.OrderBy(p => p.Price).ToList(),
                    "$$$-$" => productListDto.OrderByDescending(p => p.Price).ToList(),
                    "A-Z" => productListDto.OrderBy(p => p.Name).ToList(),
                    "Z-A" => productListDto.OrderByDescending(p => p.Name).ToList(),
                    _ => productListDto.OrderBy(p => p.Name).ToList(),
                };
                var sizes = new List<string>();
                var colors = new List<string>();
                if (!String.IsNullOrEmpty(request.Search))
                {
                    productListDto = productListDto.Where(s => s.Name.ToLower().Contains(request.Search.ToLower())).ToList();
                }
                if (sportList.Any())
                {
                    productListDto = productListDto.Where(s => sportList.Contains(s.Sport)).ToList();
                }
                sizes = productListDto.SelectMany(p => p.ColorEndpoints).SelectMany(x => x.Sizes).Distinct().ToList();
                colors = productListDto.SelectMany(p => p.ColorEndpoints).Select(p => p.ColorCode).Distinct().ToList();
                if (colorList.Any() && sizeList.Any())
                {
                    productListDto = productListDto.Where(p => p.ColorEndpoints.Any(c => colorList.Contains(c.ColorCode))
                    && p.ColorEndpoints.Any(sv => sv.Sizes.Intersect(sizeList).Any() && sv.IsSelected == true)).ToList();
                    sizes = productListDto.SelectMany(p => p.ColorEndpoints).SelectMany(x => x.Sizes).Distinct().ToList();
                    colors = productListDto.SelectMany(p => p.ColorEndpoints).Select(p => p.ColorCode).Distinct().ToList();
                }
                else if (colorList.Any())
                {
                    productListDto = productListDto.Where(p => p.ColorEndpoints.Any(c => colorList.Contains(c.ColorCode))).ToList();
                    sizes = productListDto.SelectMany(p => p.ColorEndpoints).SelectMany(x => x.Sizes).Distinct().ToList();
                }
                else if (sizeList.Any())
                {
                    productListDto = productListDto.Where(p => p.ColorEndpoints.Any(sv => sv.Sizes.Intersect(sizeList).Any() && sv.IsSelected==true)).ToList();
                    colors = productListDto.SelectMany(p => p.ColorEndpoints).Where(p=>p.IsSelected==true).Select(p => p.ColorCode).Distinct().ToList();
                }
                else
                {
                    sizes = productListDto.SelectMany(p => p.ColorEndpoints).SelectMany(x => x.Sizes).Distinct().ToList();
                    colors = productListDto.SelectMany(p => p.ColorEndpoints).Select(p => p.ColorCode).Distinct().ToList();
                }    
                return new SportProductListDto
                {
                    Products = productListDto,
                    Count = productListDto.Count,
                    Sizes = sizes,
                    Colors = colors
                };
            }
        }
    }
}
