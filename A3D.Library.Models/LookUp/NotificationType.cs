using System.Collections.Generic;

namespace A3D.Library.Models.LookUp
{
    public class NotificationType : BaseLookUpModel
    {
        public static IEnumerable<NotificationType> GetValues()
        {
            yield return NotificationType.Email;
            yield return NotificationType.Sms;
            yield return NotificationType.Browser;
        }

        public static readonly NotificationType Email = new NotificationType()
        {
            Id = 1,
            Name = "Email",
            Description = "Send notification to an email address"
        };

        public static readonly NotificationType Sms = new NotificationType()
        {
            Id = 2,
            Name = "Sms",
            Description = "Send notification to a Sms device"
        };

        public static readonly NotificationType Browser = new NotificationType()
        {
            Id = 3,
            Name = "Browser",
            Description = "Send notification via Broser Notification"
        };
    }
}
