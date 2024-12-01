using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Model.CartModel
{
    public class DeleteItemModel
    {
        public string BuyerId { get; set; }
        public Guid SportProductVariantId { get; set; }
        public int Quantity { get; set; }
    }
}
