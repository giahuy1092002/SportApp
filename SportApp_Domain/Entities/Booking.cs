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
        public long TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime BookingDate { get; set; }
        public BookingStatus Status { get; set; } = BookingStatus.Pending;
        public string? Note { get; set; }
        public List<BookingTimeSlot> TimeSlotBookeds { get; set; } = new List<BookingTimeSlot>();
        [ForeignKey("CustomerId")]
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("SportFieldId")]
        public Guid SportFieldId { get; set; }
        public SportField SportField { get; set; }
        public bool IsRemind { get; set; }
        public string TimeFrameBooked { get; set; }
        public Guid? VoucherId { get; set; }
    }
    public enum BookingStatus
    {
        Pending,
        PaymentReceived,
        PaymentFailed,
        Reject
    }
}
