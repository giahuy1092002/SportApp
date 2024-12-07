using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class SportProductRating
    {
        public Guid Id { get; set; }
        public string SportProductVariantName { get; set; }
        public string SizeValue { get; set; }
        public string ColorName { get; set; }
        public int StartRating { get; set; }
        public string Comment { get; set; }
        [ForeignKey("SportProductVariantId")]
        public Guid SportProductVariantId { get; set; }
        public SportProductVariant SportProductVariant { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
