using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class SportFieldVoucher
    {
        public Guid SportFieldId { get; set; }
        public SportField SportField { get; set; }
        public Guid VoucherId { get; set; }
        public Voucher Voucher { get; set; }
        public int Quantity { get; set; }
    }
}
