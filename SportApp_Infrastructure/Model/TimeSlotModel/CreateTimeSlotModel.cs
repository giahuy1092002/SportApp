using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Model.TimeSlotModel
{
    public class CreateTimeSlotModel
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public long Price { get; set; }
        public Guid SportFieldId { get; set; }

    }
}
