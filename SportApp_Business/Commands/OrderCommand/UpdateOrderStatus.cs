using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Domain.Entities.OrderAggregate;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.OrderCommand
{
    public class UpdateOrderStatus : ICommand<bool>
    {
        public Guid OrderId { get; set; }
        public class CompleteOrderCommandHandler : ICommandHandler<UpdateOrderStatus, bool>
        {
            private readonly SportAppDbContext _context;
            public CompleteOrderCommandHandler(SportAppDbContext context)
            {
                _context = context;
            }
            public async Task<bool> Handle(UpdateOrderStatus request,CancellationToken cancellationToken)
            {
                var order = await _context.Order.FirstOrDefaultAsync(o=>o.Id == request.OrderId);
                if (order == null) throw new AppException("Đơn hàng không tồn tại");
                if(order.OrderStatus==OrderStatus.Pending)
                {
                    order.OrderStatus = OrderStatus.Transporting;
                }    
                else if(order.OrderStatus==OrderStatus.PaymentReceived)
                {
                    order.OrderStatus = OrderStatus.Transporting;
                }    
                else if( order.OrderStatus==OrderStatus.Transporting)
                {
                    order.OrderStatus = OrderStatus.Complete;
                }
                _context.Order.Update(order);
                _context.SaveChanges();
                return await Task.FromResult(true);
            }
        }
    }
}
