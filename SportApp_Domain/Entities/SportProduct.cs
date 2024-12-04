using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class SportProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public List<SportProductVariant> Variants { get; set; }
        public List<ImageProduct> ImageProducts { get; set; }
    }
}
