using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.SpecDtos;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.SpecQuery
{
    public class GetSpecsQuery : IQuery<List<SpecDto>>
    {
        public class GetSpecsHandler : IQueryHandler<GetSpecsQuery, List<SpecDto>>
        {
            private readonly IMapper _mapper;
            private readonly SportAppDbContext _context;
            public GetSpecsHandler(SportAppDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;   
            }
            public async Task<List<SpecDto>> Handle(GetSpecsQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var listSpec = await _context.Spec
                        .Include(s=>s.User)
                        .Where(s=>s.IsDeleted==false)
                        .ToListAsync();
                    return _mapper.Map<List<SpecDto>>(listSpec);    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                } 
                
            }
        }
    }
}
