using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.VoucherDtos
{
    public class VoucherDto
    {
        public Guid VoucherId { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long MinPrice { get; set; }
        public int PercentSale { get; set; }
        public long MaxSale { get; set; }
    }
}
