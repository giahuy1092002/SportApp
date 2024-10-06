using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid SportFieldId { get; set; }
        public long TotelPrice { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Note { get; set; }
        [ForeignKey("SpecId")]
        public Guid? SpecId { get; set; }
        public Spec Spec { get; set; }
    }
}
