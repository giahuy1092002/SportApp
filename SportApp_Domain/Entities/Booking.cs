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
        [ForeignKey("SportFieldId")]
        public Guid SportFieldId { get; set; }
        public SportField SportField { get; set; }
        public long TotelPrice { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime BookingDate { get; set; }
        public List<BookingTimeSlot> TimeSlotBookeds { get; set; } = new List<BookingTimeSlot>();
        public string? Note { get; set; }
        [ForeignKey("SpecId")]
        public Guid? SpecId { get; set; }
        public Spec Spec { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
