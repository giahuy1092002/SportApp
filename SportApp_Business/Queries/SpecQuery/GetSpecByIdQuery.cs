using MediatR;
using SportApp_Business.Common;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.SpecQuery
{
    public class GetSpecByIdQuery : IQuery<Unit>
    {
        public Guid SpecId { get; set; }
        public class GetSpecByIdHandler : IQueryHandler<GetSpecByIdQuery, Unit>
        {
            private readonly SportAppDbContext _context;
            public GetSpecByIdHandler(SportAppDbContext context)
            {
                _context = context;
            }

            public Task<Unit> Handle(GetSpecByIdQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
