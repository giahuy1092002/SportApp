using SportApp_Business.Queries.SportFieldQuery;
using SportApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.SportFieldDtos
{
    public class SportFieldUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sport { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public List<TimeFrame> TimeFrames { get; set; }
        public List<Image> Images { get; set; }
    }
}
