using SportApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Model.CartModel
{
    public class AddItemModel
    {
        public SportProductVariant SportProductVariant { get; set; }
        public int Quantity { get; set; }
        public string BuyerId { get; set; }
    }
}
