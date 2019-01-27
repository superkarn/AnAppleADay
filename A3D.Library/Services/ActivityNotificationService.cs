using A3D.Library.Models;
using A3D.Library.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace A3D.Library.Services
{
    public class ActivityNotificationService : IActivityNotificationService
    {
        public int Create(ActivityNotification obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ActivityNotification> GetByActivityId(int activityId)
        {
            IList<ActivityNotification> list = new List<ActivityNotification>();
            list.Add(new ActivityNotification() { ActivityId = activityId, IsEnabled = true, Recipient = $"recipient1" });
            list.Add(new ActivityNotification() { ActivityId = activityId, IsEnabled = false, Recipient = $"recipient2" });
            list.Add(new ActivityNotification() { ActivityId = activityId, IsEnabled = true, Recipient = $"recipient3" });

            return list;
        }

        public ActivityNotification GetById(int id)
        {
            return new ActivityNotification() { ActivityId = 1000, IsEnabled = true, Recipient = $"recipient-{id}" };
        }

        public void Update(ActivityNotification obj)
        {
            throw new NotImplementedException();
        }
    }
}
