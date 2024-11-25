using AutoMapper;
using SportApp_Business.Common;
using SportApp_Business.Dtos.CartDtos;
using SportApp_Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Queries.CartQuery
{
    public class GetUserCart : IQuery<CartDto>
    {
        public string Email { get; set; }
        public class GetUserCartHandler : IQueryHandler<GetUserCart,CartDto>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetUserCartHandler(SportAppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CartDto> Handle(GetUserCart request, CancellationToken cancellationToken)
            {
                var cart = await _context.Cart
                    .Include(c => c.Items)
                        .ThenInclude(i => i.SportProductVariant)
                            .ThenInclude(sv => sv.SportProduct)
                    .Include(c => c.Items)
                        .ThenInclude(i => i.SportProductVariant)
                            .ThenInclude(sv => sv.Color)
                    .Include(c => c.Items)
                        .ThenInclude(i => i.SportProductVariant)
                            .ThenInclude(sv => sv.Size)
                    .FirstOrDefaultAsync(c => c.BuyerId == request.Email);
                if (cart == null) return null;
                var cartDto = new CartDto
                {
                    TotalPrice = cart.TotalPrice(),
                    TotalQuantity = cart.TotalQuantity(),
                    Items = _mapper.Map<List<CartItemDto>>(cart.Items)
                };
                return cartDto;
            }
        }
    }
}
