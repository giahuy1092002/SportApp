using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.ColorQuery
{
    public class GetColors : IQuery<List<Color>>
    {
        public class GetColorsHandler : IQueryHandler<GetColors,List<Color>>
        {
            private readonly SportAppDbContext _context;
            public GetColorsHandler(SportAppDbContext context)
            {
                _context = context;
            }

            public async Task<List<Color>> Handle(GetColors request, CancellationToken cancellationToken)
            {
                var list = await _context.Color.ToListAsync();
                return list;
            }
        }
    }
}
