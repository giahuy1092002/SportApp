using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.BanListDtos;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries
{
    public class GetBanLists : IQuery<ListBanListDto>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public class GetBanListsHandler : IQueryHandler<GetBanLists, ListBanListDto>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetBanListsHandler(SportAppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;   
            }
            public async Task<ListBanListDto> Handle(GetBanLists request, CancellationToken cancellationToken)
            {
                var banlists = await _context.BanList
                    .Include(b=>b.User)
                    .ToListAsync();
                var list = _mapper.Map<List<BanListDto>>(banlists);
                var count = list.Count;
                list = list.Skip((request.PageNumber-1)*request.PageSize).Take(request.PageSize).ToList();
                return new ListBanListDto
                {
                    BanLists = list,
                    Count = count
                };

            }
        }
    }
}
