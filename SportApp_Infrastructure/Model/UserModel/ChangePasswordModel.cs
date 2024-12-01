using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Model.UserModel
{
    public class ChangePasswordModel
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
