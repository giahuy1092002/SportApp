using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.OwnerDtos
{
    public class OwnerDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
    public class OwnerListDto
    {
        public List<OwnerDto> Owners { get; set; }
        public int Count { get; set; }
    }
}
