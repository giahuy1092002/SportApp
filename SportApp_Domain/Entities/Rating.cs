using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class Rating
    {
        public Guid Id  { get; set; }
        public string? Comment { get; set; }
        public int NumberOfStar {  get; set; }
        public Guid SportFieldId { get; set; }
        public SportField SportField { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
