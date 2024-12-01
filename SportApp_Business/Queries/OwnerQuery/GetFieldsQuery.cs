using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.SportFieldDtos;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.OwnerQuery
{
    public class GetFieldsQuery : IQuery<List<SportFieldsOwner>>
    {
        public Guid OwnerId { get; set; }
        public class GetFieldsHandler : IQueryHandler<GetFieldsQuery, List<SportFieldsOwner>>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetFieldsHandler(SportAppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;   
            }
            public async Task<List<SportFieldsOwner>> Handle(GetFieldsQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var listFields = await _context.SportField
                         .Include(s => s.Ratings)
                         .Include(s => s.TimeSlots)
                         .Include(s => s.Images)
                        .Where(s=>s.OwnerId==request.OwnerId)
                        .ToListAsync();
                    return _mapper.Map<List<SportFieldsOwner>>(listFields);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                } 
                
            }
        }
    }
}
