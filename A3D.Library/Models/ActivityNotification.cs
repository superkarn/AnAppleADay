using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A3D.Library.Models
{
    public class ActivityNotification
    {
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public int NotificationTypeId { get; set; }
        public NotificationType NotificationType { get; set; }

        public bool IsEnabled { get; set; } = true;
        public string Recipient { get; set; }
    }
}
