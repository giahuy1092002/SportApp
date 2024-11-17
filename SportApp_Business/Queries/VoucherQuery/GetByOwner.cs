using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.VoucherDtos;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.VoucherQuery
{
    public class GetByOwner : IQuery<VoucherListDto>
    {
        public Guid OwnerId { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public class GetByOwnerHandler : IQueryHandler<GetByOwner, VoucherListDto>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetByOwnerHandler(SportAppDbContext context,IMapper mapper)
            {
                _context = context;          
                _mapper = mapper;
            }
            public async Task<VoucherListDto> Handle(GetByOwner request, CancellationToken cancellationToken)
            {
                var list = await _context.Vouchers.Where(v => v.OwnerId == request.OwnerId).ToListAsync();
                int count = list.Count;
                list = list.Skip((request.PageNumber-1)*request.PageSize).Take(request.PageSize).ToList();
                var result = _mapper.Map<List<VoucherDtoList>>(list);
                return new VoucherListDto
                {
                    VoucherList = result,
                    Count = count
                };
            }
        }
    }
}
