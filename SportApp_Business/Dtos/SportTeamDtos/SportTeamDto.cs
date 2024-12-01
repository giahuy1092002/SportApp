using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.SportTeamDtos
{
    public class SportTeamDto
    {
        public Guid Id { get; set; }
        public Guid LeaderId { get; set; }
        public string LeaderName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CurrentMember { get; set; }
        public int LimitMember { get; set; }
        public string Sport {  get; set; }
        public string Endpoint { get; set; }
        public string Avatar { get; set; }
        public string Description { get; set; }
        public string? Note { get; set; }
    }
}
