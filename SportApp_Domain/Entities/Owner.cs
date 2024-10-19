using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class Owner
    {
        public Guid OwnerId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<SportField> SportFields { get; set; } = new List<SportField>();
        public List<Voucher> Vouchers { get; set; } = new List<Voucher> {};  

    }
}
