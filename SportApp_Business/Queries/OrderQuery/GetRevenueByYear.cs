using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Queries.OwnerQuery;
using SportApp_Domain.Entities.OrderAggregate;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.OrderQuery
{
    public class GetRevenueByYear : IQuery<List<MonthlyRevenueDto>>
    {
        public int Year { get; set; }
        public class GetRevenueByYearHandler : IQueryHandler<GetRevenueByYear, List<MonthlyRevenueDto>>
        {
            private readonly SportAppDbContext _context;
            public GetRevenueByYearHandler(SportAppDbContext context)
            {
                _context = context;
            }
            public async Task<List<MonthlyRevenueDto>> Handle(GetRevenueByYear request,CancellationToken cancellationToken)
            {
                var revenue = await _context.Order
                            .Where(b => b.OrderDate.Year == request.Year && (b.OrderStatus == OrderStatus.PaymentReceived ||b.OrderStatus == OrderStatus.Complete))
                            .GroupBy(b => b.OrderDate.Month)
                            .Select(g => new { Month = g.Key, TotalRevenue = g.Sum(b => b.GetTotal())})
                            .ToListAsync();
                var monthlyRevenue = Enumerable.Range(1, 12)
                    .Select(month => new MonthlyRevenueDto
                    {
                        Month = month,
                        TotalRevenue = revenue.FirstOrDefault(r => r.Month == month)?.TotalRevenue ?? 0
                    })
                    .ToList();

                return monthlyRevenue;
            }
        }
    }
}
