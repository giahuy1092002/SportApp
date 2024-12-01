using SportApp_Business.Common;
using SportApp_Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.SportProductQuery
{
    public class GetSportProductCount:IQuery<int>
    {
        public class GetSportProductCountHandler : IQueryHandler<GetSportProductCount,int>
        {
            private readonly SportAppDbContext _context;
            public GetSportProductCountHandler(SportAppDbContext context)
            {
               _context = context;
            }

            public async Task<int> Handle(GetSportProductCount request, CancellationToken cancellationToken)
            {
                var list = await _context.SportProductVariant
                    .ToListAsync();
                list = list
                    .GroupBy(sv => new { sv.SportProductId, sv.ColorId })
                    .Select(group => group.First())
                    .ToList();
                return list.Count;
            }
        }
    }
}
