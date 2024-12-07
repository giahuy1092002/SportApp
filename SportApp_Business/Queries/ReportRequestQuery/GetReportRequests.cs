using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.ReportRequestDtos;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.ReportRequestQuery
{
    public class GetReportRequests : IQuery<ListReportRequestDto>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public class GetReportRequestsHandler : IQueryHandler<GetReportRequests, ListReportRequestDto>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetReportRequestsHandler(SportAppDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ListReportRequestDto> Handle(GetReportRequests request,CancellationToken cancellationToken)
            {
                var list = await _context.ReportRequest.ToListAsync();
                var count = list.Count;
                list = list.Skip((request.PageNumber-1)*request.PageSize).Take(request.PageSize).ToList();
                var requests = _mapper.Map<List<ReportRequestDto>>(list);
                return new ListReportRequestDto
                {
                    Requests = requests,
                    Count = count
                };
            }
        }
    }
}
