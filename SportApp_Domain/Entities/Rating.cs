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
        //public decimal NumberOfStar {  get; set; }
        [ForeignKey("SportFieldId")] 
        
        public Guid SportFieldId { get; set; }
    }
}
