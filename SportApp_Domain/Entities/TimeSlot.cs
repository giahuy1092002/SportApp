using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class TimeSlot
    {
        public Guid Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public long Price { get; set; }
        [ForeignKey("SportFieldId")]
        public Guid SportFieldId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
