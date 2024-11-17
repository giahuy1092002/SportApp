using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class Voucher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("OwnerId")]
        public Guid? OwnerId { get; set; }
        public Owner Owner { get; set; }
        public long MinPrice { get; set; }
        public int PercentSale {  get; set; }
        public long MaxSale { get; set; }

    }
}
