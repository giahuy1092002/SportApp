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
    public class GetVouchers : IQuery<VoucherListDto>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public class GetVouchersHandler : IQueryHandler<GetVouchers, VoucherListDto>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetVouchersHandler(SportAppDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<VoucherListDto> Handle(GetVouchers request,CancellationToken cancellationToken)
            {
                var list = await _context.Vouchers.ToListAsync();
                int count = list.Count;
                list = list.Skip((request.PageNumber-1)*request.PageSize).Take(request.PageSize).ToList();
                var listDto = _mapper.Map<List<VoucherDto>>(list);
                return new VoucherListDto
                {
                    Count = count,
                    VoucherList = listDto
                };
            }

        }
    }
}
