using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Model.PaymentModel
{
    public class PaymentResponseModel
    {
        public string BookingDescription { get; set; }
        public string BookingType { get; set; }
        public string TransactionId { get; set; }
        public string BookingId { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentId { get; set; }
        public bool Success { get; set; }
        public string Token { get; set; }
        public string VnPayResponseCode { get; set; }
    }
}
