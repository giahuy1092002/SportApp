using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.TimeSlotDtos
{
    public class TimeSlotDto
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public long Price { get; set; }
        public bool Status { get; set; } = false;
    }
}
