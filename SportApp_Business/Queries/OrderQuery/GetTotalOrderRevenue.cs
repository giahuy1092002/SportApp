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
    public class GetTotalOrderRevenue : IQuery<long>
    {
        public class GetTotalOrderRevenueHandler : IQueryHandler<GetTotalOrderRevenue,long>
        {
            private readonly SportAppDbContext _context;
            public GetTotalOrderRevenueHandler(SportAppDbContext context)
            {
                _context = context;
            }
            public async Task<long> Handle(GetTotalOrderRevenue request, CancellationToken cancellationToken)
            {
                var revenue = await _context.Order
                    .Where(o=>o.OrderStatus==OrderStatus.PaymentReceived || o.OrderStatus == OrderStatus.Complete)
                    .ToListAsync();
                return revenue.Sum(o=>o.GetTotal());
            }
        }
    }
}
