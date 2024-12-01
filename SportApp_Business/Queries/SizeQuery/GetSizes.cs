using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.SizeQuery
{
    public class GetSizes : IQuery<List<Size>>
    {
        public class GetSizesHandler : IQueryHandler<GetSizes,List<Size>>
        {
            private readonly SportAppDbContext _context;
            public GetSizesHandler(SportAppDbContext context)
            {
                _context = context;
            }

            public async Task<List<Size>> Handle(GetSizes request, CancellationToken cancellationToken)
            {
                var list = await _context.Size.ToListAsync();
                return list;
            }
        }
    }
}
