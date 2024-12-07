using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.ReportRequestDtos
{
    public class ReportRequestDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Reason { get; set; }
    }
    public class ListReportRequestDto
    {
        public List<ReportRequestDto> Requests { get; set; }
        public int Count { get; set; }
    }
}
