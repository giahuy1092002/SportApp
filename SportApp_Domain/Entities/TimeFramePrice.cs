using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class TimeFramePrice
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public long Price { get; set; }
    }
}
