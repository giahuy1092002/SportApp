
using SportApp_Domain.Entities;

namespace SportApp_Infrastructure.Model.BookingModel
{
    public class CreateBookingModel
    {
        public string Name { get; set; }
        public Guid CustomerId { get; set; }
        public Guid SportFieldId { get; set; }
        public long TotalPrice { get; set; }
        public string? Note { get; set; }
        public Guid? SpecId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
