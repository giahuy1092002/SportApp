using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class UserInfo
    {
        [Key]
        [Column("InfoId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid InfoId { get; set; }
        public string? Avatar { get; set; }

        [Column("FirstName")]
        public string? FirstName { get; set; }

        [Column("LastName")]
        public string? LastName { get; set; }

        [Column("Gender")]
        public string? Gender { get; set; }

        [Column("DateOfBirth")]
        public DateTime? DateOfBirth { get; set; }
        [Column("PhoneNumber")]
        public string? PhoneNumber { get; set; }
        public string? Location { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }

}
