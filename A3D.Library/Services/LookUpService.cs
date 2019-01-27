using A3D.Library.Models;
using A3D.Library.Models.LookUp;
using A3D.Library.Services.Interfaces;
using System.Collections.Generic;

namespace A3D.Library.Services
{
    public class LookUpService : ILookUpService
    {
        public IDictionary<string,IEnumerable<BaseLookUpModel>> GetAll()
        {
            var activityPrivacyList = new List<BaseLookUpModel>();
            activityPrivacyList.Add(new ActivityPrivacy { Id = 1, Name = "Private", Description = "Can be viewed only by owner" });
            activityPrivacyList.Add(new ActivityPrivacy { Id = 2, Name = "Public", Description = "Can be viewed by anybody" });

            var activityStatusList = new List<BaseLookUpModel>();
            activityStatusList.Add(new ActivityStatus { Id = 1, Name = "Skipped", Description = "Activity Instance was skipped (not completed)" });
            activityStatusList.Add(new ActivityStatus { Id = 2, Name = "Partial", Description = "Activity Instance was partially completed" });
            activityStatusList.Add(new ActivityStatus { Id = 3, Name = "Completed", Description = "Activity Instance was completed" });

            var notificationTypeList = new List<BaseLookUpModel>();
            notificationTypeList.Add(new NotificationType { Id = 1, Name = "Email", Description = "Send notification to an email address" });
            notificationTypeList.Add(new NotificationType { Id = 2, Name = "Sms", Description = "Send notification to a Sms device" });
            notificationTypeList.Add(new NotificationType { Id = 3, Name = "Browser", Description = "Send notification via Broser Notification" });

            return new Dictionary<string, IEnumerable<BaseLookUpModel>>
            {
                { "ActivityPrivacy", activityPrivacyList },
                { "ActivityStatus", activityStatusList },
                { "NotificationType",  notificationTypeList }
            };
        }
    }
}
