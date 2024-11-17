using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Model.SportTeamModel
{
    public class UpdateSportTeamModel
    {
        public Guid SportTeamId { get; set; }
        public string Sport {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string? Note { get; set; }
        public int LimitMember { get; set; }
    }
}
