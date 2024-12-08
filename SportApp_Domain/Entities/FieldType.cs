using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class FieldType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("SportId")]
        public Guid SportId { get; set; }
        public Sport Sport { get; set; }
    }
}
