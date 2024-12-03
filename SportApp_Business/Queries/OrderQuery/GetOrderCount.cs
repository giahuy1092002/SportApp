using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.OrderQuery
{
    public class GetOrderCount : IQuery<int>
    {
        public class GetOrderCountHandler : IQueryHandler<GetOrderCount,int>
        {
            private readonly SportAppDbContext _context;
            public GetOrderCountHandler(SportAppDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(GetOrderCount request, CancellationToken cancellationToken)
            {
                var orders =  await _context.Order.ToListAsync();
                return orders.Count;
            }
        }
    }
}
