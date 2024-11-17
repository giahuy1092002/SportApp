using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class ImageProduct
    {
        public Guid Id { get; set; }
        [ForeignKey("SportProductVariantId")]
        public Guid SportProductVariantId { get; set; }
        public SportProductVariant ProductVariant { get; set; }
        public string PictureUrl { get; set; }
        public string PublicId { get; set; }
        public string Type { get; set; }
    }
}
