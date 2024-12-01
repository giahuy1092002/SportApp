using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.SportFieldDtos
{
    public class SportFieldListDto
    {
        public Guid Id {  get; set; }
        public string Name { get; set; }
        public string EndPoint { get; set; }
        public string Sport {  get; set; }
        public string Address { get; set; }
        public string PriceRange { get; set; }
        public decimal Stars { get; set; }
        public int NumberOfReviews { get; set; }
        public string PictureUrl { get; set; }
        public string Distance { get; set; } = "Chưa xác định";
        public string Duration { get; set; } = "Chưa xác định";
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
