
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
        public DateTime BookingDate { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
