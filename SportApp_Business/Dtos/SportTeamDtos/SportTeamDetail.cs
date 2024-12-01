using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.SportTeamDtos
{
    public class SportTeamDetail
    {
        public Guid Id { get; set; }
        public Guid LeaderId { get; set; }
        public string Sport { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Endpoint { get; set; }
        public string Address { get; set; }
        public string? Note { get; set; }
        public int CurrentMember { get; set; }
        public int LimitMember { get; set; }
        public string Avatar { get; set; }
        public List<MemberDto> Members { get; set; }
        public List<RequestSportTeam> Requests { get; set; }
    }
    public class MemberDto
    {
        public Guid SportTeamId { get; set; }
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinDate { get; set; }
        public string Role { get; set; }
    }
    public class RequestSportTeam
    {
        public string FirstName {  set; get; }
        public string LastName { set; get; }
        public string Avatar { get; set; }
        public Guid CustomerId { get; set; }
    }

}
