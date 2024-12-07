using Microsoft.EntityFrameworkCore;
using SportApp_Business.Common;
using SportApp_Domain.Entities.OrderAggregate;
using SportApp_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportApp_Business.Commands.OrderCommand
{
    public class RejectOrder : ICommand<bool>
    {
        public Guid OrderId { get; set; }
        public string Reason { get; set; }
        public class RejectOrderHandler : ICommandHandler<RejectOrder,bool>
        {
            private readonly SportAppDbContext _context;
            public RejectOrderHandler(SportAppDbContext context)
            {
                _context = context;
            }
            public async Task<bool> Handle(RejectOrder request, CancellationToken cancellationToken)
            {
                try
                {
                    var order = await _context.Order.FirstOrDefaultAsync(o => o.Id == request.OrderId);
                    if (order == null) throw new AppException("Đơn hàng không tồn tại");
                    if (order.OrderStatus == OrderStatus.Pending || order.OrderStatus == OrderStatus.PaymentReceived)
                    {
                        order.OrderStatus = OrderStatus.Rejected;
                    }
                    _context.Order.Update(order);
                    _context.SaveChanges();
                    return await Task.FromResult(true);
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
