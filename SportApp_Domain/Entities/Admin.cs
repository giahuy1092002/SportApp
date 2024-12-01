using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class Admin
    {
        public Guid Id  { get; set; }
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
