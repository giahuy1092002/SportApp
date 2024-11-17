using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Model.PaymentModel
{
    public class PaymentInformationModel
    {
        public string BookingId { get; set; }
        public string BookingType { get; set; }
        public long Amount { get; set; }
        public string BookingDescription { get; set; }
        public string Name { get; set; }
    }
}
