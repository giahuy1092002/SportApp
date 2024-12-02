using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.OrderDtos;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.OrderQuery
{
    public class GetByUser : IQuery<ListOrderDto>
    {
        public string Email { get; set; }
        public string? Status { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public class GetByUserHandler : IQueryHandler<GetByUser, ListOrderDto>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetByUserHandler(SportAppDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ListOrderDto> Handle(GetByUser request, CancellationToken cancellationToken)
            {
                var list = await _context.Order
                    .Include(o=>o.Items)
                        .ThenInclude(i=>i.SportProductVariant)
                            .ThenInclude(sv=>sv.Color)
                    .Include(o => o.Items)
                        .ThenInclude(i => i.SportProductVariant)
                            .ThenInclude(sv => sv.Size)
                    .Include(o => o.Items)
                        .ThenInclude(i => i.SportProductVariant)
                            .ThenInclude(sv => sv.SportProduct)
                                .ThenInclude(s=>s.ImageProducts)
                    .Where(o => o.BuyerId == request.Email).ToListAsync();
                if(!String.IsNullOrEmpty(request.Status)) list = list.Where(o => o.OrderStatus.ToString() == request.Status).ToList();
                int count = list.Count;
                list = list.Skip((request.PageNumber-1)*request.PageSize).Take(request.PageSize).ToList();
                var result = _mapper.Map<List<OrderDto>>(list);
                return new ListOrderDto
                {
                    Orders = result,
                    Count = count
                };
            }
        }
    }
}
