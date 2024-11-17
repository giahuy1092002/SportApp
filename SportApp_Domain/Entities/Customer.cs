using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string? Interest {  get; set; }
        public long? Height { get; set; }
        public long? Weight { get; set; }
        public string? Skills { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<UserSportTeam> Teams { get; set; }
    }
}
