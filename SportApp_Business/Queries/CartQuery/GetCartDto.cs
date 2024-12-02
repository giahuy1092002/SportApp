using AutoMapper;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportApp_Business.Dtos.CartDtos;

namespace SportApp_Business.Queries.CartQuery
{
    public class GetCartDto : IQuery<CartDto>
    {
        public string BuyerId { get; set; }
        public class GetCartDtoHandler : IQueryHandler<GetCartDto, CartDto>
        {
            private readonly SportAppDbContext _context;
            private readonly IMapper _mapper;
            public GetCartDtoHandler(SportAppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CartDto> Handle(GetCartDto request, CancellationToken cancellationToken)
            {
                var cart = await _context.Cart
                    .Include(c => c.Items)
                        .ThenInclude(i => i.SportProductVariant)
                            .ThenInclude(sv => sv.SportProduct)
                                .ThenInclude(s=>s.ImageProducts)
                    .Include(c => c.Items)
                        .ThenInclude(i => i.SportProductVariant)
                            .ThenInclude(sv => sv.Color)
                    .Include(c => c.Items)
                        .ThenInclude(i => i.SportProductVariant)
                            .ThenInclude(sv => sv.Size)
                    .FirstOrDefaultAsync(c => c.BuyerId == request.BuyerId);
                if (cart == null) return null;
                var cartDto = new CartDto
                {
                    Id = cart.Id,
                    BuyerId = cart.BuyerId,
                    TotalPrice = cart.TotalPrice(),
                    TotalQuantity = cart.TotalQuantity(),
                    Items = _mapper.Map<List<CartItemDto>>(cart.Items)
                };
                return cartDto;
            }
        }
    }
}
