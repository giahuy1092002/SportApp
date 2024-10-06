using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Dto.UserDto
{
    public class SignUpDto
    {
        public string Email { get; set; }
    }
    public class SignUpRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
