using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.BanListDtos
{
    public class BanListDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public string Reason { get; set; }
        public int Duration { get; set; }
    }
    public class ListBanListDto
    {
        public List<BanListDto> BanLists { get; set; }
        public int Count { get; set; }
    }
}
