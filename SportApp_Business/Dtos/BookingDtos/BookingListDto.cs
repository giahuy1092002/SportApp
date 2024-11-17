using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.BookingDtos
{
    public class BookingListDto
    {
        public List<BookingDto> BookingList { get;set; }
        public int Count { get; set; }
    }
}
