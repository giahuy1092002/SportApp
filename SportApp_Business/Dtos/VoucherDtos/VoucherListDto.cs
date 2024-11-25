using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.VoucherDtos
{
    public class VoucherListDto
    {
        public List<VoucherDto> VoucherList { get; set; }
        public int Count { get; set; }
    }
}
