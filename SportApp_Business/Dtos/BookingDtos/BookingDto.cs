using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.BookingDtos
{
    public class BookingDto
    {
        public Guid Id { get; set; }
        public string Name {  get; set; }
        public string SportFieldName { get; set; }
        public string Address { get; set; }
        public string[] TimeSlotBooked { get; set; }
        public DateTime BookingDate { get; set; }
        public long TotalPrice { get; set; }
        public string Status { get; set; }
        public bool IsRating { get; set; }
        public Guid SportFieldId { get; set; }
        public string EndPoint {  get; set; }
    }
}
