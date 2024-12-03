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
    public class GetTotalRevenue : IQuery<long>
    {
        public Guid OwnerId { get; set; }
        public class GetTotalRevenueHandler : IQueryHandler<GetTotalRevenue,long>
        {
            private readonly SportAppDbContext _context;
            public GetTotalRevenueHandler(SportAppDbContext context)
            {
                _context = context;
            }
            public async Task<long> Handle(GetTotalRevenue request, CancellationToken cancellationToken)
            {
                var listBooking = await _context.Booking
                    .Include(b=>b.SportField)
                    .Where(s => s.SportField.OwnerId == request.OwnerId).ToListAsync();
                var revenue = listBooking.Sum(s => s.TotalPrice);
                return revenue;
            }
        }
    }
}
