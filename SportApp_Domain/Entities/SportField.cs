using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class SportField
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sport {  get; set; }
        public string Address { get; set; }

        [ForeignKey("FieldTypeId")]
        public Guid FieldTypeId { get; set; }
        public FieldType FieldType { get; set; }
        public ICollection<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();
        public ICollection<Image> Images { get; set; }
        public bool IsDeleted { get; set; } = false;
        [ForeignKey("OwnerId")]
        public Guid OwnerId { get; set; }
    }
}
