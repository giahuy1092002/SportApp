using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class SportTeam
    {
        public Guid Id { get; set; }
        public string Sport {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Endpoint { get; set; }
        public string Address { get; set; }
        public string? Note { get; set; }
        public int CurrentMember { get; set; } = 0;
        public int LimitMember { get; set; }
        public string? Avatar { get; set; }
        public string? PublicId { get; set; }
        public bool IsDelete { get; set; } = false;
        public List<UserSportTeam> Members { get; set; }
    }
}
