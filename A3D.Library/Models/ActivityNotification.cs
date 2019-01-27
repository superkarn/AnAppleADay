using A3D.Library.Models.LookUp;

namespace A3D.Library.Models
{
    public class ActivityNotification : BaseModel
    {
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public int NotificationTypeId { get; set; }
        public NotificationType NotificationType { get; set; }

        public bool IsEnabled { get; set; } = true;
        public string Recipient { get; set; }
    }
}
