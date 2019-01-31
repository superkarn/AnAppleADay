using System.Linq;
using A3D.Library.Models;
using A3D.Library.Repositories.Interfaces;

namespace A3D.Library.Repositories.EntityFramework
{
    public class ActivityNotificationRepository : BaseRepository<ActivityNotification>, IActivityNotificationRepository
    {
        public ActivityNotificationRepository(ApplicationDbContext context)
            : base(context)
        { }

        public void Create(ActivityNotification item)
        {
            this.Context.Add(item);
            this.Context.SaveChanges();
        }

        public void DeleteByKey(int activityId, int notificationTypeId)
        {
            ActivityNotification item = new ActivityNotification() { ActivityId = activityId, NotificationTypeId = notificationTypeId };
            this.Context.Attach(item);
            this.Context.Remove(item);
            this.Context.SaveChanges();
        }

        public IQueryable<ActivityNotification> GetByActivityId(int activityId)
        {
            return this.DbSet.Where(x => x.ActivityId == activityId);
        }

        public ActivityNotification GetByKey(int activityId, int notificationTypeId)
        {
            return this.DbSet.Find(activityId, notificationTypeId);
        }

        public void Update(ActivityNotification item)
        {
            var entity = this.Context.ActivityNotifications.Find(item.ActivityId, item.NotificationTypeId);

            this.Context.Entry(entity).CurrentValues.SetValues(item);
            this.Context.SaveChanges();
        }
    }
}
