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
    public class GetCustomers : IQuery<int>
    {
        public Guid OwnerId { get; set; }
        public class GetCustomersHandler : IQueryHandler<GetCustomers,int>
        {
            private readonly SportAppDbContext _context;
            public GetCustomersHandler(SportAppDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(GetCustomers request, CancellationToken cancellationToken)
            {
                var list = await _context.Booking.Where(b => b.SportField.OwnerId == request.OwnerId).ToListAsync();
                var listCustomer = list
                .GroupBy(c => c.CustomerId)
                .Select(group => group.First()) 
                .ToList();
                return listCustomer.Count;
            }
        }
    }
}
