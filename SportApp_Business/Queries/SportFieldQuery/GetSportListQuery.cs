using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.SportFieldQuery
{
    public class GetSportListQuery:IQuery<List<string>>
    {
        public class GetSportListHandler:IQueryHandler<GetSportListQuery,List<string>>
        {
            private readonly SportAppDbContext _context;
            public GetSportListHandler(SportAppDbContext context)
            {
                _context = context;
            }
            public async Task<List<string>> Handle(GetSportListQuery request, CancellationToken cancellationToken)
            {
                var sportList = await _context.SportField
                    .Select(s => s.Sport)
                    .Distinct()
                    .ToListAsync();
                return sportList;
            }
        }
    }
}
