using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class UserNotification
    {
        public Guid NotificationId { get; set; }
        public Notification Notification { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public bool IsRead { get; set; } = false;
    }
}
