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
        [Required]
        public Guid InfoId { get; set; }

        [Column("RegistrationDate")]
        public DateTime? RegistrationDate { get; set; }

        [Column("ActiveStatus")]
        public bool? ActiveStatus { get; set; }

        [Column("IsDeleted")]
        public bool IsDeleted { get; set; }

        [ForeignKey("InfoId")]
        public virtual UserInfo? UserInfo { get; set; }

    }
}
