using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities.OrderAggregate
{
    public class Order
    {
        public Guid Id { get; set; }
        public string BuyerId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public List<OrderItem> Items { get; set;} = new List<OrderItem>();
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public long SubTotal { get; set; }
        public long DeliveryFee { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public long GetTotal()
        {
            return DeliveryFee + SubTotal;
        }
    }
}
