using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Business.Dtos.CartDtos;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.CartQuery
{
    public class GetCart : IQuery<Cart>
    {
        public string BuyerId { get; set; }
        public class GetCartHandler : IQueryHandler<GetCart,Cart>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetCartHandler(SportAppDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Cart> Handle(GetCart request, CancellationToken cancellationToken)
            {
                var cart = await _context.Cart
                    .Include(c=>c.Items)
                        .ThenInclude(i=>i.SportProductVariant)
                            .ThenInclude(sv=>sv.SportProduct)
                    .Include(c => c.Items)
                        .ThenInclude(i => i.SportProductVariant)
                            .ThenInclude(sv => sv.Color)
                    .Include(c => c.Items)
                        .ThenInclude(i => i.SportProductVariant)
                            .ThenInclude(sv => sv.Size)
                    .FirstOrDefaultAsync(c=>c.BuyerId==request.BuyerId);
                return cart;
           }
        }
    }
}
