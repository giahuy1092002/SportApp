using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Model.SportEquipmentModel
{
    public class CreateSportEquipmentModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sport { get; set; }
        public Guid OwnerId { get; set; }
        public long RentPrice { get; set; }
        public long BuyPrice { get; set; }
        public int QuantityInStock { get; set; }
    }
}
