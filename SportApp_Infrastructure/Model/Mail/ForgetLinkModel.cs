using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Model.Mail
{
    public class ForgetLinkModel
    {
        public string Email { get; set; }
        public string Link { get; set; }
    }
}
