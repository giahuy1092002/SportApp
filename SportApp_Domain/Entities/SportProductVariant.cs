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
        public SportProduct SportProduct { get; set; }
        [ForeignKey("ColorId")]
        public Guid ColorId { get; set; }
        public Color Color { get; set; }
        public List<Size> Sizes { get; set; }
        public List<ImageProduct> ImageProducts { get; set; }
    }
}
