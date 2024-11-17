using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.SpecDtos
{
    public class SpecDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Avatar { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? DateOfBirth { get;set; }
        public string? Skills { get; set; }
    }
}
