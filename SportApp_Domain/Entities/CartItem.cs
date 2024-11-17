using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("SportProductVariantId")]
        public Guid SportProductVariantId { get; set; }
        public SportProductVariant SportProductVariant { get; set; }


    }
}
