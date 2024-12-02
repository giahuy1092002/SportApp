using SportApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.SportProductDtos
{
    public class SportProductUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ColorName { get; set; }
        public Guid ColorId { get; set; }
        public List<SizeDto> Sizes { get; set; }
        public List<ImageProduct> ImageProducts { get; set; }
    }
}
