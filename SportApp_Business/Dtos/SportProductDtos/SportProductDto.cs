using SportApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.SportProductDtos
{
    public class SportProductDto
    {
        public string PictureUrl { get; set; }
        public List<ColorEndpoint> ColorEndpoints { get; set; }
        public long Price { get; set; }
        public string Name { get; set; }
    }
    public class ColorEndpoint
    {
        public string EndPoint { get; set; }
        public string ColorCode { get; set; }
    }
       
}
