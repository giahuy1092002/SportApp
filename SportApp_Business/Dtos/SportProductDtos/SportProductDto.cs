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
        public Guid SportProductId { get; set; }
        public string CategoryName { get; set; }
        public string Sport {  get; set; }
        public string PictureUrl { get; set; }
        public string EndPoint {  get; set; }
        public List<ColorEndpoint> ColorEndpoints { get; set; }
        public long Price { get; set; }
        public string Name { get; set; }
    }
    public class ColorEndpoint
    {
        public string EndPoint { get; set; }
        public string ColorCode { get; set; }
        public bool IsSelected { get; set; }
        public List<string> Sizes { get; set; }
    }
       
}
