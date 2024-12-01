using SportApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Model.NotificationModel
{
    public class CreateNotificationModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid? RelatedId { get; set; } //Event, SportFied, System
        public string RelatedType { get; set; }
    }
}
