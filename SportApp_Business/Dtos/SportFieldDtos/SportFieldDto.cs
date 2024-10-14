using Microsoft.Identity.Client;
using SportApp_Business.Dtos.TimeSlotDtos;
using SportApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.SportFieldDtos
{
    public class SportFieldDto
    {
        public string Name { get; set; }
        public string Sport { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public long MinPrice { get; set; }
        public long MaxPrice { get; set; }
        public int NumberOfReviews { get; set; }
        public decimal RatioAccept {  get; set; }
        public int NumberOfBooking { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
