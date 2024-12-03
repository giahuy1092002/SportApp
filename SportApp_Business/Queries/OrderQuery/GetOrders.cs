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
    public class GetOrders : IQuery<ListOrderAdminDto>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string? Status { get; set; }
        public class GetOrdersHandler : IQueryHandler<GetOrders, ListOrderAdminDto>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetOrdersHandler(SportAppDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ListOrderAdminDto> Handle(GetOrders request, CancellationToken cancellationToken)
            {
                var orders = await _context.Order.ToListAsync();
                if (!String.IsNullOrEmpty(request.Status)) orders = orders.Where(o => o.OrderStatus.ToString() == request.Status).ToList();
                var count = orders.Count;
                orders = orders.Skip((request.PageNumber-1)*request.PageSize).Take(request.PageSize).ToList();
                var list = _mapper.Map<List<OrderAdminDto>>(orders);
                return new ListOrderAdminDto
                {
                    Orders = list,
                    Count = count
                };
            }
        }
    }
}
