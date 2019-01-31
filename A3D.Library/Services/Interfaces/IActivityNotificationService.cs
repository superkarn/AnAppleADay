using A3D.Library.Models;
using System.Collections.Generic;

namespace A3D.Library.Services.Interfaces
{
    public interface IActivityNotificationService
    {
        void Create(ApplicationContext context, ActivityNotification item);
        void DeleteByKey(ApplicationContext context, int activityId, int notificationTypeId);
        IEnumerable<ActivityNotification> GetByActivityId(ApplicationContext context, int activityId);
        ActivityNotification GetByKey(ApplicationContext context, int activityId, int notificationTypeId);
        void Update(ApplicationContext context, ActivityNotification item);
    }
}
