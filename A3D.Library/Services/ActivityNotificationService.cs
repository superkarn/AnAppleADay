using A3D.Library.Models;
using A3D.Library.Repositories.Interfaces;
using A3D.Library.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace A3D.Library.Services
{
    public class ActivityNotificationService : IActivityNotificationService
    {
        private readonly IActivityNotificationRepository activityNotificationRepository;

        public ActivityNotificationService(IActivityNotificationRepository activityNotificationRepository)
        {
            this.activityNotificationRepository = activityNotificationRepository;
        }

        public void Create(ActivityNotification item)
        {
            this.activityNotificationRepository.Create(item);
        }

        public void DeleteByKey(int activityId, int notificationTypeId)
        {
            this.activityNotificationRepository.DeleteByKey(activityId, notificationTypeId);
        }

        public IEnumerable<ActivityNotification> GetByActivityId(int activityId)
        {
            return this.activityNotificationRepository.GetByActivityId(activityId);
        }

        public ActivityNotification GetByKey(int activityId, int notificationTypeId)
        {
            return this.activityNotificationRepository.GetByKey(activityId, notificationTypeId);
        }

        public void Update(ActivityNotification item)
        {
            var existingItem = this.activityNotificationRepository.GetByKey(item.ActivityId, item.NotificationTypeId);

            // TODO make this work with PATCH
            existingItem.IsEnabled = item.IsEnabled;
            existingItem.Recipient = item.Recipient;

            this.activityNotificationRepository.Update(item);
        }
    }
}
