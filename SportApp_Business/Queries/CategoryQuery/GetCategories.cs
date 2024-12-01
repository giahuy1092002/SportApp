using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.CategoryDtos;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.CategoryQuery
{
    public class GetCategories : IQuery<List<CategoryDto>>
    {
        public class GetCategoriesHandler : IQueryHandler<GetCategories,List<CategoryDto>>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetCategoriesHandler(SportAppDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CategoryDto>> Handle(GetCategories request, CancellationToken cancellationToken)
            {
                var list = await _context.Category.ToListAsync();
                return _mapper.Map<List<CategoryDto>>(list);
            }
        }
    }
}
