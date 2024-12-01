using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.NotifyQuery
{
    public class GetCountNotify : IQuery<int>
    {
        public Guid UserId { get; set; }
        public class GetCountNotifyHandler : IQueryHandler<GetCountNotify,int>
        {
            private readonly SportAppDbContext _context;
            public GetCountNotifyHandler(SportAppDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(GetCountNotify request, CancellationToken cancellationToken)
            {
                var notify = await _context.UserNotifications.Where(u => u.UserId == request.UserId && u.IsRead==false).ToListAsync();
                return notify.Count;
            }
        }
    }
}
