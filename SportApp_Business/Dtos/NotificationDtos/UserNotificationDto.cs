using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.NotificationDtos
{
    public class UserNotificationDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatAt { get; set; }
        public bool IsRead { get; set; }
        public string RelatedType { get; set; }
        public string EndPoint { get; set; }
    }
}
