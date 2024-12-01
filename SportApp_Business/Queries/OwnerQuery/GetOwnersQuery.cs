using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.OwnerDtos;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.OwnerQuery
{
    public class GetOwnersQuery : IQuery<List<OwnerDto>>
    {
        public class GetOwnerQueryHandler : IQueryHandler<GetOwnersQuery, List<OwnerDto>>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetOwnerQueryHandler(SportAppDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<OwnerDto>> Handle(GetOwnersQuery request,CancellationToken cancellationToken)
            {
                try
                {
                    var listOwner = await _context.Owner
                        .Include(o=>o.User)
                        .ToListAsync();
                    var result =  _mapper.Map<List<OwnerDto>>(listOwner);
                    return result;
                }
                catch(Exception ex) 
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
