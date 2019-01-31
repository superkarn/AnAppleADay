using A3D.Library.Models;
using System.Collections.Generic;

namespace A3D.Library.Services.Interfaces
{
    public interface IActivityNotificationService
    {
        void Create(ActivityNotification item);
        void DeleteByKey(int activityId, int notificationTypeId);
        IEnumerable<ActivityNotification> GetByActivityId(int activityId);
        ActivityNotification GetByKey(int activityId, int notificationTypeId);
        void Update(ActivityNotification item);
    }
}
