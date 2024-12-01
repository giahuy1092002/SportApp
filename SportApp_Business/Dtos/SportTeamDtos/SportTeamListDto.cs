using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.SportTeamDtos
{
    public class SportTeamListDto
    {
        public List<SportTeamDto> SportTeams { get; set; }
        public int Count { get; set; }
    }
}
