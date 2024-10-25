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
        public string Description { get; set; }
        public string EndPoint { get; set; }
        [ForeignKey("FieldTypeId")]
        public Guid FieldTypeId { get; set; }
        public FieldType FieldType { get; set; }
        public List<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();
        public List<Image> Images { get; set; }
        public bool IsDeleted { get; set; } = false;
        [ForeignKey("OwnerId")]
        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }

        public List<Rating> Ratings { get; set; } = new List<Rating> { };
        [NotMapped]
        public decimal Stars
        {
            get => Ratings != null && Ratings.Any() ? (decimal)Ratings.Average(r => r.NumberOfStar) : 0;
            set { }
        }
    }
}
