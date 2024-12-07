using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities.OrderAggregate
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid SportProductVariantId { get; set; }
        public SportProductVariant SportProductVariant { get; set; }
        public long Price { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public bool IsRating { get; set; } = false;
    }
}
