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
        public Guid ColorId { get; set; }
        public Color Color { get; set; }
        public Guid SportProductId { get; set; }
        public SportProduct SportProduct { get; set; }
        public string PictureUrl { get; set; }
        public string PublicId { get; set; }
        public string Type { get; set; }
    }
}
