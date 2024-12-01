using SportApp_Business.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.SportDtos
{
    public class SportDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CategoryDto> Categories { get; set; }
    }
}
