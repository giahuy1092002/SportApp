using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Domain.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }
        public Guid? RelatedId { get; set; } //Event, SportFied, System, SportTeam
        public string RelatedType { get; set; }
        public string? EndPoint {  get; set; }
        
    }   
    public enum NotifyType
    {
        Event,
        SportField,
        System,
        SportTeam
    }
}
