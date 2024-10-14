using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Model.UserModel
{
    public class UpdateAvatarModel
    {
        public Guid UserId { get; set; }
        public string Avatar {  get; set; }
    }
}
