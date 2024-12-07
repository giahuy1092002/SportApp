using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.OwnerQuery
{
    public class GetRevenueCurrentMonth : IQuery<double>
    {
        public Guid OwnerId { get; set; }
        public class GetRevenueCurrentMonthHandler : IQueryHandler<GetRevenueCurrentMonth, double>
        {
            private readonly SportAppDbContext _context;
            public GetRevenueCurrentMonthHandler(SportAppDbContext context)
            {
                _context = context;
            }

            public async Task<double> Handle(GetRevenueCurrentMonth request, CancellationToken cancellationToken)
            {
                var currentYear = DateTime.Now.Year;
                var currentMonth = DateTime.Now.Month;

                var totalRevenue = await _context.Booking
                    .Include(b => b.SportField)
                    .Where(b => b.CreatedDate.Year == currentYear &&
                                b.CreatedDate.Month == currentMonth &&
                                b.SportField.OwnerId == request.OwnerId &&
                                (b.Status == BookingStatus.Completed ||
                                 b.Status == BookingStatus.PaymentReceived ||
                                 (b.Status == BookingStatus.Rejected && b.IsRight==true)))
                    .SumAsync(b => b.Status == BookingStatus.Rejected ? b.TotalPrice * 0.3 : b.TotalPrice);

                return totalRevenue;

            }
        }
    }
}
