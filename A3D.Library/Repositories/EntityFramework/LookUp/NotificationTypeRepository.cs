using A3D.Library.Models.LookUp;

namespace A3D.Library.Repositories.EntityFramework.LookUp
{
    public class NotificationTypeRepository : BaseLookUpRepository<NotificationType>
    {
        public NotificationTypeRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
