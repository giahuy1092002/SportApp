using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class UserSportTeam
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid SportTeamId { get; set; }
        public SportTeam SportTeam { get; set; }
        public DateTime JoinDate { get; set; } = DateTime.Now;
        public RoleType Role { get; set; }
        public bool IsAccept { get; set; } = false;
    }
    public enum RoleType
    {
        Leader,
        Member
    }
}
