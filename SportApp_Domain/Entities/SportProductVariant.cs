using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class SportProductVariant
    {
        public Guid Id { get; set; }
        public long Price { get; set; }
        [ForeignKey("SportProductId")]
        public Guid SportProductId { get; set; }
        public string EndPoint { get; set; }
        public int QuantityInStock { get; set; }
        public SportProduct SportProduct { get; set; }
        [ForeignKey("ColorId")]
        public Guid ColorId { get; set; }
        public Color Color { get; set; }
        public Guid SizeId { get; set; }
        public Size Size { get; set; }
        public List<SportProductRating> Ratings { get; set; }

    }
}
