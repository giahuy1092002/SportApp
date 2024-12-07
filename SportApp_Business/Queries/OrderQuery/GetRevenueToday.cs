using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Domain.Entities.OrderAggregate;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.OrderQuery
{
    public class GetRevenueToday : IQuery<long>
    {
        public class GetRevenueTodayHandler : IQueryHandler<GetRevenueToday,long>
        {
            private readonly SportAppDbContext _context;
            public GetRevenueTodayHandler(SportAppDbContext context)
            {
                _context = context;
            }
            public async Task<long> Handle(GetRevenueToday request, CancellationToken cancellationToken)
            {
                var today = DateTime.Today;
                var tomorrow = today.AddDays(1);

                var totalRevenue = await _context.Order
                    .Where(o => o.OrderDate >= today && o.OrderDate < tomorrow && (o.OrderStatus==OrderStatus.PaymentReceived||o.OrderStatus==OrderStatus.Complete))
                    .ToListAsync();

                return totalRevenue.Sum(o => o.GetTotal());
            }
        }
    }
}
