using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.OwnerQuery
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
            public async Task<List<MonthlyRevenueDto>> Handle(GetRevenueByYear request, CancellationToken cancellationToken)
            {
                var revenue = await _context.Booking
                            .Where(b => b.CreatedDate.Year == request.Year)
                            .GroupBy(b => b.CreatedDate.Month)
                            .Select(g => new { Month = g.Key, TotalRevenue = g.Sum(b => b.TotalPrice) })
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
    public class MonthlyRevenueDto
    {
        public int Month { get; set; }
        public long TotalRevenue { get; set; }
    }
}
