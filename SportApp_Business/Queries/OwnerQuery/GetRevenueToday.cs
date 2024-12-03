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
    public class GetRevenueToday : IQuery<long>
    {
        public Guid OwnerId { get; set; }
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

                var totalRevenue = await _context.Booking
                    .Include(b=>b.SportField)
                    .Where(b => b.CreatedDate >= today && b.CreatedDate < tomorrow && b.SportField.OwnerId == request.OwnerId)
                    .SumAsync(b => b.TotalPrice);

                return totalRevenue;
            }
        }
    }
}
