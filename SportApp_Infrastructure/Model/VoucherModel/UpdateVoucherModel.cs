using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Model.VoucherModel
{
    public class UpdateVoucherModel
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Quantity { get; set; }
        public long MinPrice { get; set; }
        public int PercentSale { get; set; }
        public long MaxSale { get; set; }
        public Guid VoucherId { get; set; }
    }
}
