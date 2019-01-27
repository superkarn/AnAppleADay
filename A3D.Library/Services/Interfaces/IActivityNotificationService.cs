using A3D.Library.Models;
using System.Collections.Generic;

namespace A3D.Library.Services.Interfaces
{
    public interface IActivityNotificationService : ICrudService<ActivityNotification>
    {
        IEnumerable<ActivityNotification> GetByActivityId(int activityId);
    }
}
