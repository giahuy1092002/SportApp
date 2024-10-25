using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.SportFieldDtos
{
    public class SportFieldListDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public long MinPrice { get; set; }
        public long MaxPrice { get; set; }
        public decimal Stars { get; set; }
        public int NumberOfReviews { get; set; }
        public string PictureUrl { get; set; }
    }
}
