using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Model.CustomerModel
{
    public class CreateCustomerModel
    {
        public Guid UserId { get; set; }
        public string? Interest { get; set; }
        public long? Height { get; set; }
        public long? Weight { get; set; }
        public string? Skills { get; set; }
    }
}
