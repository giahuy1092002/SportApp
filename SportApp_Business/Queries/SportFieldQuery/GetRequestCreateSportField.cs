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

namespace SportApp_Business.Queries.SportFieldQuery
{
    public class GetRequestCreateSportField : IQuery<ListField>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public class GetRequestCreateSportFieldHandler : IQueryHandler<GetRequestCreateSportField,ListField>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetRequestCreateSportFieldHandler(SportAppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ListField> Handle(GetRequestCreateSportField request, CancellationToken cancellationToken)
            {
                var list = await _context.SportField
                    .Include(s=>s.Images)
                    .Include(s=>s.TimeSlots)
                    .Where(s=>s.IsAccept==false)
                    .ToListAsync();
                int count = list.Count;
                list = list.Skip((request.PageNumber-1)*request.PageSize).Take(request.PageSize).ToList();
                var result = _mapper.Map<List<SportFieldListDto>>(list);
                return new ListField
                {
                    Fields = result,
                    Count = count
                };

            }
        }
    }
}
