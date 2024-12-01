using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.SportProductDtos
{
    public class SportProductListDto
    {
        public List<SportProductDto> Products { get; set; }
        public int Count { get; set; }
    }
}
