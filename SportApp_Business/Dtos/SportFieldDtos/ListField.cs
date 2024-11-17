using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.SportFieldDtos
{
    public class ListField
    {
        public List<SportFieldListDto> Fields { get; set; }
        public int Count { get; set; }
    }
}
