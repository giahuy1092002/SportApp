using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Dtos.NotificationDtos
{
    public class ListUserNotitication
    {
        public List<UserNotificationDto> Notifications { get; set; }
        public int Count { get; set; }
    }
}
