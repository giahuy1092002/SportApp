using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.CustomerDtos
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
    public class CustomerDtoDetail
    {
        public string? Interest { get; set; }
        public long? Height { get; set; }
        public long? Weight { get; set; }
        public string? Skills { get; set; }
    }
}
