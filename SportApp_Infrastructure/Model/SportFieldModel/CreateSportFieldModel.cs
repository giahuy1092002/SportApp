using SportApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Model.SportFieldModel
{
    public class CreateSportFieldModel
    {
        public string Name { get; set; }
        public string Sport {  get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public Guid FieldTypeId { get; set; }
        public Guid OwnerId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public List<TimeFramePrice> Prices { get; set; } = new List<TimeFramePrice>();
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
