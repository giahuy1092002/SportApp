using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class BookingTimeSlot
    {
        public Guid BookingId { get; set; }
        public Booking Booking { get; set; }
        public Guid TimeSlotId { get; set; }
        public TimeSlot TimeSlot { get; set; }
    }
}
