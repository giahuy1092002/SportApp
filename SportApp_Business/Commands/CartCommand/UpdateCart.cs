using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.CartCommand
{
    public class UpdateCart : ICommand<bool>
    {
        public string BuyerId { get; set; }
        public string Email { get; set; }
        public class UpdateCartHandler : ICommandHandler<UpdateCart, bool>
        {
            private readonly SportAppDbContext _context;
            public UpdateCartHandler(SportAppDbContext context)
            {
                _context = context;
            }
            public async Task<bool> Handle(UpdateCart request, CancellationToken cancellationToken)
            {
                var cart = await _context.Cart.FirstOrDefaultAsync(c=>c.BuyerId==request.BuyerId);
                cart.BuyerId = request.Email;
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
