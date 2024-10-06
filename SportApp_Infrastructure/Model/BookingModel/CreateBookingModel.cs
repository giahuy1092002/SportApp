using SportApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
