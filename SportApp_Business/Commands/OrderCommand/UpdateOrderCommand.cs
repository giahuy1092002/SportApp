using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Domain.Entities;
using SportApp_Domain.Entities.OrderAggregate;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.OrderCommand
{
    public class UpdateOrderCommand : ICommand<bool>
    {
        public Guid OrderId { get; set; }
        public class UpdateOrderHandler : ICommandHandler<UpdateOrderCommand,bool>
        {
            private readonly SportAppDbContext _context;
            public UpdateOrderHandler(SportAppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
            {
                var order = await _context.Order.FirstOrDefaultAsync(b => b.Id == request.OrderId);
                order.OrderStatus = OrderStatus.PaymentReceived;
                _context.Order.Update(order);
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
        }
    }
}
