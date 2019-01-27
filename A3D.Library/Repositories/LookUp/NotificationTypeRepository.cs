using A3D.Library.Models.LookUp;
using A3D.Library.Repositories.EntityFramework;

namespace A3D.Library.Repositories.LookUp
{
    public class NotificationTypeRepository : BaseLookUpRepository<NotificationType>
    {
        public NotificationTypeRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
