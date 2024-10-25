using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.SportEquipmentDtos
{
    public class SportEquipmentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long RentPrice { get; set; }
        public long BuyPrice { get; set; }
    }
}
