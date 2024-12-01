using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public DateTime? RegistrationDate { get; set; }
        public bool? ActiveStatus { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Location { get; set; }
        public string? Avatar { get; set; }
        public string? PublicId { get; set; }

    }
}
