using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.SportFieldQuery
{
    public class GetSportFieldsByOwner : IQuery<int>
    {
        public Guid OwnerId { get; set; }
        public class GetSportFieldByOwnerHandler : IQueryHandler<GetSportFieldsByOwner,int>
        {
            private readonly SportAppDbContext _context;
            public GetSportFieldByOwnerHandler(SportAppDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(GetSportFieldsByOwner request, CancellationToken cancellationToken)
            {
                var list = await _context.SportField.Where(s => s.OwnerId == request.OwnerId).ToListAsync();
                return list.Count;
            }
        }
    }
}
