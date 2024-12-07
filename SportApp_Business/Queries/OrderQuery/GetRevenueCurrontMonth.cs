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
    public class GetRevenueCurrontMonth : IQuery<long>
    {
        public class GetRevenueCurrontMonthHandler : IQueryHandler<GetRevenueCurrontMonth,long>
        {
            private readonly SportAppDbContext _context;
            public GetRevenueCurrontMonthHandler(SportAppDbContext context)
            {
                _context = context;
            }
            public async Task<long> Handle(GetRevenueCurrontMonth request, CancellationToken cancellationToken)
            {
                var currentYear = DateTime.Now.Year;
                var currentMonth = DateTime.Now.Month;

                var totalRevenue = await _context.Order
                    .Where(o => o.OrderDate.Year == currentYear && o.OrderDate.Month == currentMonth && (o.OrderStatus == OrderStatus.PaymentReceived||o.OrderStatus==OrderStatus.Complete))
                    .ToListAsync();

                return totalRevenue.Sum(o => o.GetTotal());
            }
        }
    }
}
