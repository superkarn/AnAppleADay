using A3D.Library.Models;
using System.Linq;

namespace A3D.Library.Data.Repositories.Interfaces
{
    public interface IActivityNotificationRepository
    {
        void Create(ActivityNotification item);
        void DeleteByKey(int activityId, int notificationTypeId);
        IQueryable<ActivityNotification> GetByActivityId(int activityId);
        ActivityNotification GetByKey(int activityId, int notificationTypeId);
        void Update(ActivityNotification item);
    }
}
